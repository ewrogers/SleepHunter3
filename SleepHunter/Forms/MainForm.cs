using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private uint[] HandledDupes = new uint[0];
        public ProcessesForm ProcessWindow = new ProcessesForm();
        public MacroForm ActiveMacro;
        private bool DialogCancel = true;


        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        private void MdiChild_Activate(object sender, EventArgs e)
        {
            if (!(ActiveMdiChild is MacroForm))
                return;

            ActiveMacro = (MacroForm)ActiveMdiChild;
        }

        #region File Menu Actions
        private void NewMacroMenu_Click(object sender, EventArgs e)
        {
            MacroForm frmMacro = new MacroForm();
            frmMacro.MdiParent = this;
            frmMacro.Show();
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
                    lblStatus.Text = $"Opening {str}...";
                    MacroForm frmMacro = new MacroForm();
                    macroReader.AddCommandsToList(frmMacro.lvwMacro, commands, arguments);
                    frmMacro.MdiParent = this;
                    frmMacro.txtName.Text = fileTitle;
                    frmMacro.ClearNullEntries();
                    frmMacro.ReNumberLines();
                    frmMacro.IndentLines();
                    frmMacro.Show();
                }
            }
            lblStatus.Text = "Idle.";
        }

        private void SaveMacroMenu_Click(object sender, EventArgs e)
        {
            if (ActiveMacro == null)
            {
                int num1 = (int)MessageBox.Show("No macro windows are open, cannot save.", "No Data Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (ActiveMacro.lvwMacro.Items.Count < 1)
            {
                int num2 = (int)MessageBox.Show("Macro window contains no data.", "Empty Macro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                saveFileDialog.FileName = ActiveMacro.txtName.Text + ".sh3";
                DialogCancel = true;
                int num3 = (int)saveFileDialog.ShowDialog(this);
                if (DialogCancel)
                    return;
                string fileName = saveFileDialog.FileName;
                if (fileName == null || fileName.Trim() == "")
                    return;
                lblStatus.Text = $"Saving {fileName}...";
                string[] CommandList = new string[ActiveMacro.lvwMacro.Items.Count];
                string[] ArgList = new string[ActiveMacro.lvwMacro.Items.Count];
                int index = 0;
                foreach (ListViewItem listViewItem in ActiveMacro.lvwMacro.Items)
                {
                    string[] strArray = listViewItem.Tag.ToString().Split('|');
                    CommandList[index] = strArray[0];
                    ArgList[index] = strArray[1];
                    ++index;
                }
                new MacroWriter().SaveData(CommandList, ArgList, ActiveMacro.txtName.Text.Trim(), fileName);
                lblStatus.Text = "Idle.";
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
            StatusForm frmStatus = new StatusForm();
            frmStatus.MdiParent = this;
            frmStatus.Show();
        }

        private void ProcessManagerMenu_Click(object sender, EventArgs e)
        {
            if (ProcessWindow.IsDisposed)
            {
                ProcessWindow = new ProcessesForm();
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

        // This is no longer used!
        private void ChatWindowMenu_Click(object sender, EventArgs e)
        {
            ChatForm frmChat = new ChatForm();
            frmChat.MdiParent = this;
            frmChat.Show();
        }

        private void OptionsWindowMenu_Click(object sender, EventArgs e)
        {
            OptionsForm frmOptions = new OptionsForm();
            frmOptions.MdiParent = this;
            frmOptions.Show();
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
            ActiveMacro.AddCommand(commandText);
        }

        private void CommandsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode treeNode) || treeNode.Parent == null | treeNode.Tag == null)
                return;

            var commandText = $"{treeNode.Text}|{treeNode.Tag}";
            DoDragDrop(commandText, DragDropEffects.Copy);
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            Form[] mdiChildren = MdiChildren;
            uint[] array = new uint[mdiChildren.Length];
            int index1 = 0;
            foreach (Form form in mdiChildren)
            {
                if (form is MacroForm)
                {
                    MacroForm frmMacro = (MacroForm)form;
                    if (frmMacro.memRead != null)
                        array[index1] = frmMacro.memRead.ProcessID;
                }
                ++index1;
            }

            for (int index2 = 0; index2 < array.Length; ++index2)
            {
                if (Array.IndexOf(array, array[index2]) != Array.LastIndexOf(array, array[index2]) & array[index2] > 0U && Array.IndexOf(HandledDupes, array[index2]) < 0)
                {
                    notifyIcon.ShowBalloonTip(2500, "Overloaded Process", $"You have attached two different macros to the same process.{Environment.NewLine}{Environment.NewLine}It is suggested that you correct this unless you are sure the actions of both macros will not interfere with each other.", ToolTipIcon.Warning);
                    uint[] handledDupes = HandledDupes;
                    uint[] numArray = new uint[handledDupes.Length + 1];
                    handledDupes.CopyTo(numArray, 0);
                    numArray[numArray.Length - 1] = array[index2];
                    HandledDupes = numArray;
                }
            }
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
                    if (frmMacro.lblProcessID.Text.EndsWith(processID.ToString()))
                    {
                        frmMacro.MacroRunning = false;
                        frmMacro.memRead.DetachProcess();
                        frmMacro.lblProcessID.Text = "Process ID:";
                        frmMacro.lblProcessName.Text = "Process Name:";
                        frmMacro.lblWindowHandle.Text = "Window Handle:";
                        frmMacro.lblCharName.Text = "Character Name:";
                        frmMacro.lblStatus.Text = "Macro is not running.";
                        frmMacro.lblStatus.Image = frmMacro.ilsStatusIcons.Images[2];
                        frmMacro.memRead = null;
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
                    if (frmMacro.hotkey.HotkeyID == hotkeyID)
                    {
                        if (frmMacro.MacroRunning)
                        {
                            frmMacro.StopButton();
                            break;
                        }
                        frmMacro.PlayButton();
                        break;
                    }
                }
            }
        }



        
    }
}