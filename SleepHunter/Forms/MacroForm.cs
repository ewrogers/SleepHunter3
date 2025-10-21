using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Interop;
using SleepHunter.Interop.Windows;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;
using System;
using System.Windows.Forms;

namespace SleepHunter.Forms
{

    public partial class MacroForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IWindowEnumerator windowEnumerator;
        private GameClientWindow clientWindow;
        private GameClientReader clientReader;
        private bool isAttached;

        public MacroForm(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            windowEnumerator = serviceProvider.GetRequiredService<IWindowEnumerator>();

            InitializeComponent();
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

                if (quickAttachButton.DropDownItems.Count == 0)
                {
                    var placeholder = quickAttachButton.DropDownItems.Add("No Clients Found");
                    placeholder.Enabled = false;
                }
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
                MessageBox.Show(this, "Unable to attach to the selected client.", "Quick Attach Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

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

            var command = (MacroCommandDefinition)e.Data.GetData(typeof(MacroCommandDefinition));
            var argsForm = serviceProvider.GetRequiredService<ArgumentsForm>();
            argsForm.Command = command;
            argsForm.ShowDialog(this);
        }
    }
}