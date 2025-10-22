using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Interop;
using SleepHunter.Interop.Windows;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SleepHunter.Extensions;

namespace SleepHunter.Forms
{

    public partial class MacroForm
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IWindowEnumerator windowEnumerator;
        private readonly IMacroCommandRegistry commandRegistry;
        private readonly IMacroCommandFactory commandFactory;

        private readonly List<MacroCommandObject> macroCommands = new List<MacroCommandObject>();

        private GameClientWindow clientWindow;
        private GameClientReader clientReader;
        private bool isAttached;

        private bool isRunning;
        private bool isPaused;

        public MacroForm(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            windowEnumerator = serviceProvider.GetRequiredService<IWindowEnumerator>();
            commandRegistry = serviceProvider.GetRequiredService<IMacroCommandRegistry>();
            commandFactory = serviceProvider.GetRequiredService<IMacroCommandFactory>();

            InitializeComponent();

            UpdateToolbarAndMenuState();
        }

        public MacroParameterValue[] ShowArgumentsForm(MacroCommandDefinition command,
            IReadOnlyList<MacroParameterValue> parameters = null)
        {
            // No args, nothing to show
            if (command.Parameters.Count == 0)
            {
                return Array.Empty<MacroParameterValue>();
            }

            // Set the command definition and existing parameters (if provided)
            var argsForm = serviceProvider.GetRequiredService<ArgumentsForm>();
            argsForm.Command = command;

            if (parameters != null)
            {
                argsForm.SetDefaultParameters(parameters);
            }

            // Show the arguments form for the command requested
            argsForm.ShowDialog(this);

            // Ignore if the user cancelled
            return argsForm.DialogResult != DialogResult.OK
                ? null
                : argsForm.Parameters.ToArray();
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

                    // Reduce indent for a closing command
                    if (commandObj != null && commandObj.Command.IsClosingCommand())
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
            isAttached = true;

            UpdateProcessUI();
        }

        private void DetachClient()
        {
            clientReader?.Dispose();

            isAttached = false;
            UpdateProcessUI();
        }

        private void UpdateProcessUI()
        {
            string characterName = string.Empty;
            try
            {
                if (isAttached)
                {
                    characterName = clientReader.ReadCharacterName();
                }
            }
            catch
            {
                DetachClient();
                return;
            }

            Text = isAttached ? $"{characterName} - Macro" : "Macro Data";

            clientVersionLabel.Text = isAttached ? "Client Version: 7.41" : "Client Version:";
            processIdLabel.Text = isAttached ? $"Process ID: {clientWindow.ProcessId}" : "Process ID:";
            windowHandleLabel.Text = isAttached ? $"Window Handle: {clientWindow.WindowHandle}" : "Window Handle:";
            characterNameLabel.Text = isAttached ? $"Character Name: {characterName}" : "Character Name:";

            clientVersionLabel.Enabled = isAttached;
            processIdLabel.Enabled = isAttached;
            windowHandleLabel.Enabled = isAttached;
            characterNameLabel.Enabled = isAttached;
        }

        private void UpdateToolbarAndMenuState()
        {
            var hasSingleSelection = macroListView.SelectedIndices.Count == 1;
            var hasMultipleSelection = macroListView.SelectedIndices.Count > 1;
            var isEmpty = macroListView.Items.Count == 0;
            var hasSelection = hasSingleSelection || hasMultipleSelection;

            // Check for parameter count, only commands with parameters are editable
            var hasParameters = false;
            if (hasSingleSelection)
            {
                var selectedListViewItem = macroListView.SelectedItems[0];
                if (selectedListViewItem.Tag is MacroCommandObject commandObj)
                {
                    hasParameters = commandObj.Parameters.Count > 0;
                }
            }

            if (hasSingleSelection)
            {
                editSelectedMenu.ShortcutKeyDisplayString = !hasParameters ? "(No Parameters)" : "Space";
            }
            else if (hasMultipleSelection)
            {
                editSelectedMenu.ShortcutKeyDisplayString = "(Multiple Selected)";
            }
            else
            {
                editSelectedMenu.ShortcutKeyDisplayString = "Space";
            }

            editButton.Enabled = editSelectedMenu.Enabled = !isEmpty && hasSingleSelection && hasParameters;
            deleteButton.Enabled = deleteSelectedMenu.Enabled = !isEmpty && hasSelection;

            cutButton.Enabled = cutSelectedMenu.Enabled = !isEmpty && hasSelection;
            copyButton.Enabled = copySelectedMenu.Enabled = !isEmpty && hasSelection;
            pasteButton.Enabled = pasteSelectedMenu.Enabled = false;

            moveUpButton.Enabled = moveUpMenu.Enabled = !isEmpty && hasSelection;
            moveDownButton.Enabled = moveDownMenu.Enabled = !isEmpty && hasSelection;

            playButton.Enabled = !isEmpty && !isRunning;
            pauseButton.Enabled = !isEmpty && isRunning && !isPaused;
            stopButton.Enabled = isRunning;
        }

