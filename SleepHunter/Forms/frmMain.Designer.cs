using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class frmMain : Form
    {
        private IContainer components = null;
        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuNew;
        private ToolStripMenuItem mnuOpen;
        private ToolStripMenuItem mnuSave;
        private ToolStripSeparator SeperatorA;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuStatus;
        private ToolStripMenuItem mnuAttach;
        private ToolStripMenuItem chatWindowToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem mnuWindow;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileVert;
        private ToolStripMenuItem mnuTileHoriz;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuMinAll;
        private ToolStripMenuItem mnuCloseAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuSearch;
        private ToolStripMenuItem mnuDocumentation;
        private ToolStripSeparator SeperatorB;
        private ToolStripMenuItem mnuAbout;
        internal NotifyIcon nidIcon;
        private StatusStrip stbMain;
        private ToolStripStatusLabel lblStatus;
        private Panel pnlCommands;
        private TreeView tvwCommands;
        private ImageList ilsNodes;
        private Timer tmrDblTargetChk;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;

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
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMain));
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
            TreeNode treeNode60 = new TreeNode("Logic Library", 0, 0, new TreeNode[3]
            {
      treeNode23,
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
      treeNode66,
      treeNode65,
      treeNode63,
      treeNode64,
      treeNode62,
      treeNode61
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
            this.mnuNew.Image = (Image)resources.GetObject("mnuNew.Image");
            this.mnuNew.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = Keys.N | Keys.Control;
            this.mnuNew.Size = new Size(186, 22);
            this.mnuNew.Text = "&New Macro";
            this.mnuNew.Click += new EventHandler(this.mnuNew_Click);
            this.mnuOpen.Image = (Image)resources.GetObject("mnuOpen.Image");
            this.mnuOpen.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = Keys.O | Keys.Control;
            this.mnuOpen.Size = new Size(186, 22);
            this.mnuOpen.Text = "&Open Macro";
            this.mnuOpen.Click += new EventHandler(this.mnuOpen_Click);
            this.mnuSave.Image = (Image)resources.GetObject("mnuSave.Image");
            this.mnuSave.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = Keys.S | Keys.Control;
            this.mnuSave.Size = new Size(186, 22);
            this.mnuSave.Text = "&Save Macro";
            this.mnuSave.Click += new EventHandler(this.mnuSave_Click);
            this.SeperatorA.Name = "SeperatorA";
            this.SeperatorA.Size = new Size(183, 6);
            this.mnuExit.Image = (Image)resources.GetObject("mnuExit.Image");
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
            this.mnuStatus.Image = (Image)resources.GetObject("mnuStatus.Image");
            this.mnuStatus.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.ShortcutKeys = Keys.H | Keys.Control;
            this.mnuStatus.Size = new Size(205, 22);
            this.mnuStatus.Text = "S&tatus Window";
            this.mnuStatus.Click += new EventHandler(this.mnuStatus_Click);
            this.mnuAttach.Image = (Image)resources.GetObject("mnuAttach.Image");
            this.mnuAttach.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuAttach.Name = "mnuAttach";
            this.mnuAttach.ShortcutKeys = Keys.P | Keys.Control;
            this.mnuAttach.Size = new Size(205, 22);
            this.mnuAttach.Text = "&Process Manager";
            this.mnuAttach.Click += new EventHandler(this.mnuAttach_Click);
            this.chatWindowToolStripMenuItem.Enabled = false;
            this.chatWindowToolStripMenuItem.Image = (Image)resources.GetObject("chatWindowToolStripMenuItem.Image");
            this.chatWindowToolStripMenuItem.Name = "chatWindowToolStripMenuItem";
            this.chatWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.chatWindowToolStripMenuItem.ShortcutKeys = Keys.C | Keys.Control;
            this.chatWindowToolStripMenuItem.Size = new Size(205, 22);
            this.chatWindowToolStripMenuItem.Text = "&Chat Window";
            this.chatWindowToolStripMenuItem.Click += new EventHandler(this.chatWindowToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Image = (Image)resources.GetObject("optionsToolStripMenuItem.Image");
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
            this.mnuSearch.Image = (Image)resources.GetObject("mnuSearch.Image");
            this.mnuSearch.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.ShortcutKeys = Keys.F3;
            this.mnuSearch.Size = new Size(188, 22);
            this.mnuSearch.Text = "S&earch...";
            this.mnuSearch.Visible = false;
            this.mnuDocumentation.Enabled = false;
            this.mnuDocumentation.Image = (Image)resources.GetObject("mnuDocumentation.Image");
            this.mnuDocumentation.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuDocumentation.Name = "mnuDocumentation";
            this.mnuDocumentation.ShortcutKeys = Keys.F1;
            this.mnuDocumentation.Size = new Size(188, 22);
            this.mnuDocumentation.Text = "&Documentation...";
            this.mnuDocumentation.Visible = false;
            this.SeperatorB.Name = "SeperatorB";
            this.SeperatorB.Size = new Size(185, 6);
            this.SeperatorB.Visible = false;
            this.mnuAbout.Image = (Image)resources.GetObject("mnuAbout.Image");
            this.mnuAbout.ImageScaling = ToolStripItemImageScaling.None;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.ShortcutKeys = Keys.F12 | Keys.Control;
            this.mnuAbout.Size = new Size(188, 22);
            this.mnuAbout.Text = "&About SleepHunter";
            this.mnuAbout.Click += new EventHandler(this.mnuAbout_Click);
            this.nidIcon.Icon = (Icon)resources.GetObject("nidIcon.Icon");
            this.nidIcon.Text = "SleepHunter";
            this.nidIcon.Visible = true;
            this.stbMain.Items.AddRange(new ToolStripItem[1]
            {
      (ToolStripItem) this.lblStatus
            });
            this.stbMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.stbMain.Location = new Point(0, 551);
            this.stbMain.Name = "stbMain";
            this.stbMain.Size = new Size(792, 22);
            this.stbMain.SizingGrip = false;
            this.stbMain.TabIndex = 4;
            this.stbMain.Text = "statusStrip1";
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(93, 17);
            this.lblStatus.Text = "SleepHunter v3.0";
            this.pnlCommands.BorderStyle = BorderStyle.Fixed3D;
            this.pnlCommands.Controls.Add((Control)this.tvwCommands);
            this.pnlCommands.Dock = DockStyle.Left;
            this.pnlCommands.Location = new Point(0, 24);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new Size(196, 527);
            this.pnlCommands.TabIndex = 5;
            this.tvwCommands.AllowDrop = true;
            this.tvwCommands.Dock = DockStyle.Fill;
            this.tvwCommands.ImageIndex = 0;
            this.tvwCommands.ImageList = this.ilsNodes;
            this.tvwCommands.Location = new Point(0, 0);
            this.tvwCommands.Name = "tvwCommands";
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
            this.tvwCommands.Size = new Size(192, 519);
            this.tvwCommands.Sorted = true;
            this.tvwCommands.TabIndex = 0;
            this.tvwCommands.DoubleClick += new EventHandler(this.tvwCommands_DoubleClick);
            this.tvwCommands.ItemDrag += new ItemDragEventHandler(this.tvwCommands_ItemDrag);
            this.ilsNodes.ImageStream = (ImageListStreamer)resources.GetObject("ilsNodes.ImageStream");
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
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
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
    }
}
