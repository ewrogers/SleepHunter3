using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Macro.Commands;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SleepHunter.Macro.Serialization;

namespace SleepHunter.Forms
{
    public partial class MainForm
    {
        private const int WM_HOTKEY = 0x312;

        private readonly IServiceProvider serviceProvider;
        private readonly IMacroCommandRegistry commandRegistry;
        private readonly IMacroSerializer serializer;
        
        private ProcessesForm processWindow;
        private MacroForm activeMacro;

        public MainForm(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            commandRegistry = serviceProvider.GetService<IMacroCommandRegistry>();
            serializer = serviceProvider.GetService<IMacroSerializer>();
            
            processWindow = this.serviceProvider.GetRequiredService<ProcessesForm>();

            InitializeComponent();
            UpdateMenuState();
        }

        private void UpdateMenuState()
        {
            saveMacroMenu.Enabled = activeMacro?.IsDisposed == false;
        }

        private void MdiChild_Activate(object sender, EventArgs e)
        {
            if (!(ActiveMdiChild is MacroForm macroForm))
                return;

            activeMacro = macroForm;
            UpdateMenuState();
        }

        #region File Menu Actions
        private void NewMacroMenu_Click(object sender, EventArgs e)
        {
            var macroForm = serviceProvider.GetRequiredService<MacroForm>();
            macroForm.MdiParent = this;
            macroForm.FormClosed += macroForm_Closed;
            macroForm.Show();
        }

        private void OpenMacroMenu_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        private void SaveMacroMenu_Click(object sender, EventArgs e)
        {
            if (activeMacro == null)
            {
                return;
            }

            SaveMacroDocument(activeMacro.GetMacroDocument());
        }

        private void SetStatusText(string text)
        {
            statusLabel.Text = text;
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
            }
            else
            {
                processWindow.MdiParent = this;
            }
            
            processWindow.Show();
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
            var selectedNode = commandsTreeView.SelectedNode;
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
        
        private void macroForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (sender is MacroForm macroForm)
            {
                macroForm.FormClosed -= macroForm_Closed;
                activeMacro = null;
            }

            UpdateMenuState();
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