        #region Quick Attach Toolbar

        private void quickAttachButton_DropDownOpening(object sender, System.EventArgs e)
        {
            quickAttachButton.DropDownItems.Clear();

            var clientWindows = windowEnumerator.FindWindows("Darkages");

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
                    var newItem = quickAttachButton.DropDownItems.Add(characterName);
                    newItem.Tag = new GameClientWindow(gameWindow.Handle, gameWindow.ProcessId);
                }
                catch
                {
                    continue;
                }
                finally
                {
                    reader?.Dispose();
                }
            }

            if (quickAttachButton.DropDownItems.Count == 0)
            {
                var placeholder = quickAttachButton.DropDownItems.Add("No Clients Found");
                placeholder.Enabled = false;
            }
        }

        private void quickAttachButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!(e.ClickedItem.Tag is GameClientWindow gameWindow))
            {
                return;
            }

            // TODO: Check macro state and stop it if already running
            AttachToClient(gameWindow);
        }

        #endregion

        private void processPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(GameClientWindow))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void processPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GameClientWindow)))
            {
                return;
            }

            try
            {
                var gameWindow = (GameClientWindow)e.Data.GetData(typeof(GameClientWindow));

                // TODO: Check macro state and stop it if already running
                AttachToClient(gameWindow);
            }
            catch
            {
                MessageBox.Show(this, "Unable to attach to the selected client.", "Quick Attach Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #region Macro List View Events

        private void macroListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(MacroCommandDefinition))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void macroListView_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(MacroCommandDefinition)))
            {
                return;
            }

            var definition = (MacroCommandDefinition)e.Data.GetData(typeof(MacroCommandDefinition));
            var parameters = ShowArgumentsForm(definition);

            // Ignore if not enough parameters provided
            if (parameters == null)
            {
                return;
            }

            AddMacroCommand(definition, parameters);
        }

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
            var size = macroListView.Size;
            var columnWidth = size.Width - macroListView.Columns[0].Width - 24;

            macroListView.Columns[1].Width = columnWidth;
        }

        #endregion

        #region Toolbar + Context Menu Events

        private void edit_Click(object sender, EventArgs e)
        {
            // Ensure there is a single selection of a command with parameters to edit
            if (macroListView.SelectedIndices.Count == 0 ||
                !(macroListView.SelectedItems[0].Tag is MacroCommandObject commandObj) ||
                commandObj.Parameters.Count == 0)
            {
                return;
            }

            var newParameters = ShowArgumentsForm(commandObj.Definition, commandObj.Parameters);
        }

        private void deleteSelected_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }

            DeleteMacroCommands(macroListView.SelectedIndices.ToList());
            macroListView.SelectedIndices.Clear();
            
            UpdateToolbarAndMenuState();
        }

        private void cutSelected_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }
        }

        private void copySelected_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }
        }

        private void paste_Click(object sender, EventArgs e)
        {

        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            if (macroListView.SelectedIndices.Count == 0)
            {
                return;
            }
        }

        #endregion

        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            clientReader?.Dispose();
        }
    }
}