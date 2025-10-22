using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Macro.Commands;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MainForm
    {
        private const int WM_HOTKEY = 0x312;

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
            var num = (int)openFileDialog.ShowDialog(this);
            var fileNames = openFileDialog.FileNames;
            if (fileNames == null | dialogCancel)
                return;
            var macroReader = new MacroReader();
            
            foreach (var str in fileNames)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }

                var commands = macroReader.GetCommands(str.Trim());
                var arguments = macroReader.GetArguments(str.Trim());
                var fileTitle = macroReader.GetFileTitle(str.Trim());
                statusLabel.Text = $"Opening {str}...";
                var macroForm = serviceProvider.GetRequiredService<MacroForm>();
                //macroReader.AddCommandsToList(frmMacro.macroListView, commands, arguments);
                macroForm.MdiParent = this;
                // macroForm.nameTextBox.Text = fileTitle;
                macroForm.Show();
            }

            statusLabel.Text = "Idle.";
        }

        private void SaveMacroMenu_Click(object sender, EventArgs e)
        {
            if (activeMacro == null)
            {
                MessageBox.Show("No macro windows are open, cannot save.", "No Data Windows", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            else if (false)
            {
                MessageBox.Show("Macro window contains no data.", "Empty Macro", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            else
            {
                const string macroName = "test.sh3";
                //saveFileDialog.FileName = activeMacro.nameTextBox.Text + ".sh3";
                dialogCancel = true;
                var result = saveFileDialog.ShowDialog(this);
                if (dialogCancel)
                    return;
                var fileName = saveFileDialog.FileName;
                if (fileName == null || fileName.Trim() == "")
                    return;
                statusLabel.Text = $"Saving {fileName}...";
                //string[] commandList = new string[activeMacro.macroListView.Items.Count];
                //string[] argList = new string[activeMacro.macroListView.Items.Count];
                //int index = 0;
                //foreach (ListViewItem listViewItem in activeMacro.macroListView.Items)
                //{
                //    string[] strArray = listViewItem.Tag.ToString().Split('|');
                //    commandList[index] = strArray[0];
                //    argList[index] = strArray[1];
                //    ++index;
                //}
                //new MacroWriter().SaveData(commandList, argList, macroName, fileName);
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
            foreach (var mdiChild in MdiChildren)
            {
                mdiChild.WindowState = FormWindowState.Minimized;
            }
        }


        private void CloseAllWindowsMenu_Click(object sender, EventArgs e)
        {
            foreach (var mdiChild in MdiChildren)
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

            var parameters = activeMacro.ShowArgumentsForm(selectedCommand);
            if (parameters != null)
            {
                activeMacro.AddMacroCommand(selectedCommand, parameters);
            }
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WM_HOTKEY)
            {
                return;
            }

            HotkeyAction((int)m.WParam);
        }

        private void HotkeyAction(int hotkeyId)
        {
            foreach (var mdiChild in MdiChildren)
            {
                if (mdiChild is MacroForm macroForm)
                {
                    //if (macroForm.hotkey.hotkeyId == hotkeyID)
                    //{
                    //    if (macroForm.MacroRunning)
                    //    {
                    //        macroForm.StopButton();
                    //        break;
                    //    }
                    //    macroForm.PlayButton();
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