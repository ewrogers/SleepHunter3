using SleepHunter.Interop;
using SleepHunter.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ProcessesForm : Form
    {
        private readonly IGameClientService _gameClientService;

        private readonly Graphics _processListViewGraphics;
        private readonly Pen _borderPen;
        private readonly Brush _placeholderBrush;
        private readonly Font _placeholderFont;
        private readonly StringFormat _placeholderStringFormat;

        public ProcessesForm(IGameClientService gameClientService)
        {
            _gameClientService = gameClientService;

            InitializeComponent();

            _processListViewGraphics = Graphics.FromHwnd(processListView.Handle);
            _borderPen = new Pen(SystemColors.ControlDark);

            _placeholderBrush = new SolidBrush(SystemColors.ControlText);
            _placeholderFont = new Font("Tahoma", 10f, FontStyle.Bold);
            _placeholderStringFormat = new StringFormat(StringFormat.GenericDefault)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
        }


        private void processListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var listViewItem = e.Item as ListViewItem;
            var data = new DataObject(listViewItem.Tag);

            DoDragDrop(data, DragDropEffects.Copy);
        }

        private void processPanel_Paint(object sender, PaintEventArgs e)
        {
            var clientRectangle = processPanel.ClientRectangle;
            clientRectangle.Inflate(-4, -4);
            e.Graphics.DrawRectangle(_borderPen, clientRectangle);

            if (processListView.Items.Count == 0)
            {
                DrawPlaceholderText("No Dark Ages Processes Running.");
            }
        }

        private void form_Shown(object sender, EventArgs e) => ScanForProcesses();
        private void refreshButton_Click(object sender, EventArgs e) => ScanForProcesses();

        private void ScanForProcesses()
        {
            refreshButton.Enabled = false;

            processListView.BeginUpdate();
            processListView.Items.Clear();

            try
            {
                var clientWindows = _gameClientService.FindClientWindows();

                foreach (var clientWindow in clientWindows)
                {
                    var reader = new GameClientReader(clientWindow.ProcessId);

                    try
                    {
                        // First check that it matches the client version signature
                        var signature = reader.ReadVersion();
                        if (!string.Equals(signature, GameClientReader.Version741, StringComparison.Ordinal))
                        {
                            continue;
                        }

                        // Get client name
                        var name = reader.ReadCharacterName();
                        var displayName = !string.IsNullOrWhiteSpace(name) ? $"Darkages.exe ({name})" : "Darkages.exe";

                        // Add the process list view
                        var listViewItem = processListView.Items.Add(displayName, 0);
                        listViewItem.Group = processListView.Groups[2];
                        listViewItem.Tag = clientWindow;
                    }
                    finally
                    {
                        reader.Dispose();
                    }
                }
            }
            finally
            {
                processListView.EndUpdate();
                refreshButton.Enabled = true;
            }

            if (processListView.Items.Count == 0)
            {
                DrawPlaceholderText("No Dark Ages Processes Running.");
            }
        }

        private void DrawPlaceholderText(string text)
        {
            processListView.Refresh();
            _processListViewGraphics.DrawString(text, _placeholderFont, _placeholderBrush, processListView.ClientRectangle, _placeholderStringFormat);
        }

        private void ProcessesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _processListViewGraphics.Dispose();
        }
    }
}