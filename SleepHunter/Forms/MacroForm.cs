using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Interop;
using SleepHunter.Interop.Windows;
using SleepHunter.Models;
using System;
using System.Windows.Forms;

namespace SleepHunter.Forms
{

    public partial class MacroForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWindowEnumerator _windowEnumerator;
        private GameClientWindow _clientWindow;
        private GameClientReader _clientReader;
        private bool _isAttached;

        public MacroForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _windowEnumerator = _serviceProvider.GetRequiredService<IWindowEnumerator>();

            InitializeComponent();
        }

        private void AttachToClient(GameClientWindow window)
        {
            if (_clientReader != null)
            {
                _clientReader.Dispose();
            }

            _clientWindow = window;
            _clientReader = new GameClientReader(_clientWindow.ProcessId);
            _isAttached = true;

            UpdateProcessUI();
        }

        private void DetachClient()
        {
            if (_clientReader != null)
            {
                _clientReader.Dispose();
            }

            _isAttached = false;
            UpdateProcessUI();
        }

        private void UpdateProcessUI()
        {
            string characterName = string.Empty;
            try
            {
                if (_isAttached)
                {
                    characterName = _clientReader.ReadCharacterName();
                }
            }
            catch
            {
                DetachClient();
                return;
            }

            Text = _isAttached ? $"{characterName} - Macro" : "Macro Data";

            clientVersionLabel.Text = _isAttached ? "Client Version: 7.41" : "Client Version:";
            processIdLabel.Text = _isAttached ? $"Process ID: {_clientWindow.ProcessId}" : "Process ID:";
            windowHandleLabel.Text = _isAttached ? $"Window Handle: {_clientWindow.WindowHandle}" : "Window Handle:";
            characterNameLabel.Text = _isAttached ? $"Character Name: {characterName}" : "Character Name:";

            clientVersionLabel.Enabled = _isAttached;
            processIdLabel.Enabled = _isAttached;
            windowHandleLabel.Enabled = _isAttached;
            characterNameLabel.Enabled = _isAttached;
        }

        #region Quick Attach Toolbar

        private void quickAttachButton_DropDownOpening(object sender, System.EventArgs e)
        {
            quickAttachButton.DropDownItems.Clear();

            var clientWindows = _windowEnumerator.FindWindows("Darkages");

            foreach (var clientWindow in clientWindows)
            {
                GameClientReader reader = null;

                try
                {
                    reader = new GameClientReader(clientWindow.ProcessId);
                    var signature = reader.ReadVersion();

                    if (!string.Equals(signature, GameClientReader.Version741, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    var characterName = reader.ReadCharacterName();
                    var newItem = quickAttachButton.DropDownItems.Add(characterName);
                    newItem.Tag = new GameClientWindow(clientWindow.Handle, clientWindow.ProcessId);
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
            if (!(e.ClickedItem.Tag is GameClientWindow clientWindow))
            {
                return;
            }

            // TODO: Check macro state and stop it if already running
            AttachToClient(clientWindow);
        }
        #endregion

        private void processPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GameClientWindow)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void processPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GameClientWindow)))
            {
                return;
            }

            try
            {
                var clientWindow = (GameClientWindow)e.Data.GetData(typeof(GameClientWindow));

                // TODO: Check macro state and stop it if already running
                AttachToClient(clientWindow);
            }
            catch
            {
                MessageBox.Show(this, "Unable to attach to the selected client.", "Quick Attach Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
    }
}