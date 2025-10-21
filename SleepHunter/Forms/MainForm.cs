using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Macro.Commands;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMacroCommandRegistry commandRegistry;

        private ProcessesForm processWindow;
        private MacroForm activeMacro;
        private bool dialogCancel = true;

        public MainForm(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            commandRegistry = serviceProvider.GetService<IMacroCommandRegistry>();

            processWindow = this.serviceProvider.GetRequiredService<ProcessesForm>();

            InitializeComponent();
        }

        private void MdiChild_Activate(object sender, EventArgs e)
        {
            if (!(ActiveMdiChild is MacroForm macroForm))
                return;

            activeMacro = macroForm;
        }

        #region File Menu Actions
        private void NewMacroMenu_Click(object sender, EventArgs e)
        {
            var macroForm = serviceProvider.GetRequiredService<MacroForm>();
            macroForm.MdiParent = this;
            macroForm.Show();
        }

        private void OpenMacroMenu_Click(object sender, EventArgs e)
        {
            dialogCancel = true;
            int num = (int)openFileDialog.ShowDialog(this);
            string[] fileNames = openFileDialog.FileNames;
            if (fileNames == null | dialogCancel)
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
                    MacroForm frmMacro = serviceProvider.GetRequiredService<MacroForm>();
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
            if (activeMacro == null)
            {
                int num1 = (int)MessageBox.Show("No macro windows are open, cannot save.", "No Data Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (activeMacro.macroListView.Items.Count < 1)
            {
                int num2 = (int)MessageBox.Show("Macro window contains no data.", "Empty Macro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                saveFileDialog.FileName = activeMacro.nameTextBox.Text + ".sh3";
                dialogCancel = true;
                int num3 = (int)saveFileDialog.ShowDialog(this);
                if (dialogCancel)
                    return;
                string fileName = saveFileDialog.FileName;
                if (fileName == null || fileName.Trim() == "")
                    return;
                statusLabel.Text = $"Saving {fileName}...";
                string[] commandList = new string[activeMacro.macroListView.Items.Count];
                string[] argList = new string[activeMacro.macroListView.Items.Count];
                int index = 0;
                foreach (ListViewItem listViewItem in activeMacro.macroListView.Items)
                {
                    string[] strArray = listViewItem.Tag.ToString().Split('|');
                    commandList[index] = strArray[0];
                    argList[index] = strArray[1];
                    ++index;
                }
                new MacroWriter().SaveData(commandList, argList, activeMacro.nameTextBox.Text.Trim(), fileName);
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
            var statusForm = serviceProvider.GetRequiredService<StatusForm>();
            statusForm.MdiParent = this;
            statusForm.Show();
        }

        private void ProcessManagerMenu_Click(object sender, EventArgs e)
        {
            if (processWindow.IsDisposed)
            {
                processWindow = serviceProvider.GetRequiredService<ProcessesForm>();
                processWindow.MdiParent = this;
                processWindow.Location = new Point(0, 0);
                processWindow.Width = ClientRectangle.Width - commandsPanel.ClientRectangle.Width - 4;
                processWindow.Show();
            }
            else
            {
                processWindow.MdiParent = this;
                processWindow.Show();
            }
        }

        private void OptionsWindowMenu_Click(object sender, EventArgs e)
        {
            var optionsForm = serviceProvider.GetRequiredService<OptionsForm>();
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
            if (selectedNode == null || activeMacro == null || activeMacro.IsDisposed)
            {
                return;
            }

            if (!(selectedNode.Tag is MacroCommandDefinition selectedCommand))
            {
                return;
            }

            var argsForm = serviceProvider.GetRequiredService<ArgumentsForm>();
            argsForm.Command = selectedCommand;
            argsForm.ShowDialog(this);
        }

        private void CommandsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode treeNode) || !(treeNode.Tag is MacroCommandDefinition command))
            {
                return;
            }

            var data = new DataObject(command);
            DoDragDrop(data, DragDropEffects.Copy);
        }

        #region File Dialog Handlers
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e) => dialogCancel = false;

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e) => dialogCancel = false;
        #endregion

        public void DetachByPid(uint ProcessId)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                if (mdiChild is MacroForm)
                {
                    MacroForm frmMacro = (MacroForm)mdiChild;
                    if (frmMacro.processIdLabel.Text.EndsWith(ProcessId.ToString()))
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

        public void HotkeyAction(int HotkeyId)
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

        private void form_Load(object sender, EventArgs e)
        {
            LoadCommandLibrary();
        }

        private void LoadCommandLibrary()
        {
            commandsTreeView.Nodes.Clear();
            commandsTreeView.BeginUpdate();

            commandsTreeView.Sorted = false;

            try
            {
                var groupedCommands = commandRegistry.Commands
                    .GroupBy(x => x.Category)
                    .OrderBy(x => x.Key);

                foreach (var groupedCommand in groupedCommands)
                {
                    var category = groupedCommand.Key;
                    var commands = groupedCommand.ToList();

                    var parentNode = commandsTreeView.Nodes.Add($"{category} Commands");
                    parentNode.ImageIndex = 0;
                    parentNode.SelectedImageIndex = 0;

                    foreach (var command in commands)
                    {
                        var childNode = parentNode.Nodes.Add(command.DisplayName);
                        childNode.ImageIndex = 1;
                        childNode.SelectedImageIndex = 1;
                        childNode.ToolTipText = command.Description;
                        childNode.Tag = command;
                    }
                }
            }
            finally
            {
                commandsTreeView.EndUpdate();
            }
        }        
    }
}