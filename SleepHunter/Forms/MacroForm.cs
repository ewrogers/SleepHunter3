using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Interop;
using SleepHunter.Interop.Windows;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SleepHunter.Macro;
using SleepHunter.Macro.Serialization;
using System.Linq;
using System.Drawing;
using SleepHunter.Interop.Hotkey;
using SleepHunter.Macro.Commands.Logic;

namespace SleepHunter.Forms
{

    public partial class MacroForm
    {
        private static readonly Color DebugStepHighlightColor = Color.FromArgb(0xFF, 0xF0, 0x85);
        private static readonly Color ValidationHighlightColor = Color.FromArgb(0xFF, 0xC9, 0xC9);
        private static readonly Color ValidationTextColor = Color.FromArgb(0xE7, 0x00, 0x0B);

        private readonly IServiceProvider serviceProvider;
        private readonly IWindowEnumerator windowEnumerator;
        private readonly IMacroCommandRegistry commandRegistry;
        private readonly IMacroCommandFactory commandFactory;
        private readonly IMacroSerializer serializer;
        
        private readonly List<MacroCommandObject> macroCommands = new List<MacroCommandObject>();

        private GameClientWindow clientWindow;
        private GameClientReader clientReader;
        private IMacroExecutor macroExecutor;
        private GlobalHotkey hotkey;

        private string macroName = string.Empty;
        private string macroAuthor = string.Empty;

        private bool debugStepEnabled;
        private ListViewItem highlightedItem;
        private string validationErrorMessage;

        public bool IsClientAttached { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }
        public MacroStopReason StopReason { get; private set; }

        public MacroForm(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            windowEnumerator = serviceProvider.GetRequiredService<IWindowEnumerator>();
            commandRegistry = serviceProvider.GetRequiredService<IMacroCommandRegistry>();
            commandFactory = serviceProvider.GetRequiredService<IMacroCommandFactory>();
            serializer = serviceProvider.GetRequiredService<IMacroSerializer>();
            
            InitializeComponent();

            UpdateMacroUi();
            UpdateToolbarAndMenuState();
            UpdateStatusBarState();
        }

        private void ReformatLines()
        {
            macroListView.BeginUpdate();

            try
            {
                var lineNumber = 1;
                var indent = 0;

                var sb = new StringBuilder();

                foreach (ListViewItem listViewItem in macroListView.Items)
                {
                    sb.Clear();

                    var commandObj = listViewItem.Tag as MacroCommandObject;

                    // Re-calculate the line number
                    listViewItem.SubItems[0].Text = (lineNumber++).ToString().PadLeft(8, ' ');

                    // Reduce indent for a closing command, and also for Else (acts as close-then-open)
                    if (commandObj != null && (commandObj.Command.IsClosingCommand() || commandObj.Command is ElseCommand))
                    {
                        indent = Math.Max(0, indent - 1);
                    }

                    // Re-indent the line
                    if (indent > 0)
                    {
                        sb.Append(' ', indent * 2);
                    }

                    sb.Append(listViewItem.SubItems[1].Text.Trim());

                    listViewItem.SubItems[1].Text = sb.ToString();

                    // Increase indent level after an opening command
                    if (commandObj != null && commandObj.Command.IsOpeningCommand())
                    {
                        indent++;
                    }
                }
            }
            finally
            {
                macroListView.EndUpdate();
            }
        }

        private void AttachToClient(GameClientWindow window)
        {
            clientReader?.Dispose();

            clientWindow = window;
            clientReader = new GameClientReader(clientWindow.ProcessId);
            IsClientAttached = true;

            UpdateMacroUi();
            UpdateToolbarAndMenuState();
        }

        private void DetachClient()
        {
            clientReader?.Dispose();
            IsClientAttached = false;

            if (IsRunning)
            {
                StopMacro(MacroStopReason.ProcessNotFound);
            }

            UpdateMacroUi();
            UpdateToolbarAndMenuState();
        }

        #region Macro State Buttons

        private void playButton_Click(object sender, EventArgs e)
        {
            if (IsRunning && !IsPaused)
            {
                return;
            }

            if (IsPaused)
            {
                ResumeMacro();
            }
            else
            {
                ValidateMacro();

                if (string.IsNullOrWhiteSpace(validationErrorMessage))
                {
                    StartMacro();
                }
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                return;
            }

            PauseMacro();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                return;
            }

            StopMacro(MacroStopReason.UserStopped);
        }

        #endregion

        #region Quick Attach Toolbar

