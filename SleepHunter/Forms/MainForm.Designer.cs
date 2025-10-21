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
        private ToolStripSeparator fileMenuSeparator;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem statusWindowMenu;
        private ToolStripMenuItem processManagerMenu;
        private ToolStripMenuItem optionsMenu;
        private ToolStripMenuItem windowMenu;
        private ToolStripMenuItem cascadeMenu;
        private ToolStripMenuItem tileVerticalMenu;
        private ToolStripMenuItem tileHorizontalMenu;
        private ToolStripSeparator windowMenuSeparator;
        private ToolStripMenuItem minimizeAllMenu;
        private ToolStripMenuItem closeAllMenu;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem searchMenu;
        private ToolStripMenuItem docsMenu;
        private ToolStripSeparator helpMenuSeparator;
        private ToolStripMenuItem aboutMenu;
        internal NotifyIcon notifyIcon;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Character Status Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chat Dialog Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Inventory Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Medenia Skill Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Medenia Spell Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Temuair Skill Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Temuair Spell Pane", 1, 1);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Game-Specific Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Send Keystrokes", 1, 1);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Keyboard Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("If HP < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("If HP = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("If HP ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("If HP > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("While HP < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("While HP = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("While HP ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("While HP > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("HP Conditionals", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("If X Coord < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("If X Coord = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("If X Coord ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("If X Coord > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("While X Coord < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("While X Coord = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("While X Coord ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("While X Coord > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("X Coord. Conditionals", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("If Y Coord < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("If Y Coord = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("If Y Coord ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("If Y Coord > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("While Y Coord < X", 1, 1);
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("While Y Coord = X", 1, 1);
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("While Y Coord ≠ X", 1, 1);
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("While Y Coord > X", 1, 1);
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Y Coord. Conditionals", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Logic Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode28,
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Break", 1, 1);
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("GoTo Line", 1, 1);
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Loop End", 1, 1);
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Loop Reset", 1, 1);
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Loop Restart", 1, 1);
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Loop Start", 1, 1);
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Loop Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Left Click", 1, 1);
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Move Cursor", 1, 1);
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Recall Cursor Position", 1, 1);
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Right Click", 1, 1);
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Save Cursor Position", 1, 1);
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Mouse Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50});
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Wait X Milliseconds", 1, 1);
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Time Library", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode52});
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMacroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.docsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
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
            this.mdiSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.commandsPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.MdiWindowListItem = this.windowMenu;
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.ShowItemToolTips = true;
            this.mainMenuStrip.Size = new System.Drawing.Size(1008, 25);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMacroMenu,
            this.openMacroMenu,
            this.saveMacroMenu,
            this.fileMenuSeparator,
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
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(195, 6);
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
            this.toolsMenuSeparator,
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
            // toolsMenuSeparator
            // 
            this.toolsMenuSeparator.Name = "toolsMenuSeparator";
            this.toolsMenuSeparator.Size = new System.Drawing.Size(219, 6);
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
            this.windowMenuSeparator,
            this.minimizeAllMenu,
            this.closeAllMenu,
            this.mdiSeparator});
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
            // windowMenuSeparator
            // 
            this.windowMenuSeparator.Name = "windowMenuSeparator";
            this.windowMenuSeparator.Size = new System.Drawing.Size(223, 6);
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
            this.helpMenuSeparator,
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
            // helpMenuSeparator
            // 
            this.helpMenuSeparator.Name = "helpMenuSeparator";
            this.helpMenuSeparator.Size = new System.Drawing.Size(211, 6);
            this.helpMenuSeparator.Visible = false;
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
            this.statusLabel});
            this.mainStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 619);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1008, 22);
            this.mainStatusStrip.SizingGrip = false;
            this.mainStatusStrip.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(106, 17);
            this.statusLabel.Text = "SleepHunter v3.1";
            // 
            // commandsPanel
            // 
            this.commandsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.commandsPanel.Controls.Add(this.commandsTreeView);
            this.commandsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.commandsPanel.Location = new System.Drawing.Point(0, 25);
            this.commandsPanel.Name = "commandsPanel";
            this.commandsPanel.Size = new System.Drawing.Size(240, 594);
            this.commandsPanel.TabIndex = 5;
            // 
            // commandsTreeView
            // 
            this.commandsTreeView.AllowDrop = true;
            this.commandsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsTreeView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandsTreeView.ImageIndex = 0;
            this.commandsTreeView.ImageList = this.nodeImageList;
            this.commandsTreeView.Location = new System.Drawing.Point(0, 0);
            this.commandsTreeView.Name = "commandsTreeView";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "Character Status Pane";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Chat Dialog Pane";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "Inventory Pane";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "Medenia Skill Pane";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "Medenia Spell Pane";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "Temuair Skill Pane";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Text = "Temuair Spell Pane";
            treeNode8.ImageIndex = 0;
            treeNode8.Name = "";
            treeNode8.SelectedImageIndex = 0;
            treeNode8.Text = "Game-Specific Library";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Text = "Send Keystrokes";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "";
            treeNode10.SelectedImageIndex = 0;
            treeNode10.Text = "Keyboard Library";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "";
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Text = "If HP < X";
            treeNode12.ImageIndex = 1;
            treeNode12.Name = "";
            treeNode12.SelectedImageIndex = 1;
            treeNode12.Text = "If HP = X";
            treeNode13.ImageIndex = 1;
            treeNode13.Name = "";
            treeNode13.SelectedImageIndex = 1;
            treeNode13.Text = "If HP ≠ X";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "";
            treeNode14.SelectedImageIndex = 1;
            treeNode14.Text = "If HP > X";
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "";
            treeNode15.SelectedImageIndex = 1;
            treeNode15.Text = "While HP < X";
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "";
            treeNode16.SelectedImageIndex = 1;
            treeNode16.Text = "While HP = X";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "";
            treeNode17.SelectedImageIndex = 1;
            treeNode17.Text = "While HP ≠ X";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "";
            treeNode18.SelectedImageIndex = 1;
            treeNode18.Text = "While HP > X";
            treeNode19.ImageIndex = 0;
            treeNode19.Name = "";
            treeNode19.SelectedImageIndex = 0;
            treeNode19.Text = "HP Conditionals";
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "";
            treeNode20.SelectedImageIndex = 1;
            treeNode20.Text = "If X Coord < X";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "";
            treeNode21.SelectedImageIndex = 1;
            treeNode21.Text = "If X Coord = X";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "";
            treeNode22.SelectedImageIndex = 1;
            treeNode22.Text = "If X Coord ≠ X";
            treeNode23.ImageIndex = 1;
            treeNode23.Name = "";
            treeNode23.SelectedImageIndex = 1;
            treeNode23.Text = "If X Coord > X";
            treeNode24.ImageIndex = 1;
            treeNode24.Name = "";
            treeNode24.SelectedImageIndex = 1;
            treeNode24.Text = "While X Coord < X";
            treeNode25.ImageIndex = 1;
            treeNode25.Name = "";
            treeNode25.SelectedImageIndex = 1;
            treeNode25.Text = "While X Coord = X";
            treeNode26.ImageIndex = 1;
            treeNode26.Name = "";
            treeNode26.SelectedImageIndex = 1;
            treeNode26.Text = "While X Coord ≠ X";
            treeNode27.ImageIndex = 1;
            treeNode27.Name = "";
            treeNode27.SelectedImageIndex = 1;
            treeNode27.Text = "While X Coord > X";
            treeNode28.ImageIndex = 0;
            treeNode28.Name = "";
            treeNode28.SelectedImageIndex = 0;
            treeNode28.Text = "X Coord. Conditionals";
            treeNode29.ImageIndex = 1;
            treeNode29.Name = "";
            treeNode29.SelectedImageIndex = 1;
            treeNode29.Text = "If Y Coord < X";
            treeNode30.ImageIndex = 1;
            treeNode30.Name = "";
            treeNode30.SelectedImageIndex = 1;
            treeNode30.Text = "If Y Coord = X";
            treeNode31.ImageIndex = 1;
            treeNode31.Name = "";
            treeNode31.SelectedImageIndex = 1;
            treeNode31.Text = "If Y Coord ≠ X";
            treeNode32.ImageIndex = 1;
            treeNode32.Name = "";
            treeNode32.SelectedImageIndex = 1;
            treeNode32.Text = "If Y Coord > X";
            treeNode33.ImageIndex = 1;
            treeNode33.Name = "";
            treeNode33.SelectedImageIndex = 1;
            treeNode33.Text = "While Y Coord < X";
            treeNode34.ImageIndex = 1;
            treeNode34.Name = "";
            treeNode34.SelectedImageIndex = 1;
            treeNode34.Text = "While Y Coord = X";
            treeNode35.ImageIndex = 1;
            treeNode35.Name = "";
            treeNode35.SelectedImageIndex = 1;
            treeNode35.Text = "While Y Coord ≠ X";
            treeNode36.ImageIndex = 1;
            treeNode36.Name = "";
            treeNode36.SelectedImageIndex = 1;
            treeNode36.Text = "While Y Coord > X";
            treeNode37.ImageIndex = 0;
            treeNode37.Name = "";
            treeNode37.SelectedImageIndex = 0;
            treeNode37.Text = "Y Coord. Conditionals";
            treeNode38.ImageIndex = 0;
            treeNode38.Name = "";
            treeNode38.SelectedImageIndex = 0;
            treeNode38.Text = "Logic Library";
            treeNode39.ImageIndex = 1;
            treeNode39.Name = "";
            treeNode39.SelectedImageIndex = 1;
            treeNode39.Text = "Break";
            treeNode40.ImageIndex = 1;
            treeNode40.Name = "";
            treeNode40.SelectedImageIndex = 1;
            treeNode40.Text = "GoTo Line";
            treeNode41.ImageIndex = 1;
            treeNode41.Name = "";
            treeNode41.SelectedImageIndex = 1;
            treeNode41.Text = "Loop End";
            treeNode42.ImageIndex = 1;
            treeNode42.Name = "";
            treeNode42.SelectedImageIndex = 1;
            treeNode42.Text = "Loop Reset";
            treeNode43.ImageIndex = 1;
            treeNode43.Name = "";
            treeNode43.SelectedImageIndex = 1;
            treeNode43.Text = "Loop Restart";
            treeNode44.ImageIndex = 1;
            treeNode44.Name = "";
            treeNode44.SelectedImageIndex = 1;
            treeNode44.Text = "Loop Start";
            treeNode45.ImageIndex = 0;
            treeNode45.Name = "";
            treeNode45.SelectedImageIndex = 0;
            treeNode45.Text = "Loop Library";
            treeNode46.ImageIndex = 1;
            treeNode46.Name = "";
            treeNode46.SelectedImageIndex = 1;
            treeNode46.Text = "Left Click";
            treeNode47.ImageIndex = 1;
            treeNode47.Name = "";
            treeNode47.SelectedImageIndex = 1;
            treeNode47.Text = "Move Cursor";
            treeNode48.ImageIndex = 1;
            treeNode48.Name = "";
            treeNode48.SelectedImageIndex = 1;
            treeNode48.Text = "Recall Cursor Position";
            treeNode49.ImageIndex = 1;
            treeNode49.Name = "";
            treeNode49.SelectedImageIndex = 1;
            treeNode49.Text = "Right Click";
            treeNode50.ImageIndex = 1;
            treeNode50.Name = "";
            treeNode50.SelectedImageIndex = 1;
            treeNode50.Text = "Save Cursor Position";
            treeNode51.ImageIndex = 0;
            treeNode51.Name = "";
            treeNode51.SelectedImageIndex = 0;
            treeNode51.Text = "Mouse Library";
            treeNode52.ImageIndex = 1;
            treeNode52.Name = "";
            treeNode52.SelectedImageIndex = 1;
            treeNode52.Text = "Wait X Milliseconds";
            treeNode53.ImageIndex = 0;
            treeNode53.Name = "";
            treeNode53.SelectedImageIndex = 0;
            treeNode53.Text = "Time Library";
            this.commandsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode10,
            treeNode38,
            treeNode45,
            treeNode51,
            treeNode53});
            this.commandsTreeView.SelectedImageIndex = 0;
            this.commandsTreeView.ShowNodeToolTips = true;
            this.commandsTreeView.Size = new System.Drawing.Size(236, 590);
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
            this.doubleClickTimer.Tick += new System.EventHandler(this.DoubleClickTimer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sh3";
            this.openFileDialog.Filter = "SleepHunter v3 Macro Files (*.sh3)|*.sh3";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Open Macro";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sh3";
            this.saveFileDialog.Filter = "SleepHunter v3 Macro Files (*.sh3)|*.sh3";
            this.saveFileDialog.Title = "Save Macro";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // mdiSeparator
            // 
            this.mdiSeparator.Name = "mdiSeparator";
            this.mdiSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.commandsPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SleepHunter";
            this.MdiChildActivate += new System.EventHandler(this.MdiChild_Activate);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.commandsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStripSeparator toolsMenuSeparator;
        private ToolStripSeparator mdiSeparator;
    }
}
