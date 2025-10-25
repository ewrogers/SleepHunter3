using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MainForm : Form
    {
        private IContainer components = null;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newMacroMenu;
        private ToolStripMenuItem openMacroMenu;
        private ToolStripMenuItem saveMacroMenu;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem statusWindowMenu;
        private ToolStripMenuItem processManagerMenu;
        private ToolStripMenuItem optionsMenu;
        private ToolStripMenuItem windowMenu;
        private ToolStripMenuItem cascadeMenu;
        private ToolStripMenuItem tileVerticalMenu;
        private ToolStripMenuItem tileHorizontalMenu;
        private ToolStripMenuItem minimizeAllMenu;
        private ToolStripMenuItem closeAllMenu;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem searchMenu;
        private ToolStripMenuItem docsMenu;
        private ToolStripMenuItem aboutMenu;
        private StatusStrip mainStatusStrip;
        private ToolStripStatusLabel statusLabel;
        private Panel commandsPanel;
        private TreeView commandsTreeView;
        private ImageList nodeImageList;
        private Timer doubleClickTimer;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator fileMenuSeparator;
            System.Windows.Forms.ToolStripSeparator toolsMenuSeparator;
            System.Windows.Forms.ToolStripSeparator windowMenuSeparator;
            System.Windows.Forms.ToolStripSeparator mdiSeparator;
            System.Windows.Forms.ToolStripSeparator helpMenuSeparator;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.docsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.commandsPanel = new System.Windows.Forms.Panel();
            this.commandsTreeView = new System.Windows.Forms.TreeView();
            this.nodeImageList = new System.Windows.Forms.ImageList(this.components);
            this.doubleClickTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            toolsMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            windowMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            mdiSeparator = new System.Windows.Forms.ToolStripSeparator();
            helpMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.commandsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileMenuSeparator
            // 
            fileMenuSeparator.Name = "fileMenuSeparator";
            fileMenuSeparator.Size = new System.Drawing.Size(195, 6);
            // 
            // toolsMenuSeparator
            // 
            toolsMenuSeparator.Name = "toolsMenuSeparator";
            toolsMenuSeparator.Size = new System.Drawing.Size(219, 6);
            // 
            // windowMenuSeparator
            // 
            windowMenuSeparator.Name = "windowMenuSeparator";
            windowMenuSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // mdiSeparator
            // 
            mdiSeparator.Name = "mdiSeparator";
            mdiSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // helpMenuSeparator
            // 
            helpMenuSeparator.Name = "helpMenuSeparator";
            helpMenuSeparator.Size = new System.Drawing.Size(211, 6);
            helpMenuSeparator.Visible = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.windowMenu,
            this.helpMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.MdiWindowListItem = this.windowMenu;
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mainMenuStrip.ShowItemToolTips = true;
            this.mainMenuStrip.Size = new System.Drawing.Size(1008, 27);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMacroMenu,
            this.openMacroMenu,
            this.saveMacroMenu,
            fileMenuSeparator,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(39, 21);
            this.fileMenu.Text = "&File";
            // 
            // newMacroMenu
            // 
            this.newMacroMenu.Image = ((System.Drawing.Image)(resources.GetObject("newMacroMenu.Image")));
            this.newMacroMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newMacroMenu.Name = "newMacroMenu";
            this.newMacroMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMacroMenu.Size = new System.Drawing.Size(198, 22);
            this.newMacroMenu.Text = "&New Macro";
            this.newMacroMenu.Click += new System.EventHandler(this.NewMacroMenu_Click);
            // 
            // openMacroMenu
            // 
            this.openMacroMenu.Image = ((System.Drawing.Image)(resources.GetObject("openMacroMenu.Image")));
            this.openMacroMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openMacroMenu.Name = "openMacroMenu";
            this.openMacroMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMacroMenu.Size = new System.Drawing.Size(198, 22);
            this.openMacroMenu.Text = "&Open Macro";
            this.openMacroMenu.Click += new System.EventHandler(this.OpenMacroMenu_Click);
            // 
            // saveMacroMenu
            // 
            this.saveMacroMenu.Image = ((System.Drawing.Image)(resources.GetObject("saveMacroMenu.Image")));
            this.saveMacroMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveMacroMenu.Name = "saveMacroMenu";
            this.saveMacroMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMacroMenu.Size = new System.Drawing.Size(198, 22);
            this.saveMacroMenu.Text = "&Save Macro";
            this.saveMacroMenu.Click += new System.EventHandler(this.SaveMacroMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Image = ((System.Drawing.Image)(resources.GetObject("exitMenu.Image")));
            this.exitMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitMenu.Size = new System.Drawing.Size(198, 22);
            this.exitMenu.Text = "E&xit Program";
            this.exitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusWindowMenu,
            this.processManagerMenu,
            toolsMenuSeparator,
            this.optionsMenu});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(51, 21);
            this.toolsMenu.Text = "&Tools";
            // 
            // statusWindowMenu
            // 
            this.statusWindowMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusWindowMenu.Image = ((System.Drawing.Image)(resources.GetObject("statusWindowMenu.Image")));
            this.statusWindowMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusWindowMenu.Name = "statusWindowMenu";
            this.statusWindowMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.statusWindowMenu.Size = new System.Drawing.Size(222, 22);
            this.statusWindowMenu.Text = "S&tatus Window";
            this.statusWindowMenu.Click += new System.EventHandler(this.StatusWindowMenu_Click);
            // 
            // processManagerMenu
            // 
            this.processManagerMenu.Image = ((System.Drawing.Image)(resources.GetObject("processManagerMenu.Image")));
            this.processManagerMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.processManagerMenu.Name = "processManagerMenu";
            this.processManagerMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.processManagerMenu.Size = new System.Drawing.Size(222, 22);
            this.processManagerMenu.Text = "&Process Manager";
            this.processManagerMenu.Click += new System.EventHandler(this.ProcessManagerMenu_Click);
            // 
            // optionsMenu
            // 
            this.optionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("optionsMenu.Image")));
            this.optionsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.ShortcutKeyDisplayString = "";
            this.optionsMenu.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.optionsMenu.Size = new System.Drawing.Size(222, 22);
            this.optionsMenu.Text = "&Options...";
            this.optionsMenu.Click += new System.EventHandler(this.OptionsWindowMenu_Click);
            // 
            // windowMenu
            // 
            this.windowMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeMenu,
            this.tileVerticalMenu,
            this.tileHorizontalMenu,
            windowMenuSeparator,
            this.minimizeAllMenu,
            this.closeAllMenu,
            mdiSeparator});
            this.windowMenu.Name = "windowMenu";
            this.windowMenu.Size = new System.Drawing.Size(67, 21);
            this.windowMenu.Text = "&Window";
            // 
            // cascadeMenu
            // 
            this.cascadeMenu.Name = "cascadeMenu";
            this.cascadeMenu.Size = new System.Drawing.Size(226, 22);
            this.cascadeMenu.Text = "Cascade Windows";
            this.cascadeMenu.Click += new System.EventHandler(this.CascadeWindowsMenu_Click);
            // 
            // tileVerticalMenu
            // 
            this.tileVerticalMenu.Name = "tileVerticalMenu";
            this.tileVerticalMenu.Size = new System.Drawing.Size(226, 22);
            this.tileVerticalMenu.Text = "Tile Windows Vertically";
            this.tileVerticalMenu.Click += new System.EventHandler(this.TileVerticalMenu_Click);
            // 
            // tileHorizontalMenu
            // 
            this.tileHorizontalMenu.Name = "tileHorizontalMenu";
            this.tileHorizontalMenu.Size = new System.Drawing.Size(226, 22);
            this.tileHorizontalMenu.Text = "Tile Windows Horizontally";
            this.tileHorizontalMenu.Click += new System.EventHandler(this.TileHorizontalMenu_Click);
            // 
            // minimizeAllMenu
            // 
            this.minimizeAllMenu.Name = "minimizeAllMenu";
            this.minimizeAllMenu.Size = new System.Drawing.Size(226, 22);
            this.minimizeAllMenu.Text = "&Minimize All";
            this.minimizeAllMenu.Click += new System.EventHandler(this.MinimizeAllMenu_Click);
            // 
            // closeAllMenu
            // 
            this.closeAllMenu.Name = "closeAllMenu";
            this.closeAllMenu.Size = new System.Drawing.Size(226, 22);
            this.closeAllMenu.Text = "C&lose All";
            this.closeAllMenu.Click += new System.EventHandler(this.CloseAllWindowsMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMenu,
            this.docsMenu,
            helpMenuSeparator,
            this.aboutMenu});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(47, 21);
            this.helpMenu.Text = "&Help";
            // 
            // searchMenu
            // 
            this.searchMenu.Enabled = false;
            this.searchMenu.Image = ((System.Drawing.Image)(resources.GetObject("searchMenu.Image")));
            this.searchMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.searchMenu.Size = new System.Drawing.Size(214, 22);
            this.searchMenu.Text = "S&earch...";
            this.searchMenu.Visible = false;
            // 
            // docsMenu
            // 
            this.docsMenu.Enabled = false;
            this.docsMenu.Image = ((System.Drawing.Image)(resources.GetObject("docsMenu.Image")));
            this.docsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.docsMenu.Name = "docsMenu";
            this.docsMenu.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.docsMenu.Size = new System.Drawing.Size(214, 22);
            this.docsMenu.Text = "&Documentation...";
            this.docsMenu.Visible = false;
            // 
            // aboutMenu
            // 
            this.aboutMenu.Image = ((System.Drawing.Image)(resources.GetObject("aboutMenu.Image")));
            this.aboutMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.aboutMenu.Size = new System.Drawing.Size(214, 22);
            this.aboutMenu.Text = "&About SleepHunter";
            this.aboutMenu.Click += new System.EventHandler(this.AboutMenu_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SleepHunter";
            this.notifyIcon.Visible = true;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.versionLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 617);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1008, 24);
            this.mainStatusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(1);
            this.statusLabel.Size = new System.Drawing.Size(919, 19);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commandsPanel
            // 
            this.commandsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.commandsPanel.Controls.Add(this.commandsTreeView);
            this.commandsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.commandsPanel.Location = new System.Drawing.Point(0, 27);
            this.commandsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.commandsPanel.Name = "commandsPanel";
            this.commandsPanel.Size = new System.Drawing.Size(303, 590);
            this.commandsPanel.TabIndex = 1;
            // 
            // commandsTreeView
            // 
            this.commandsTreeView.AllowDrop = true;
            this.commandsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsTreeView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandsTreeView.ImageIndex = 0;
            this.commandsTreeView.ImageList = this.nodeImageList;
            this.commandsTreeView.Location = new System.Drawing.Point(0, 0);
            this.commandsTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.commandsTreeView.Name = "commandsTreeView";
            this.commandsTreeView.SelectedImageIndex = 0;
            this.commandsTreeView.ShowNodeToolTips = true;
            this.commandsTreeView.Size = new System.Drawing.Size(299, 586);
            this.commandsTreeView.Sorted = true;
            this.commandsTreeView.TabIndex = 0;
            this.commandsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CommandsTreeView_ItemDrag);
            this.commandsTreeView.DoubleClick += new System.EventHandler(this.CommandsTreeView_DoubleClick);
            // 
            // nodeImageList
            // 
            this.nodeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("nodeImageList.ImageStream")));
            this.nodeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.nodeImageList.Images.SetKeyName(0, "class_library.ico");
            this.nodeImageList.Images.SetKeyName(1, "class_method.ico");
            // 
            // doubleClickTimer
            // 
            this.doubleClickTimer.Enabled = true;
            this.doubleClickTimer.Interval = 2000;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sh3";
            this.openFileDialog.Filter = "SleepHunter v3 Macro Files (*.sh3, *.sh3x)|*.sh3;*.sh3x";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Open Macro";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sh3";
            this.saveFileDialog.Filter = "SleepHunter v3 Macro Files (*.sh3x)|*.sh3x";
            this.saveFileDialog.Title = "Save Macro";
            // 
            // versionLabel
            // 
            this.versionLabel.Enabled = false;
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(41, 19);
            this.versionLabel.Text = "v3.1.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.commandsPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SleepHunter";
            this.Load += new System.EventHandler(this.form_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.commandsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private NotifyIcon notifyIcon;
        private ToolStripStatusLabel versionLabel;
    }
}
