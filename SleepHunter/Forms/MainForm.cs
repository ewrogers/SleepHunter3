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

        private void mnuNew_Click(object sender, EventArgs e)
        {
            MacroForm frmMacro = new MacroForm();
            frmMacro.MdiParent = this;
            frmMacro.Show();
        }

        private void tvwCommands_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treeNode = (TreeNode)e.Item;
            if (treeNode.Parent == null | treeNode.Tag == null)
                return;
            int num = (int)DoDragDrop($"{treeNode.Text}|{treeNode.Tag}", DragDropEffects.Copy);
        }

        private void mnuAttach_Click(object sender, EventArgs e)
        {
            if (ProcessWindow.IsDisposed)
            {
                ProcessWindow = new ProcessesForm();
                ProcessWindow.MdiParent = this;
                ProcessWindow.Location = new Point(0, 0);
                ProcessWindow.Width = ClientRectangle.Width - pnlCommands.ClientRectangle.Width - 4;
                ProcessWindow.Show();
            }
            else
            {
                ProcessWindow.MdiParent = this;
                ProcessWindow.Show();
            }
        }

        private void mnuStatus_Click(object sender, EventArgs e)
        {
            StatusForm frmStatus = new StatusForm();
            frmStatus.MdiParent = this;
            frmStatus.Show();
        }

        private void tmrDblTargetChk_Tick(object sender, EventArgs e)
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
                    nidIcon.ShowBalloonTip(2500, "Overloaded Process", $"You have attached two different macros to the same process.{Environment.NewLine}{Environment.NewLine}It is suggested that you correct this unless you are sure the actions of both macros will not interfere with each other.", ToolTipIcon.Warning);
                    uint[] handledDupes = HandledDupes;
                    uint[] numArray = new uint[handledDupes.Length + 1];
                    handledDupes.CopyTo(numArray, 0);
                    numArray[numArray.Length - 1] = array[index2];
                    HandledDupes = numArray;
                }
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            DialogCancel = true;
            int num = (int)dlgOpen.ShowDialog(this);
            string[] fileNames = dlgOpen.FileNames;
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

        private void mnuSave_Click(object sender, EventArgs e)
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
                dlgSave.FileName = ActiveMacro.txtName.Text + ".sh3";
                DialogCancel = true;
                int num3 = (int)dlgSave.ShowDialog(this);
                if (DialogCancel)
                    return;
                string fileName = dlgSave.FileName;
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

        private void dlgOpen_FileOk(object sender, CancelEventArgs e) => DialogCancel = false;

        private void dlgSave_FileOk(object sender, CancelEventArgs e) => DialogCancel = false;

        private void mnuMinAll_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in MdiChildren)
                mdiChild.WindowState = FormWindowState.Minimized;
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Component mdiChild in MdiChildren)
                mdiChild.Dispose();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            int num = (int)new AboutForm().ShowDialog(this);
        }

        private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();

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

        private void tvwCommands_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvwCommands.SelectedNode;
            if (selectedNode.Nodes.Count != 0 || ActiveMacro == null || ActiveMacro.IsDisposed)
                return;
            ActiveMacro.AddCommand($"{selectedNode.Text}|{selectedNode.Tag}");
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (!(ActiveMdiChild is MacroForm))
                return;
            ActiveMacro = (MacroForm)ActiveMdiChild;
        }

        private void chatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatForm frmChat = new ChatForm();
            frmChat.MdiParent = this;
            frmChat.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm frmOptions = new OptionsForm();
            frmOptions.MdiParent = this;
            frmOptions.Show();
        }

        private void mnuArrange_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);

        private void mnuTileVert_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuTileHoriz_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}