using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessesForm ProcessWindow;
        public MacroForm ActiveMacro;
        private bool DialogCancel = true;

        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            ProcessWindow = _serviceProvider.GetRequiredService<ProcessesForm>();

            InitializeComponent();
        }

        private void MdiChild_Activate(object sender, EventArgs e)
        {
            if (!(ActiveMdiChild is MacroForm macroForm))
                return;

            ActiveMacro = macroForm;
        }

        #region File Menu Actions
        private void NewMacroMenu_Click(object sender, EventArgs e)
        {
            var macroForm = _serviceProvider.GetRequiredService<MacroForm>();
            macroForm.MdiParent = this;
            macroForm.Show();
        }

        private void OpenMacroMenu_Click(object sender, EventArgs e)
        {
            DialogCancel = true;
            int num = (int)openFileDialog.ShowDialog(this);
            string[] fileNames = openFileDialog.FileNames;
            if (fileNames == null | DialogCancel)
                return;
            MacroReader macroReader = new MacroReader();
            foreach (string str in fileNames)
            {
                if (str.Trim() != "")
                {
                    string[] commands = macroReader.GetCommands(str.Trim());
                    string[] arguments = macroReader.GetArguments(str.Trim());
                    string fileTitle = macroReader.GetFileTitle(str.Trim());
                    statusLabel.Text = $"Opening {str}...";
                    MacroForm frmMacro = _serviceProvider.GetRequiredService<MacroForm>();
                    macroReader.AddCommandsToList(frmMacro.macroListView, commands, arguments);
                    frmMacro.MdiParent = this;
                    frmMacro.nameTextBox.Text = fileTitle;
                    frmMacro.Show();
                }
            }
            statusLabel.Text = "Idle.";
        }

        private void SaveMacroMenu_Click(object sender, EventArgs e)
        {
            if (ActiveMacro == null)
            {
                int num1 = (int)MessageBox.Show("No macro windows are open, cannot save.", "No Data Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (ActiveMacro.macroListView.Items.Count < 1)
            {
                int num2 = (int)MessageBox.Show("Macro window contains no data.", "Empty Macro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                saveFileDialog.FileName = ActiveMacro.nameTextBox.Text + ".sh3";
                DialogCancel = true;
                int num3 = (int)saveFileDialog.ShowDialog(this);
                if (DialogCancel)
                    return;
                string fileName = saveFileDialog.FileName;
                if (fileName == null || fileName.Trim() == "")
                    return;
                statusLabel.Text = $"Saving {fileName}...";
                string[] CommandList = new string[ActiveMacro.macroListView.Items.Count];
                string[] ArgList = new string[ActiveMacro.macroListView.Items.Count];
                int index = 0;
                foreach (ListViewItem listViewItem in ActiveMacro.macroListView.Items)
                {
                    string[] strArray = listViewItem.Tag.ToString().Split('|');
                    CommandList[index] = strArray[0];
                    ArgList[index] = strArray[1];
                    ++index;
                }
                new MacroWriter().SaveData(CommandList, ArgList, ActiveMacro.nameTextBox.Text.Trim(), fileName);
                statusLabel.Text = "Idle.";
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            // Do any additional cleanup here
            Application.Exit();
        }
        #endregion

        #region Tools Menu Actions

        private void StatusWindowMenu_Click(object sender, EventArgs e)
        {
            var statusForm = _serviceProvider.GetRequiredService<StatusForm>();
            statusForm.MdiParent = this;
            statusForm.Show();
        }

        private void ProcessManagerMenu_Click(object sender, EventArgs e)
        {
            if (ProcessWindow.IsDisposed)
            {
                ProcessWindow = _serviceProvider.GetRequiredService<ProcessesForm>();
                ProcessWindow.MdiParent = this;
                ProcessWindow.Location = new Point(0, 0);
                ProcessWindow.Width = ClientRectangle.Width - commandsPanel.ClientRectangle.Width - 4;
                ProcessWindow.Show();
            }
            else
            {
                ProcessWindow.MdiParent = this;
                ProcessWindow.Show();
            }
        }

        private void OptionsWindowMenu_Click(object sender, EventArgs e)
        {
            var optionsForm = _serviceProvider.GetRequiredService<OptionsForm>();
            optionsForm.ShowDialog(this);
        }

        #endregion

        #region Window Layout Menu Actions
        private void MinimizeAllMenu_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                mdiChild.WindowState = FormWindowState.Minimized;
            }
        }


        private void CloseAllWindowsMenu_Click(object sender, EventArgs e)
        {
            foreach (Component mdiChild in MdiChildren)
            {
                mdiChild.Dispose();
            }
        }

        private void ArrangeWindowsMenu_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.ArrangeIcons);
        private void CascadeWindowsMenu_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);
        private void TileVerticalMenu_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);
        private void TileHorizontalMenu_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);
        #endregion

        #region Help Menu Actions
        private void AboutMenu_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        #endregion

        private void CommandsTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = commandsTreeView.SelectedNode;
            if (selectedNode.Nodes.Count != 0 || ActiveMacro == null || ActiveMacro.IsDisposed)
                return;

            var commandText = $"{selectedNode.Text}|{selectedNode.Tag}";
            //ActiveMacro.AddCommand(commandText);
        }

        private void CommandsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode treeNode) || treeNode.Parent == null | treeNode.Tag == null)
                return;

            var commandText = $"{treeNode.Text}|{treeNode.Tag}";
            DoDragDrop(commandText, DragDropEffects.Copy);
        }

        #region File Dialog Handlers
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e) => DialogCancel = false;

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e) => DialogCancel = false;
        #endregion

        public void DetachByPID(uint processID)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                if (mdiChild is MacroForm)
                {
                    MacroForm frmMacro = (MacroForm)mdiChild;
                    if (frmMacro.processIdLabel.Text.EndsWith(processID.ToString()))
                    {
                        frmMacro.processIdLabel.Text = "Process ID:";
                        frmMacro.clientVersionLabel.Text = "Process Name:";
                        frmMacro.windowHandleLabel.Text = "Window Handle:";
                        frmMacro.characterNameLabel.Text = "Character Name:";
                        frmMacro.statusLabel.Text = "Macro is not running.";
                        frmMacro.statusLabel.Image = frmMacro.statusImageList.Images[2];
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != 786)
                return;
            HotkeyAction((int)m.WParam);
        }

        public void HotkeyAction(int hotkeyID)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                if (mdiChild is MacroForm)
                {
                    MacroForm frmMacro = (MacroForm)mdiChild;
                    //if (frmMacro.hotkey.HotkeyID == hotkeyID)
                    //{
                    //    if (frmMacro.MacroRunning)
                    //    {
                    //        frmMacro.StopButton();
                    //        break;
                    //    }
                    //    frmMacro.PlayButton();
                    //    break;
                    //}
                }
            }
        }
    }
}