        private void quickAttachButton_DropDownOpening(object sender, EventArgs e)
        {
            quickAttachButton.DropDownItems.Clear();

            var clientWindows = windowEnumerator.FindWindows("Darkages");
            var sortedList = new SortedList<string, GameClientWindow>();

            foreach (var gameWindow in clientWindows)
            {
                GameClientReader reader = null;

                try
                {
                    reader = new GameClientReader(gameWindow.ProcessId);
                    var signature = reader.ReadVersion();

                    if (!string.Equals(signature, GameClientReader.Version741, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    var characterName = reader.ReadCharacterName();
                    var newWindow = new GameClientWindow(gameWindow.Handle, gameWindow.ProcessId);
                    sortedList.Add(characterName, newWindow);
                }
                catch
                {
                    // Do nothing
                }
                finally
                {
                    reader?.Dispose();
                }
            }

            // Ensure we add them in sorted alphabetical order
            foreach (var item in sortedList)
            {
                var newItem = quickAttachButton.DropDownItems.Add(item.Key);
                newItem.Tag = item.Value;

                newItem.Enabled = !IsRunning;
            }

            if (quickAttachButton.DropDownItems.Count == 0)
            {
                var placeholder = quickAttachButton.DropDownItems.Add("No Clients Found");
                placeholder.Enabled = false;
            }
        }

        private void quickAttachButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (IsRunning || !(e.ClickedItem.Tag is GameClientWindow gameWindow))
            {
                return;
            }

            AttachToClient(gameWindow);
        }

        #endregion

        #region Macro List View Events

        private void macroListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateToolbarAndMenuState();
        }

        private void macroListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Edit on spacebar pressed
            if (e.KeyChar != ' ' || macroListView.SelectedIndices.Count != 1)
            {
                return;
            }

            e.Handled = true;
            edit_Click(sender, e);
        }

        private void macroListView_DoubleClick(object sender, EventArgs e)
        {
            // Edit on double click
            if (macroListView.SelectedIndices.Count == 1)
            {
                edit_Click(sender, e);
            }
        }

        private void macroListView_SizeChanged(object sender, EventArgs e)
        {
            if (macroListView.Columns.Count < 2)
            {
                return;
            }

            var size = macroListView.Size;
            var columnWidth = size.Width - macroListView.Columns[0].Width - 24;

            macroListView.Columns[1].Width = columnWidth;
        }

        #endregion

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            macroName = nameTextBox.Text.Trim();
            UpdateMacroUi();
        }

        private void authorTextBox_TextChanged(object sender, EventArgs e)
        {
            macroAuthor = authorTextBox.Text.Trim();
        }

        #region Toolbar + Context Menu Events

        private void edit_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            // Ensure there is a single selection of a command with parameters to edit
            if (macroListView.SelectedIndices.Count == 0 ||
                !(macroListView.SelectedItems[0].Tag is MacroCommandObject commandObj) ||
                commandObj.Parameters.Count == 0)
            {
                return;
            }

            var targetIndex = macroListView.SelectedIndices[0];

            var newParameters = ShowArgumentsForm(commandObj.Definition, commandObj.Parameters);
            if (newParameters != null)
            {
                ReplaceCommand(commandObj.Definition, newParameters, targetIndex);
            }
        }

        private void deleteSelected_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }

            DeleteMacroCommands(GetSelectedIndices().ToList());
            macroListView.SelectedIndices.Clear();

            UpdateToolbarAndMenuState();
        }

        private void cutSelected_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }

            var selectedIndexes = GetSelectedIndices().ToList();
            CopyToClipboard(selectedIndexes);

            DeleteMacroCommands(selectedIndexes);
            UpdateToolbarAndMenuState();
        }

        private void copySelected_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }

            CopyToClipboard(GetSelectedIndices().ToList());
            UpdateToolbarAndMenuState();
        }

        private void paste_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            TryPasteFromClipboard();
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            // Check if allowed to move up
            if (macroListView.SelectedIndices.Count == 0 ||
                macroListView.SelectedIndices[0] <= 0)
            {
                return;
            }

            var targetIndex = macroListView.SelectedIndices[0] - 1;
            MoveMacroCommands(GetSelectedIndices().ToList(), targetIndex);
            UpdateToolbarAndMenuState();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                return;
            }

            // Check if allowed to move down
            if (macroListView.SelectedIndices.Count == 0 ||
                macroListView.SelectedIndices[macroListView.SelectedIndices.Count - 1] >= macroCommands.Count - 1)
            {
                return;
            }

            var tagetIndex = macroListView.SelectedIndices[macroListView.SelectedIndices.Count - 1] + 2;
            MoveMacroCommands(GetSelectedIndices().ToList(), tagetIndex);
            UpdateToolbarAndMenuState();
        }

        private void debugStepButton_CheckedChanged(object sender, EventArgs e)
        {
            debugStepEnabled = debugStepButton.Checked;
            macroExecutor?.SetDebugStepEnabled(debugStepEnabled);
        }

        #endregion

        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            hotkey?.Dispose();
            clientReader?.Dispose();

            if (macroExecutor != null)
            {
                macroExecutor.DebugStep -= OnMacroDebugStep;
                macroExecutor.StateChanged -= OnMacroStateChanged;
                macroExecutor.Exception -= OnMacroException;

                macroExecutor.StopAsync();
                macroExecutor.Dispose();
            }
        }
    }
}