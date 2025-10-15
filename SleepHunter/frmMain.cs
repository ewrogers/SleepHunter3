using ProcessMemory;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    public partial class frmMain : Form
    {
        private uint[] HandledDupes = new uint[0];
        public frmProcess ProcessWindow = new frmProcess();
        public frmMacro ActiveMacro = (frmMacro)null;
        private bool DialogCancel = true;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
            TreeNode treeNode1 = new TreeNode("Character Status Pane", 1, 1);
            TreeNode treeNode2 = new TreeNode("Chat Dialog Pane", 1, 1);
            TreeNode treeNode3 = new TreeNode("Inventory Pane", 1, 1);
            TreeNode treeNode4 = new TreeNode("Medenia Skill Pane", 1, 1);
            TreeNode treeNode5 = new TreeNode("Medenia Spell Pane", 1, 1);
            TreeNode treeNode6 = new TreeNode("Temuair Skill Pane", 1, 1);
            TreeNode treeNode7 = new TreeNode("Temuair Spell Pane", 1, 1);
            TreeNode treeNode8 = new TreeNode("Game-Specific Library", 0, 0, new TreeNode[7]
            {
      treeNode1,
      treeNode2,
      treeNode3,
      treeNode4,
      treeNode5,
      treeNode6,
      treeNode7
            });
            TreeNode treeNode9 = new TreeNode("Send Keystrokes", 1, 1);
            TreeNode treeNode10 = new TreeNode("Keyboard Library", 0, 0, new TreeNode[1]
            {
      treeNode9
            });
            TreeNode treeNode11 = new TreeNode("Break", 1, 1);
            TreeNode treeNode12 = new TreeNode("Else", 1, 1);
            TreeNode treeNode13 = new TreeNode("End If", 1, 1);
            TreeNode treeNode14 = new TreeNode("End While", 1, 1);
            TreeNode treeNode15 = new TreeNode("If HP < X", 1, 1);
            TreeNode treeNode16 = new TreeNode("If HP = X", 1, 1);
            TreeNode treeNode17 = new TreeNode("If HP > X", 1, 1);
            TreeNode treeNode18 = new TreeNode("If HP ≠ X", 1, 1);
            TreeNode treeNode19 = new TreeNode("While HP < X", 1, 1);
            TreeNode treeNode20 = new TreeNode("While HP = X", 1, 1);
            TreeNode treeNode21 = new TreeNode("While HP > X", 1, 1);
            TreeNode treeNode22 = new TreeNode("While HP ≠ X", 1, 1);
            TreeNode treeNode23 = new TreeNode("HP Conditionals", 0, 0, new TreeNode[8]
            {
      treeNode15,
      treeNode16,
      treeNode17,
      treeNode18,
      treeNode19,
      treeNode20,
      treeNode21,
      treeNode22
            });
            TreeNode treeNode24 = new TreeNode("If MAP < X", 1, 1);
            TreeNode treeNode25 = new TreeNode("If MAP = X", 1, 1);
            TreeNode treeNode26 = new TreeNode("If MAP > X", 1, 1);
            TreeNode treeNode27 = new TreeNode("If MAP ≠ X", 1, 1);
            TreeNode treeNode28 = new TreeNode("While MAP < X", 1, 1);
            TreeNode treeNode29 = new TreeNode("While MAP = X", 1, 1);
            TreeNode treeNode30 = new TreeNode("While MAP > X", 1, 1);
            TreeNode treeNode31 = new TreeNode("While MAP ≠ X", 1, 1);
            TreeNode treeNode32 = new TreeNode("MAP Conditionals", 0, 0, new TreeNode[8]
            {
      treeNode24,
      treeNode25,
      treeNode26,
      treeNode27,
      treeNode28,
      treeNode29,
      treeNode30,
      treeNode31
            });
            TreeNode treeNode33 = new TreeNode("If MP < X", 1, 1);
            TreeNode treeNode34 = new TreeNode("If MP = X", 1, 1);
            TreeNode treeNode35 = new TreeNode("If MP > X", 1, 1);
            TreeNode treeNode36 = new TreeNode("If MP ≠ X", 1, 1);
            TreeNode treeNode37 = new TreeNode("While MP < X", 1, 1);
            TreeNode treeNode38 = new TreeNode("While MP = X", 1, 1);
            TreeNode treeNode39 = new TreeNode("While MP > X", 1, 1);
            TreeNode treeNode40 = new TreeNode("While MP ≠ X", 1, 1);
            TreeNode treeNode41 = new TreeNode("MP Conditionals", 0, 0, new TreeNode[8]
            {
      treeNode33,
      treeNode34,
      treeNode35,
      treeNode36,
      treeNode37,
      treeNode38,
      treeNode39,
      treeNode40
            });
            TreeNode treeNode42 = new TreeNode("If X Coord < X", 1, 1);
            TreeNode treeNode43 = new TreeNode("If X Coord = X", 1, 1);
            TreeNode treeNode44 = new TreeNode("If X Coord > X", 1, 1);
            TreeNode treeNode45 = new TreeNode("If X Coord ≠ X", 1, 1);
            TreeNode treeNode46 = new TreeNode("While X Coord < X", 1, 1);
            TreeNode treeNode47 = new TreeNode("While X Coord = X", 1, 1);
            TreeNode treeNode48 = new TreeNode("While X Coord > X", 1, 1);
            TreeNode treeNode49 = new TreeNode("While X Coord ≠ X", 1, 1);
            TreeNode treeNode50 = new TreeNode("X Coord. Conditionals", 0, 0, new TreeNode[8]
            {
      treeNode42,
      treeNode43,
      treeNode44,
      treeNode45,
      treeNode46,
      treeNode47,
      treeNode48,
      treeNode49
            });
            TreeNode treeNode51 = new TreeNode("If Y Coord < X", 1, 1);
            TreeNode treeNode52 = new TreeNode("If Y Coord = X", 1, 1);
            TreeNode treeNode53 = new TreeNode("If Y Coord > X", 1, 1);
            TreeNode treeNode54 = new TreeNode("If Y Coord ≠ X", 1, 1);
            TreeNode treeNode55 = new TreeNode("While Y Coord < X", 1, 1);
            TreeNode treeNode56 = new TreeNode("While Y Coord = X", 1, 1);
            TreeNode treeNode57 = new TreeNode("While Y Coord > X", 1, 1);
            TreeNode treeNode58 = new TreeNode("While Y Coord ≠ X", 1, 1);
            TreeNode treeNode59 = new TreeNode("Y Coord. Conditionals", 0, 0, new TreeNode[8]
            {
      treeNode51,
      treeNode52,
      treeNode53,
      treeNode54,
      treeNode55,
      treeNode56,
      treeNode57,
      treeNode58
            });
            TreeNode treeNode60 = new TreeNode("Logic Library", 0, 0, new TreeNode[9]
            {
      treeNode11,
      treeNode12,
      treeNode13,
      treeNode14,
      treeNode23,
      treeNode32,
      treeNode41,
      treeNode50,
      treeNode59
            });
            TreeNode treeNode61 = new TreeNode("Break", 1, 1);
            TreeNode treeNode62 = new TreeNode("GoTo Line", 1, 1);
            TreeNode treeNode63 = new TreeNode("Loop End", 1, 1);
            TreeNode treeNode64 = new TreeNode("Loop Reset", 1, 1);
            TreeNode treeNode65 = new TreeNode("Loop Restart", 1, 1);
            TreeNode treeNode66 = new TreeNode("Loop Start", 1, 1);
            TreeNode treeNode67 = new TreeNode("Loop Library", 0, 0, new TreeNode[6]
            {
      treeNode61,
      treeNode62,
      treeNode63,
      treeNode64,
      treeNode65,
      treeNode66
            });
            TreeNode treeNode68 = new TreeNode("Left Click", 1, 1);
            TreeNode treeNode69 = new TreeNode("Move Cursor", 1, 1);
            TreeNode treeNode70 = new TreeNode("Recall Cursor Position", 1, 1);
            TreeNode treeNode71 = new TreeNode("Right Click", 1, 1);
            TreeNode treeNode72 = new TreeNode("Save Cursor Position", 1, 1);
            TreeNode treeNode73 = new TreeNode("Mouse Library", 0, 0, new TreeNode[5]
            {
      treeNode68,
      treeNode69,
      treeNode70,
      treeNode71,
      treeNode72
            });
            TreeNode treeNode74 = new TreeNode("Wait X Milliseconds", 1, 1);
            TreeNode treeNode75 = new TreeNode("Time Library", 0, 0, new TreeNode[1]
            {
      treeNode74
            });
            this.mnuMain = new MenuStrip();
            this.mnuFile = new ToolStripMenuItem();
            this.mnuNew = new ToolStripMenuItem();
            this.mnuOpen = new ToolStripMenuItem();
            this.mnuSave = new ToolStripMenuItem();
            this.SeperatorA = new ToolStripSeparator();
            this.mnuExit = new ToolStripMenuItem();
            this.mnuTools = new ToolStripMenuItem();
            this.mnuStatus = new ToolStripMenuItem();
            this.mnuAttach = new ToolStripMenuItem();
            this.chatWindowToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.mnuWindow = new ToolStripMenuItem();
            this.mnuCascade = new ToolStripMenuItem();
            this.mnuTileVert = new ToolStripMenuItem();
            this.mnuTileHoriz = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.mnuMinAll = new ToolStripMenuItem();
            this.mnuCloseAll = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.mnuHelp = new ToolStripMenuItem();
            this.mnuSearch = new ToolStripMenuItem();
            this.mnuDocumentation = new ToolStripMenuItem();
            this.SeperatorB = new ToolStripSeparator();
            this.mnuAbout = new ToolStripMenuItem();
            this.nidIcon = new NotifyIcon(this.components);
            this.stbMain = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.pnlCommands = new Panel();
            this.tvwCommands = new TreeView();
            this.ilsNodes = new ImageList(this.components);
            this.tmrDblTargetChk = new Timer(this.components);
            this.dlgOpen = new OpenFileDialog();
            this.dlgSave = new SaveFileDialog();
            this.mnuMain.SuspendLayout();
            this.stbMain.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            this.SuspendLayout();
            this.mnuMain.Items.AddRange(new ToolStripItem[4]
            {
      (ToolStripItem) this.mnuFile,
      (ToolStripItem) this.mnuTools,
      (ToolStripItem) this.mnuWindow,
      (ToolStripItem) this.mnuHelp
            });
            this.mnuMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.mnuWindow;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.ShowItemToolTips = true;
            this.mnuMain.Size = new Size(792, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            this.mnuFile.DropDownItems.AddRange(new ToolStripItem[5]
            {
      (ToolStripItem) this.mnuNew,
      (ToolStripItem) this.mnuOpen,
      (ToolStripItem) this.mnuSave,
      (ToolStripItem) this.SeperatorA,
      (ToolStripItem) this.mnuExit
            });
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new Size(35, 20);
            this.mnuFile.Text = "&File";
            this.mnuNew.Image = (Image)componentResourceManager.GetObject("mnuNew.Image");
            this.mnuNew.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = Keys.N | Keys.Control;
            this.mnuNew.Size = new Size(186, 22);
            this.mnuNew.Text = "&New Macro";
            this.mnuNew.Click += new EventHandler(this.mnuNew_Click);
            this.mnuOpen.Image = (Image)componentResourceManager.GetObject("mnuOpen.Image");
            this.mnuOpen.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = Keys.O | Keys.Control;
            this.mnuOpen.Size = new Size(186, 22);
            this.mnuOpen.Text = "&Open Macro";
            this.mnuOpen.Click += new EventHandler(this.mnuOpen_Click);
            this.mnuSave.Image = (Image)componentResourceManager.GetObject("mnuSave.Image");
            this.mnuSave.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = Keys.S | Keys.Control;
            this.mnuSave.Size = new Size(186, 22);
            this.mnuSave.Text = "&Save Macro";
            this.mnuSave.Click += new EventHandler(this.mnuSave_Click);
            this.SeperatorA.Name = "SeperatorA";
            this.SeperatorA.Size = new Size(183, 6);
            this.mnuExit.Image = (Image)componentResourceManager.GetObject("mnuExit.Image");
            this.mnuExit.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = Keys.Q | Keys.Control;
            this.mnuExit.Size = new Size(186, 22);
            this.mnuExit.Text = "E&xit Program";
            this.mnuExit.Click += new EventHandler(this.mnuExit_Click);
            this.mnuTools.DropDownItems.AddRange(new ToolStripItem[4]
            {
      (ToolStripItem) this.mnuStatus,
      (ToolStripItem) this.mnuAttach,
      (ToolStripItem) this.chatWindowToolStripMenuItem,
      (ToolStripItem) this.optionsToolStripMenuItem
            });
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new Size(44, 20);
            this.mnuTools.Text = "&Tools";
            this.mnuStatus.Image = (Image)componentResourceManager.GetObject("mnuStatus.Image");
            this.mnuStatus.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.ShortcutKeys = Keys.H | Keys.Control;
            this.mnuStatus.Size = new Size(205, 22);
            this.mnuStatus.Text = "S&tatus Window";
            this.mnuStatus.Click += new EventHandler(this.mnuStatus_Click);
            this.mnuAttach.Image = (Image)componentResourceManager.GetObject("mnuAttach.Image");
            this.mnuAttach.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuAttach.Name = "mnuAttach";
            this.mnuAttach.ShortcutKeys = Keys.P | Keys.Control;
            this.mnuAttach.Size = new Size(205, 22);
            this.mnuAttach.Text = "&Process Manager";
            this.mnuAttach.Click += new EventHandler(this.mnuAttach_Click);
            this.chatWindowToolStripMenuItem.Enabled = false;
            this.chatWindowToolStripMenuItem.Image = (Image)componentResourceManager.GetObject("chatWindowToolStripMenuItem.Image");
            this.chatWindowToolStripMenuItem.Name = "chatWindowToolStripMenuItem";
            this.chatWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.chatWindowToolStripMenuItem.ShortcutKeys = Keys.C | Keys.Control;
            this.chatWindowToolStripMenuItem.Size = new Size(205, 22);
            this.chatWindowToolStripMenuItem.Text = "&Chat Window";
            this.chatWindowToolStripMenuItem.Click += new EventHandler(this.chatWindowToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Image = (Image)componentResourceManager.GetObject("optionsToolStripMenuItem.Image");
            this.optionsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.optionsToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
            this.optionsToolStripMenuItem.Size = new Size(205, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Visible = false;
            this.optionsToolStripMenuItem.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
            this.mnuWindow.DropDownItems.AddRange(new ToolStripItem[7]
            {
      (ToolStripItem) this.mnuCascade,
      (ToolStripItem) this.mnuTileVert,
      (ToolStripItem) this.mnuTileHoriz,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.mnuMinAll,
      (ToolStripItem) this.mnuCloseAll,
      (ToolStripItem) this.toolStripSeparator1
            });
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new Size(57, 20);
            this.mnuWindow.Text = "&Window";
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new Size(206, 22);
            this.mnuCascade.Text = "Cascade Windows";
            this.mnuCascade.Click += new EventHandler(this.mnuCascade_Click);
            this.mnuTileVert.Name = "mnuTileVert";
            this.mnuTileVert.Size = new Size(206, 22);
            this.mnuTileVert.Text = "Tile Windows Vertically";
            this.mnuTileVert.Click += new EventHandler(this.mnuTileVert_Click);
            this.mnuTileHoriz.Name = "mnuTileHoriz";
            this.mnuTileHoriz.Size = new Size(206, 22);
            this.mnuTileHoriz.Text = "Tile Windows Horizontally";
            this.mnuTileHoriz.Click += new EventHandler(this.mnuTileHoriz_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(203, 6);
            this.mnuMinAll.Name = "mnuMinAll";
            this.mnuMinAll.Size = new Size(206, 22);
            this.mnuMinAll.Text = "&Minimize All";
            this.mnuMinAll.Click += new EventHandler(this.mnuMinAll_Click);
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new Size(206, 22);
            this.mnuCloseAll.Text = "C&lose All";
            this.mnuCloseAll.Click += new EventHandler(this.mnuCloseAll_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(203, 6);
            this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[4]
            {
      (ToolStripItem) this.mnuSearch,
      (ToolStripItem) this.mnuDocumentation,
      (ToolStripItem) this.SeperatorB,
      (ToolStripItem) this.mnuAbout
            });
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new Size(40, 20);
            this.mnuHelp.Text = "&Help";
            this.mnuSearch.Enabled = false;
            this.mnuSearch.Image = (Image)componentResourceManager.GetObject("mnuSearch.Image");
            this.mnuSearch.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.ShortcutKeys = Keys.F3;
            this.mnuSearch.Size = new Size(188, 22);
            this.mnuSearch.Text = "S&earch...";
            this.mnuSearch.Visible = false;
            this.mnuDocumentation.Enabled = false;
            this.mnuDocumentation.Image = (Image)componentResourceManager.GetObject("mnuDocumentation.Image");
            this.mnuDocumentation.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuDocumentation.Name = "mnuDocumentation";
            this.mnuDocumentation.ShortcutKeys = Keys.F1;
            this.mnuDocumentation.Size = new Size(188, 22);
            this.mnuDocumentation.Text = "&Documentation...";
            this.mnuDocumentation.Visible = false;
            this.SeperatorB.Name = "SeperatorB";
            this.SeperatorB.Size = new Size(185, 6);
            this.SeperatorB.Visible = false;
            this.mnuAbout.Image = (Image)componentResourceManager.GetObject("mnuAbout.Image");
            this.mnuAbout.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new Size(188, 22);
            this.mnuAbout.Text = "A&bout SleepHunter...";
            this.mnuAbout.Click += new EventHandler(this.mnuAbout_Click);
            this.nidIcon.Icon = (Icon)componentResourceManager.GetObject("nidIcon.Icon");
            this.nidIcon.Text = "SleepHunter v3.0a";
            this.nidIcon.Visible = true;
            this.stbMain.Items.AddRange(new ToolStripItem[1]
            {
      (ToolStripItem) this.lblStatus
            });
            this.stbMain.Location = new Point(0, 551);
            this.stbMain.Name = "stbMain";
            this.stbMain.Size = new Size(792, 22);
            this.stbMain.TabIndex = 4;
            this.stbMain.Text = "statusStrip1";
            this.lblStatus.BorderSides = ToolStripStatusLabelBorderSides.All;
            this.lblStatus.BorderStyle = Border3DStyle.SunkenOuter;
            this.lblStatus.Margin = new Padding(1, 1, 1, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new Padding(1);
            this.lblStatus.Size = new Size(775, 21);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Idle.";
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.pnlCommands.Controls.Add((Control)this.tvwCommands);
            this.pnlCommands.Dock = DockStyle.Left;
            this.pnlCommands.Location = new Point(0, 24);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Padding = new Padding(4);
            this.pnlCommands.Size = new Size(200, 527);
            this.pnlCommands.TabIndex = 5;
            this.tvwCommands.AllowDrop = true;
            this.tvwCommands.Dock = DockStyle.Left;
            this.tvwCommands.FullRowSelect = true;
            this.tvwCommands.ImageIndex = 0;
            this.tvwCommands.ImageList = this.ilsNodes;
            this.tvwCommands.LineColor = Color.DarkGray;
            this.tvwCommands.Location = new Point(4, 4);
            this.tvwCommands.Name = "tvwCommands";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node81";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Tag = (object)"GS_STATUS";
            treeNode1.Text = "Character Status Pane";
            treeNode1.ToolTipText = "Switch to Character Status Pane";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Node80";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Tag = (object)"GS_CHAT";
            treeNode2.Text = "Chat Dialog Pane";
            treeNode2.ToolTipText = "Switch to Chat Dialog Pane";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "Node75";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Tag = (object)"GS_INVENTORY";
            treeNode3.Text = "Inventory Pane";
            treeNode3.ToolTipText = "Switch to Inventory Pane";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node77";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Tag = (object)"GS_MEDSKILL";
            treeNode4.Text = "Medenia Skill Pane";
            treeNode4.ToolTipText = "Switch to Medenia Skill Pane";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "Node79";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Tag = (object)"GS_MEDSPELL";
            treeNode5.Text = "Medenia Spell Pane";
            treeNode5.ToolTipText = "Switch to Medenia Spell Pane";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "Node76";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Tag = (object)"GS_TEMSKILL";
            treeNode6.Text = "Temuair Skill Pane";
            treeNode6.ToolTipText = "Switch to Temuair Skill Pane";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "Node78";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Tag = (object)"GS_TEMSPELL";
            treeNode7.Text = "Temuair Spell Pane";
            treeNode7.ToolTipText = "Switch to Temuair Spell Pane";
            treeNode8.ImageIndex = 0;
            treeNode8.Name = "Node74";
            treeNode8.SelectedImageIndex = 0;
            treeNode8.Text = "Game-Specific Library";
            treeNode8.ToolTipText = "Provides pre-built macros to switch between diffrent panels within DA (Ex. Chat, Inventory)";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "Node2";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Tag = (object)"KB_SENDKEYS";
            treeNode9.Text = "Send Keystrokes";
            treeNode9.ToolTipText = "Provides pre-built macro to send keys to DA process";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "Node0";
            treeNode10.NodeFont = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            treeNode10.SelectedImageIndex = 0;
            treeNode10.Text = "Keyboard Library";
            treeNode10.ToolTipText = "Provides pre-built keyboard macros";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node72";
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Tag = (object)"LO_BREAK";
            treeNode11.Text = "Break";
            treeNode11.ToolTipText = "Escape a loop or condition";
            treeNode12.ImageIndex = 1;
            treeNode12.Name = "Node73";
            treeNode12.SelectedImageIndex = 1;
            treeNode12.Tag = (object)"LO_ELSE";
            treeNode12.Text = "Else";
            treeNode12.ToolTipText = "Used when partnered IF is false";
            treeNode13.ImageIndex = 1;
            treeNode13.Name = "Node71";
            treeNode13.SelectedImageIndex = 1;
            treeNode13.Tag = (object)"LO_ENDIF";
            treeNode13.Text = "End If";
            treeNode13.ToolTipText = "Signals the end of the IF conditional";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "Node0";
            treeNode14.SelectedImageIndex = 1;
            treeNode14.Tag = (object)"LO_ENDWHILE";
            treeNode14.Text = "End While";
            treeNode14.ToolTipText = "Provides the end of the WHILE loop conditional";
            treeNode15.ImageIndex = 1;
            treeNode15.Name = "Node32";
            treeNode15.SelectedImageIndex = 1;
            treeNode15.Tag = (object)"LO_IFHPL";
            treeNode15.Text = "If HP < X";
            treeNode15.ToolTipText = "Evalutes HP against given value; Returns true/false";
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "Node33";
            treeNode16.SelectedImageIndex = 1;
            treeNode16.Tag = (object)"LO_IFHPE";
            treeNode16.Text = "If HP = X";
            treeNode16.ToolTipText = "Evalutates HP against given value; Returns true/false";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "Node31";
            treeNode17.SelectedImageIndex = 1;
            treeNode17.Tag = (object)"LO_IFHPG";
            treeNode17.Text = "If HP > X";
            treeNode17.ToolTipText = "Evalutates HP against given value; Returns true/false";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "Node34";
            treeNode18.SelectedImageIndex = 1;
            treeNode18.Tag = (object)"LO_IFHPN";
            treeNode18.Text = "If HP ≠ X";
            treeNode18.ToolTipText = "Evalutates HP against given value; Returns true/false";
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "Node52";
            treeNode19.SelectedImageIndex = 1;
            treeNode19.Tag = (object)"LO_WHILEHPL";
            treeNode19.Text = "While HP < X";
            treeNode19.ToolTipText = "Loop conditional for HP; Runs until given value meets conditional";
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "Node53";
            treeNode20.SelectedImageIndex = 1;
            treeNode20.Tag = (object)"LO_WHILEHPE";
            treeNode20.Text = "While HP = X";
            treeNode20.ToolTipText = "Loop conditional for HP; Runs until given value meets conditional";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "Node51";
            treeNode21.SelectedImageIndex = 1;
            treeNode21.Tag = (object)"LO_WHILEHPG";
            treeNode21.Text = "While HP > X";
            treeNode21.ToolTipText = "Loop conditional for HP; Runs until given value meets conditional";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "Node54";
            treeNode22.SelectedImageIndex = 1;
            treeNode22.Tag = (object)"LO_WHILEHPN";
            treeNode22.Text = "While HP ≠ X";
            treeNode22.ToolTipText = "Loop conditional for HP; Runs until given value meets conditional";
            treeNode23.ImageIndex = 0;
            treeNode23.Name = "Node19";
            treeNode23.SelectedImageIndex = 0;
            treeNode23.Text = "HP Conditionals";
            treeNode23.ToolTipText = "Provides logic and loop operators for HP";
            treeNode24.ImageIndex = 1;
            treeNode24.Name = "Node40";
            treeNode24.SelectedImageIndex = 1;
            treeNode24.Tag = (object)"LO_IFMAPL";
            treeNode24.Text = "If MAP < X";
            treeNode25.ImageIndex = 1;
            treeNode25.Name = "Node41";
            treeNode25.SelectedImageIndex = 1;
            treeNode25.Tag = (object)"LO_IFMAPE";
            treeNode25.Text = "If MAP = X";
            treeNode26.ImageIndex = 1;
            treeNode26.Name = "Node39";
            treeNode26.SelectedImageIndex = 1;
            treeNode26.Tag = (object)"LO_IFMAPG";
            treeNode26.Text = "If MAP > X";
            treeNode27.ImageIndex = 1;
            treeNode27.Name = "Node42";
            treeNode27.SelectedImageIndex = 1;
            treeNode27.Tag = (object)"LO_IFMAPN";
            treeNode27.Text = "If MAP ≠ X";
            treeNode28.ImageIndex = 1;
            treeNode28.Name = "Node60";
            treeNode28.SelectedImageIndex = 1;
            treeNode28.Tag = (object)"LO_WHILEMAPL";
            treeNode28.Text = "While MAP < X";
            treeNode29.ImageIndex = 1;
            treeNode29.Name = "Node61";
            treeNode29.SelectedImageIndex = 1;
            treeNode29.Tag = (object)"LO_WHILEMAPE";
            treeNode29.Text = "While MAP = X";
            treeNode30.ImageIndex = 1;
            treeNode30.Name = "Node59";
            treeNode30.SelectedImageIndex = 1;
            treeNode30.Tag = (object)"LO_WHILEMAPG";
            treeNode30.Text = "While MAP > X";
            treeNode31.ImageIndex = 1;
            treeNode31.Name = "Node62";
            treeNode31.SelectedImageIndex = 1;
            treeNode31.Tag = (object)"LO_WHILEMAPN";
            treeNode31.Text = "While MAP ≠ X";
            treeNode32.ImageIndex = 0;
            treeNode32.Name = "Node21";
            treeNode32.SelectedImageIndex = 0;
            treeNode32.Text = "MAP Conditionals";
            treeNode33.ImageIndex = 1;
            treeNode33.Name = "Node35";
            treeNode33.SelectedImageIndex = 1;
            treeNode33.Tag = (object)"LO_IFMPL";
            treeNode33.Text = "If MP < X";
            treeNode34.ImageIndex = 1;
            treeNode34.Name = "Node37";
            treeNode34.SelectedImageIndex = 1;
            treeNode34.Tag = (object)"LO_IFMPE";
            treeNode34.Text = "If MP = X";
            treeNode35.ImageIndex = 1;
            treeNode35.Name = "Node36";
            treeNode35.SelectedImageIndex = 1;
            treeNode35.Tag = (object)"LO_IFMPG";
            treeNode35.Text = "If MP > X";
            treeNode36.ImageIndex = 1;
            treeNode36.Name = "Node38";
            treeNode36.SelectedImageIndex = 1;
            treeNode36.Tag = (object)"LO_IFMPN";
            treeNode36.Text = "If MP ≠ X";
            treeNode37.ImageIndex = 1;
            treeNode37.Name = "Node56";
            treeNode37.SelectedImageIndex = 1;
            treeNode37.Tag = (object)"LO_WHILEMPL";
            treeNode37.Text = "While MP < X";
            treeNode38.ImageIndex = 1;
            treeNode38.Name = "Node57";
            treeNode38.SelectedImageIndex = 1;
            treeNode38.Tag = (object)"LO_WHILEMPE";
            treeNode38.Text = "While MP = X";
            treeNode39.ImageIndex = 1;
            treeNode39.Name = "Node55";
            treeNode39.SelectedImageIndex = 1;
            treeNode39.Tag = (object)"LO_WHILEMPG";
            treeNode39.Text = "While MP > X";
            treeNode40.ImageIndex = 1;
            treeNode40.Name = "Node58";
            treeNode40.SelectedImageIndex = 1;
            treeNode40.Tag = (object)"LO_WHILEMPN";
            treeNode40.Text = "While MP ≠ X";
            treeNode41.ImageIndex = 0;
            treeNode41.Name = "Node20";
            treeNode41.SelectedImageIndex = 0;
            treeNode41.Text = "MP Conditionals";
            treeNode42.ImageIndex = 1;
            treeNode42.Name = "Node44";
            treeNode42.SelectedImageIndex = 1;
            treeNode42.Tag = (object)"LO_IFXL";
            treeNode42.Text = "If X Coord < X";
            treeNode43.ImageIndex = 1;
            treeNode43.Name = "Node45";
            treeNode43.SelectedImageIndex = 1;
            treeNode43.Tag = (object)"LO_IFXE";
            treeNode43.Text = "If X Coord = X";
            treeNode44.ImageIndex = 1;
            treeNode44.Name = "Node43";
            treeNode44.SelectedImageIndex = 1;
            treeNode44.Tag = (object)"LO_IFXG";
            treeNode44.Text = "If X Coord > X";
            treeNode45.ImageIndex = 1;
            treeNode45.Name = "Node46";
            treeNode45.SelectedImageIndex = 1;
            treeNode45.Tag = (object)"LO_IFXN";
            treeNode45.Text = "If X Coord ≠ X";
            treeNode46.ImageIndex = 1;
            treeNode46.Name = "Node64";
            treeNode46.SelectedImageIndex = 1;
            treeNode46.Tag = (object)"LO_WHILEXL";
            treeNode46.Text = "While X Coord < X";
            treeNode47.ImageIndex = 1;
            treeNode47.Name = "Node65";
            treeNode47.SelectedImageIndex = 1;
            treeNode47.Tag = (object)"LO_WHILEXE";
            treeNode47.Text = "While X Coord = X";
            treeNode48.ImageIndex = 1;
            treeNode48.Name = "Node63";
            treeNode48.SelectedImageIndex = 1;
            treeNode48.Tag = (object)"LO_WHILEXG";
            treeNode48.Text = "While X Coord > X";
            treeNode49.ImageIndex = 1;
            treeNode49.Name = "Node66";
            treeNode49.SelectedImageIndex = 1;
            treeNode49.Tag = (object)"LO_WHILEXN";
            treeNode49.Text = "While X Coord ≠ X";
            treeNode50.ImageIndex = 0;
            treeNode50.Name = "Node27";
            treeNode50.SelectedImageIndex = 0;
            treeNode50.Text = "X Coord. Conditionals";
            treeNode51.ImageIndex = 1;
            treeNode51.Name = "Node48";
            treeNode51.SelectedImageIndex = 1;
            treeNode51.Tag = (object)"LO_IFYL";
            treeNode51.Text = "If Y Coord < X";
            treeNode52.ImageIndex = 1;
            treeNode52.Name = "Node49";
            treeNode52.SelectedImageIndex = 1;
            treeNode52.Tag = (object)"LO_IFYE";
            treeNode52.Text = "If Y Coord = X";
            treeNode53.ImageIndex = 1;
            treeNode53.Name = "Node47";
            treeNode53.SelectedImageIndex = 1;
            treeNode53.Tag = (object)"LO_IFYG";
            treeNode53.Text = "If Y Coord > X";
            treeNode54.ImageIndex = 1;
            treeNode54.Name = "Node50";
            treeNode54.SelectedImageIndex = 1;
            treeNode54.Tag = (object)"LO_IFYN";
            treeNode54.Text = "If Y Coord ≠ X";
            treeNode55.ImageIndex = 1;
            treeNode55.Name = "Node68";
            treeNode55.SelectedImageIndex = 1;
            treeNode55.Tag = (object)"LO_WHILEYL";
            treeNode55.Text = "While Y Coord < X";
            treeNode56.ImageIndex = 1;
            treeNode56.Name = "Node69";
            treeNode56.SelectedImageIndex = 1;
            treeNode56.Tag = (object)"LO_WHILEYE";
            treeNode56.Text = "While Y Coord = X";
            treeNode57.ImageIndex = 1;
            treeNode57.Name = "Node67";
            treeNode57.SelectedImageIndex = 1;
            treeNode57.Tag = (object)"LO_WHILEYG";
            treeNode57.Text = "While Y Coord > X";
            treeNode58.ImageIndex = 1;
            treeNode58.Name = "Node70";
            treeNode58.SelectedImageIndex = 1;
            treeNode58.Tag = (object)"LO_WHILEYN";
            treeNode58.Text = "While Y Coord ≠ X";
            treeNode59.ImageIndex = 0;
            treeNode59.Name = "Node22";
            treeNode59.SelectedImageIndex = 0;
            treeNode59.Text = "Y Coord. Conditionals";
            treeNode60.ImageIndex = 0;
            treeNode60.Name = "Node18";
            treeNode60.SelectedImageIndex = 0;
            treeNode60.Text = "Logic Library";
            treeNode60.ToolTipText = "Provides Conditional Operators";
            treeNode61.ImageIndex = 1;
            treeNode61.Name = "Node16";
            treeNode61.SelectedImageIndex = 1;
            treeNode61.Tag = (object)"LP_BREAK";
            treeNode61.Text = "Break";
            treeNode61.ToolTipText = "Escapes A Loop";
            treeNode62.ImageIndex = 1;
            treeNode62.Name = "Node17";
            treeNode62.SelectedImageIndex = 1;
            treeNode62.Tag = (object)"LP_GOTO";
            treeNode62.Text = "GoTo Line";
            treeNode62.ToolTipText = "Goes Directly To A Given Line";
            treeNode63.ImageIndex = 1;
            treeNode63.Name = "Node13";
            treeNode63.SelectedImageIndex = 1;
            treeNode63.Tag = (object)"LP_END";
            treeNode63.Text = "Loop End";
            treeNode63.ToolTipText = "Signals The End Of A Loop";
            treeNode64.ImageIndex = 1;
            treeNode64.Name = "Node15";
            treeNode64.SelectedImageIndex = 1;
            treeNode64.Tag = (object)"LP_RESET";
            treeNode64.Text = "Loop Reset";
            treeNode64.ToolTipText = "Resets A Loop";
            treeNode65.ImageIndex = 1;
            treeNode65.Name = "Node14";
            treeNode65.SelectedImageIndex = 1;
            treeNode65.Tag = (object)"LP_RESTART";
            treeNode65.Text = "Loop Restart";
            treeNode65.ToolTipText = "Restarts A Loop";
            treeNode66.ImageIndex = 1;
            treeNode66.Name = "Node12";
            treeNode66.SelectedImageIndex = 1;
            treeNode66.Tag = (object)"LP_START";
            treeNode66.Text = "Loop Start";
            treeNode66.ToolTipText = "Signals The Start Of A Loop";
            treeNode67.ImageIndex = 0;
            treeNode67.Name = "Node11";
            treeNode67.SelectedImageIndex = 0;
            treeNode67.Text = "Loop Library";
            treeNode67.ToolTipText = "Provides the ability to create loops on statements to repeat actions multiple times";
            treeNode68.ImageIndex = 1;
            treeNode68.Name = "Node7";
            treeNode68.SelectedImageIndex = 1;
            treeNode68.Tag = (object)"MO_LEFTCLICK";
            treeNode68.Text = "Left Click";
            treeNode68.ToolTipText = "Signals A Left Mouse Click";
            treeNode69.ImageIndex = 1;
            treeNode69.Name = "Node6";
            treeNode69.SelectedImageIndex = 1;
            treeNode69.Tag = (object)"MO_MOVE";
            treeNode69.Text = "Move Cursor";
            treeNode69.ToolTipText = "Moves The Cursor To A Given Position";
            treeNode70.ImageIndex = 1;
            treeNode70.Name = "Node10";
            treeNode70.SelectedImageIndex = 1;
            treeNode70.Tag = (object)"MO_RECALL";
            treeNode70.Text = "Recall Cursor Position";
            treeNode70.ToolTipText = "Recalls The Previous Cursor Position \\n (You Must Call Save Cursor Position First!)";
            treeNode71.ImageIndex = 1;
            treeNode71.Name = "Node8";
            treeNode71.SelectedImageIndex = 1;
            treeNode71.Tag = (object)"MO_RIGHTCLICK";
            treeNode71.Text = "Right Click";
            treeNode71.ToolTipText = "Signals A Right Mouse Click";
            treeNode72.ImageIndex = 1;
            treeNode72.Name = "Node9";
            treeNode72.SelectedImageIndex = 1;
            treeNode72.Tag = (object)"MO_SAVE";
            treeNode72.Text = "Save Cursor Position";
            treeNode72.ToolTipText = "Saves The Current Cursor Position";
            treeNode73.ImageIndex = 0;
            treeNode73.Name = "Node5";
            treeNode73.SelectedImageIndex = 0;
            treeNode73.Text = "Mouse Library";
            treeNode73.ToolTipText = "Provides prebuilt mouse actions";
            treeNode74.ImageIndex = 1;
            treeNode74.Name = "Node83";
            treeNode74.SelectedImageIndex = 1;
            treeNode74.Tag = (object)"TI_WAIT";
            treeNode74.Text = "Wait X Milliseconds";
            treeNode74.ToolTipText = "Used To Pause Macro For Given Milliseconds.";
            treeNode75.ImageIndex = 0;
            treeNode75.Name = "Node82";
            treeNode75.SelectedImageIndex = 0;
            treeNode75.Text = "Time Library";
            treeNode75.ToolTipText = "Provides timers for macros";
            this.tvwCommands.Nodes.AddRange(new TreeNode[6]
            {
      treeNode8,
      treeNode10,
      treeNode60,
      treeNode67,
      treeNode73,
      treeNode75
            });
            this.tvwCommands.SelectedImageIndex = 0;
            this.tvwCommands.ShowNodeToolTips = true;
            this.tvwCommands.Size = new Size(192 /*0xC0*/, 519);
            this.tvwCommands.Sorted = true;
            this.tvwCommands.TabIndex = 0;
            this.tvwCommands.DoubleClick += new EventHandler(this.tvwCommands_DoubleClick);
            this.tvwCommands.ItemDrag += new ItemDragEventHandler(this.tvwCommands_ItemDrag);
            this.ilsNodes.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("ilsNodes.ImageStream");
            this.ilsNodes.TransparentColor = Color.Transparent;
            this.ilsNodes.Images.SetKeyName(0, "class_library.ico");
            this.ilsNodes.Images.SetKeyName(1, "class_method.ico");
            this.tmrDblTargetChk.Enabled = true;
            this.tmrDblTargetChk.Interval = 2000;
            this.tmrDblTargetChk.Tick += new EventHandler(this.tmrDblTargetChk_Tick);
            this.dlgOpen.DefaultExt = "sh3";
            this.dlgOpen.Filter = "SleepHunter v3 Macro Files (*.sh3)|*.sh3";
            this.dlgOpen.Multiselect = true;
            this.dlgOpen.Title = "Open Macro";
            this.dlgOpen.FileOk += new CancelEventHandler(this.dlgOpen_FileOk);
            this.dlgSave.DefaultExt = "sh3";
            this.dlgSave.Filter = "SleepHunter v3 Macro Files (*.sh3)|*.sh3";
            this.dlgSave.Title = "Save Macro";
            this.dlgSave.FileOk += new CancelEventHandler(this.dlgSave_FileOk);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(792, 573);
            this.Controls.Add((Control)this.pnlCommands);
            this.Controls.Add((Control)this.stbMain);
            this.Controls.Add((Control)this.mnuMain);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = nameof(frmMain);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SleepHunter";
            this.MdiChildActivate += new EventHandler(this.frmMain_MdiChildActivate);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stbMain.ResumeLayout(false);
            this.stbMain.PerformLayout();
            this.pnlCommands.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public frmMain() => this.InitializeComponent();

        private void mnuNew_Click(object sender, EventArgs e)
        {
            frmMacro frmMacro = new frmMacro();
            frmMacro.MdiParent = (Form)this;
            frmMacro.Show();
        }

        private void tvwCommands_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treeNode = (TreeNode)e.Item;
            if (treeNode.Parent == null | treeNode.Tag == null)
                return;
            int num = (int)this.DoDragDrop((object)$"{treeNode.Text}|{treeNode.Tag}", DragDropEffects.Copy);
        }

        private void mnuAttach_Click(object sender, EventArgs e)
        {
            if (this.ProcessWindow.IsDisposed)
            {
                this.ProcessWindow = new frmProcess();
                this.ProcessWindow.MdiParent = (Form)this;
                this.ProcessWindow.Location = new Point(0, 0);
                this.ProcessWindow.Width = this.ClientRectangle.Width - this.pnlCommands.ClientRectangle.Width - 4;
                this.ProcessWindow.Show();
            }
            else
            {
                this.ProcessWindow.MdiParent = (Form)this;
                this.ProcessWindow.Show();
            }
        }

        private void mnuStatus_Click(object sender, EventArgs e)
        {
            frmStatus frmStatus = new frmStatus();
            frmStatus.MdiParent = (Form)this;
            frmStatus.Show();
        }

        private void tmrDblTargetChk_Tick(object sender, EventArgs e)
        {
            Form[] mdiChildren = this.MdiChildren;
            uint[] array = new uint[mdiChildren.Length];
            int index1 = 0;
            foreach (Form form in mdiChildren)
            {
                if (form is frmMacro)
                {
                    frmMacro frmMacro = (frmMacro)form;
                    if (frmMacro.memRead != null)
                        array[index1] = frmMacro.memRead.ProcessID;
                }
                ++index1;
            }
            for (int index2 = 0; index2 < array.Length; ++index2)
            {
                if (Array.IndexOf<uint>(array, array[index2]) != Array.LastIndexOf<uint>(array, array[index2]) & array[index2] > 0U && Array.IndexOf<uint>(this.HandledDupes, array[index2]) < 0)
                {
                    this.nidIcon.ShowBalloonTip(2500, "Overloaded Process", $"You have attached two different macros to the same process.{Environment.NewLine}{Environment.NewLine}It is suggested that you correct this unless you are sure the actions of both macros will not interfere with each other.", ToolTipIcon.Warning);
                    uint[] handledDupes = this.HandledDupes;
                    uint[] numArray = new uint[handledDupes.Length + 1];
                    handledDupes.CopyTo((Array)numArray, 0);
                    numArray[numArray.Length - 1] = array[index2];
                    this.HandledDupes = numArray;
                }
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.DialogCancel = true;
            int num = (int)this.dlgOpen.ShowDialog((IWin32Window)this);
            string[] fileNames = this.dlgOpen.FileNames;
            if (fileNames == null | this.DialogCancel)
                return;
            MacroReader macroReader = new MacroReader();
            foreach (string str in fileNames)
            {
                if (str.Trim() != "")
                {
                    string[] commands = macroReader.GetCommands(str.Trim());
                    string[] arguments = macroReader.GetArguments(str.Trim());
                    string fileTitle = macroReader.GetFileTitle(str.Trim());
                    this.lblStatus.Text = $"Opening {str}...";
                    frmMacro frmMacro = new frmMacro();
                    macroReader.AddCommandsToList(frmMacro.lvwMacro, commands, arguments);
                    frmMacro.MdiParent = (Form)this;
                    frmMacro.txtName.Text = fileTitle;
                    frmMacro.ClearNullEntries();
                    frmMacro.ReNumberLines();
                    frmMacro.IndentLines();
                    frmMacro.Show();
                }
            }
            this.lblStatus.Text = "Idle.";
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (this.ActiveMacro == null)
            {
                int num1 = (int)MessageBox.Show("No macro windows are open, cannot save.", "No Data Windows", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.ActiveMacro.lvwMacro.Items.Count < 1)
            {
                int num2 = (int)MessageBox.Show("Macro window contains no data.", "Empty Macro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.dlgSave.FileName = this.ActiveMacro.txtName.Text + ".sh3";
                this.DialogCancel = true;
                int num3 = (int)this.dlgSave.ShowDialog((IWin32Window)this);
                if (this.DialogCancel)
                    return;
                string fileName = this.dlgSave.FileName;
                if (fileName == null || fileName.Trim() == "")
                    return;
                this.lblStatus.Text = $"Saving {fileName}...";
                string[] CommandList = new string[this.ActiveMacro.lvwMacro.Items.Count];
                string[] ArgList = new string[this.ActiveMacro.lvwMacro.Items.Count];
                int index = 0;
                foreach (ListViewItem listViewItem in this.ActiveMacro.lvwMacro.Items)
                {
                    string[] strArray = listViewItem.Tag.ToString().Split('|');
                    CommandList[index] = strArray[0];
                    ArgList[index] = strArray[1];
                    ++index;
                }
                new MacroWriter().SaveData(CommandList, ArgList, this.ActiveMacro.txtName.Text.Trim(), fileName);
                this.lblStatus.Text = "Idle.";
            }
        }

        private void dlgOpen_FileOk(object sender, CancelEventArgs e) => this.DialogCancel = false;

        private void dlgSave_FileOk(object sender, CancelEventArgs e) => this.DialogCancel = false;

        private void mnuMinAll_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in this.MdiChildren)
                mdiChild.WindowState = FormWindowState.Minimized;
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Component mdiChild in this.MdiChildren)
                mdiChild.Dispose();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            int num = (int)new frmAbout().ShowDialog((IWin32Window)this);
        }

        private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();

        public void DetachByPID(uint processID)
        {
            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmMacro)
                {
                    frmMacro frmMacro = (frmMacro)mdiChild;
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
                        frmMacro.memRead = (MemoryReader)null;
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != 786)
                return;
            this.HotkeyAction((int)m.WParam);
        }

        public void HotkeyAction(int hotkeyID)
        {
            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild is frmMacro)
                {
                    frmMacro frmMacro = (frmMacro)mdiChild;
                    if ((int)frmMacro.hotkey.HotkeyID == hotkeyID)
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
            TreeNode selectedNode = this.tvwCommands.SelectedNode;
            if (selectedNode.Nodes.Count != 0 || this.ActiveMacro == null || this.ActiveMacro.IsDisposed)
                return;
            this.ActiveMacro.AddCommand($"{selectedNode.Text}|{selectedNode.Tag}");
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (!(this.ActiveMdiChild is frmMacro))
                return;
            this.ActiveMacro = (frmMacro)this.ActiveMdiChild;
        }

        private void chatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChat frmChat = new frmChat();
            frmChat.MdiParent = (Form)this;
            frmChat.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions frmOptions = new frmOptions();
            frmOptions.MdiParent = (Form)this;
            frmOptions.Show();
        }

        private void mnuArrange_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.Cascade);

        private void mnuTileVert_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuTileHoriz_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}