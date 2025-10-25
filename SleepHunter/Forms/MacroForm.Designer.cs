using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class MacroForm : Form
    {
        private IContainer components = null;
        private StatusStrip macroStatusBar;
        private SplitContainer macroSplitContainer;
        private SplitContainer headerSplitContainer;
        private GroupBox macroGroupBox;
        private GroupBox hotkeyGroupBox;
        private CheckBox hotkeyCheckBox;
        private ColumnHeader lineColumn;
        private ColumnHeader commandColumn;
        private ToolStrip macroToolStrip;
        private ToolStripButton editButton;
        private ToolStripButton deleteButton;
        private ToolStripButton cutButton;
        private ToolStripButton copyButton;
        private ToolStripButton pasteButton;
        private ToolStripButton moveUpButton;
        private ToolStripButton moveDownButton;
        private ToolStripButton playButton;
        private ToolStripButton pauseButton;
        private ToolStripButton stopButton;
        private ToolStripDropDownButton quickAttachButton;
        private System.Windows.Forms.Timer processTimer;

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
            System.Windows.Forms.ToolStripSeparator contextMenuSeparator1;
            System.Windows.Forms.ToolStripSeparator contextMenuSeparator2;
            System.Windows.Forms.ToolStripSeparator separator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroForm));
            this.macroStatusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.macroSplitContainer = new System.Windows.Forms.SplitContainer();
            this.headerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.macroGroupBox = new System.Windows.Forms.GroupBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.hotkeyGroupBox = new System.Windows.Forms.GroupBox();
            this.hotkeyHelpText = new System.Windows.Forms.Label();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.characterNameLabel = new System.Windows.Forms.Label();
            this.hotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.macroListView = new System.Windows.Forms.ListView();
            this.lineColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.macroContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSelectedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutSelectedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteSelectedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.macroToolStrip = new System.Windows.Forms.ToolStrip();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.cutButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.pasteButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownButton = new System.Windows.Forms.ToolStripButton();
            this.playButton = new System.Windows.Forms.ToolStripButton();
            this.pauseButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.debugStepButton = new System.Windows.Forms.ToolStripButton();
            this.quickAttachButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusImageList = new System.Windows.Forms.ImageList(this.components);
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            contextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            contextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            separator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.macroStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroSplitContainer)).BeginInit();
            this.macroSplitContainer.Panel1.SuspendLayout();
            this.macroSplitContainer.Panel2.SuspendLayout();
            this.macroSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerSplitContainer)).BeginInit();
            this.headerSplitContainer.Panel1.SuspendLayout();
            this.headerSplitContainer.Panel2.SuspendLayout();
            this.headerSplitContainer.SuspendLayout();
            this.macroGroupBox.SuspendLayout();
            this.hotkeyGroupBox.SuspendLayout();
            this.macroContextMenu.SuspendLayout();
            this.macroToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuSeparator1
            // 
            contextMenuSeparator1.Name = "contextMenuSeparator1";
            contextMenuSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // contextMenuSeparator2
            // 
            contextMenuSeparator2.Name = "contextMenuSeparator2";
            contextMenuSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // macroStatusBar
            // 
            this.macroStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.macroStatusBar.Location = new System.Drawing.Point(0, 437);
            this.macroStatusBar.Name = "macroStatusBar";
            this.macroStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.macroStatusBar.Size = new System.Drawing.Size(444, 24);
            this.macroStatusBar.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Image = ((System.Drawing.Image)(resources.GetObject("statusLabel.Image")));
            this.statusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusLabel.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(1);
            this.statusLabel.Size = new System.Drawing.Size(427, 19);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "Macro is not running.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // macroSplitContainer
            // 
            this.macroSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macroSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.macroSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.macroSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.macroSplitContainer.Name = "macroSplitContainer";
            this.macroSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // macroSplitContainer.Panel1
            // 
            this.macroSplitContainer.Panel1.Controls.Add(this.headerSplitContainer);
            this.macroSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // macroSplitContainer.Panel2
            // 
            this.macroSplitContainer.Panel2.Controls.Add(this.macroListView);
            this.macroSplitContainer.Panel2.Controls.Add(this.macroToolStrip);
            this.macroSplitContainer.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.macroSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(6, 1, 5, 5);
            this.macroSplitContainer.Size = new System.Drawing.Size(444, 437);
            this.macroSplitContainer.SplitterDistance = 136;
            this.macroSplitContainer.SplitterWidth = 5;
            this.macroSplitContainer.TabIndex = 0;
            this.macroSplitContainer.Text = "splitContainer1";
            // 
            // headerSplitContainer
            // 
            this.headerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.headerSplitContainer.Location = new System.Drawing.Point(5, 5);
            this.headerSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.headerSplitContainer.Name = "headerSplitContainer";
            // 
            // headerSplitContainer.Panel1
            // 
            this.headerSplitContainer.Panel1.AllowDrop = true;
            this.headerSplitContainer.Panel1.Controls.Add(this.macroGroupBox);
            this.headerSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.headerSplitContainer.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.processPanel_DragDrop);
            this.headerSplitContainer.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.processPanel_DragEnter);
            // 
            // headerSplitContainer.Panel2
            // 
            this.headerSplitContainer.Panel2.AllowDrop = true;
            this.headerSplitContainer.Panel2.Controls.Add(this.hotkeyGroupBox);
            this.headerSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.headerSplitContainer.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.processPanel_DragDrop);
            this.headerSplitContainer.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.processPanel_DragEnter);
            this.headerSplitContainer.Size = new System.Drawing.Size(434, 126);
            this.headerSplitContainer.SplitterDistance = 211;
            this.headerSplitContainer.SplitterWidth = 5;
            this.headerSplitContainer.TabIndex = 0;
            this.headerSplitContainer.Text = "splitContainer1";
            // 
            // macroGroupBox
            // 
            this.macroGroupBox.Controls.Add(this.authorTextBox);
            this.macroGroupBox.Controls.Add(this.authorLabel);
            this.macroGroupBox.Controls.Add(this.nameTextBox);
            this.macroGroupBox.Controls.Add(this.nameLabel);
            this.macroGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macroGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macroGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.macroGroupBox.Location = new System.Drawing.Point(0, 0);
            this.macroGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.macroGroupBox.Name = "macroGroupBox";
            this.macroGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.macroGroupBox.Size = new System.Drawing.Size(210, 126);
            this.macroGroupBox.TabIndex = 0;
            this.macroGroupBox.TabStop = false;
            this.macroGroupBox.Text = "Macro Details";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(8, 88);
            this.authorTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(194, 23);
            this.authorTextBox.TabIndex = 3;
            this.authorTextBox.TextChanged += new System.EventHandler(this.authorTextBox_TextChanged);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.authorLabel.Location = new System.Drawing.Point(8, 70);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(47, 15);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Author:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(8, 42);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(194, 23);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameLabel.Location = new System.Drawing.Point(8, 24);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(79, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Macro Name:";
            // 
            // hotkeyGroupBox
            // 
            this.hotkeyGroupBox.Controls.Add(this.hotkeyHelpText);
            this.hotkeyGroupBox.Controls.Add(this.hotkeyTextBox);
            this.hotkeyGroupBox.Controls.Add(this.characterNameLabel);
            this.hotkeyGroupBox.Controls.Add(this.hotkeyCheckBox);
            this.hotkeyGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotkeyGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkeyGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hotkeyGroupBox.Location = new System.Drawing.Point(1, 0);
            this.hotkeyGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hotkeyGroupBox.Name = "hotkeyGroupBox";
            this.hotkeyGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hotkeyGroupBox.Size = new System.Drawing.Size(217, 126);
            this.hotkeyGroupBox.TabIndex = 0;
            this.hotkeyGroupBox.TabStop = false;
            this.hotkeyGroupBox.Text = "Hotkey";
            // 
            // hotkeyHelpText
            // 
            this.hotkeyHelpText.AutoSize = true;
            this.hotkeyHelpText.Location = new System.Drawing.Point(23, 96);
            this.hotkeyHelpText.Name = "hotkeyHelpText";
            this.hotkeyHelpText.Size = new System.Drawing.Size(137, 15);
            this.hotkeyHelpText.TabIndex = 3;
            this.hotkeyHelpText.Text = "Press to Set, ESC to Clear";
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.Location = new System.Drawing.Point(11, 70);
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.ReadOnly = true;
            this.hotkeyTextBox.Size = new System.Drawing.Size(159, 23);
            this.hotkeyTextBox.TabIndex = 2;
            this.hotkeyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotkeyTextBox_KeyDown);
            // 
            // characterNameLabel
            // 
            this.characterNameLabel.AutoEllipsis = true;
            this.characterNameLabel.AutoSize = true;
            this.characterNameLabel.Enabled = false;
            this.characterNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.characterNameLabel.Location = new System.Drawing.Point(8, 22);
            this.characterNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.characterNameLabel.Name = "characterNameLabel";
            this.characterNameLabel.Size = new System.Drawing.Size(106, 17);
            this.characterNameLabel.TabIndex = 0;
            this.characterNameLabel.Text = "Character Name";
            // 
            // hotkeyCheckBox
            // 
            this.hotkeyCheckBox.AutoSize = true;
            this.hotkeyCheckBox.Checked = true;
            this.hotkeyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hotkeyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotkeyCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hotkeyCheckBox.Location = new System.Drawing.Point(11, 45);
            this.hotkeyCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hotkeyCheckBox.Name = "hotkeyCheckBox";
            this.hotkeyCheckBox.Size = new System.Drawing.Size(108, 20);
            this.hotkeyCheckBox.TabIndex = 1;
            this.hotkeyCheckBox.Text = "Enable Hotkey";
            this.hotkeyCheckBox.CheckedChanged += new System.EventHandler(this.hotkeyCheckBox_CheckedChanged);
            // 
            // macroListView
            // 
            this.macroListView.AllowDrop = true;
            this.macroListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.macroListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lineColumn,
            this.commandColumn});
            this.macroListView.ContextMenuStrip = this.macroContextMenu;
            this.macroListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macroListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macroListView.FullRowSelect = true;
            this.macroListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.macroListView.HideSelection = false;
            this.macroListView.Location = new System.Drawing.Point(6, 26);
            this.macroListView.Margin = new System.Windows.Forms.Padding(12);
            this.macroListView.Name = "macroListView";
            this.macroListView.Size = new System.Drawing.Size(433, 265);
            this.macroListView.TabIndex = 1;
            this.macroListView.UseCompatibleStateImageBehavior = false;
            this.macroListView.View = System.Windows.Forms.View.Details;
            this.macroListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.macroListView_ItemDrag);
            this.macroListView.SelectedIndexChanged += new System.EventHandler(this.macroListView_SelectedIndexChanged);
            this.macroListView.SizeChanged += new System.EventHandler(this.macroListView_SizeChanged);
            this.macroListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.macroListView_DragDrop);
            this.macroListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.macroListView_DragEnter);
            this.macroListView.DragOver += new System.Windows.Forms.DragEventHandler(this.macroListView_DragOver);
            this.macroListView.DragLeave += new System.EventHandler(this.macroListView_DragLeave);
            this.macroListView.DoubleClick += new System.EventHandler(this.macroListView_DoubleClick);
            this.macroListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.macroListView_KeyPress);
            // 
            // lineColumn
            // 
            this.lineColumn.Text = "Line #";
            this.lineColumn.Width = 50;
            // 
            // commandColumn
            // 
            this.commandColumn.Text = "Command";
            this.commandColumn.Width = 320;
            // 
            // macroContextMenu
            // 
            this.macroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedMenu,
            contextMenuSeparator1,
            this.cutSelectedMenu,
            this.copySelectedMenu,
            this.pasteSelectedMenu,
            this.deleteSelectedMenu,
            contextMenuSeparator2,
            this.moveUpMenu,
            this.moveDownMenu});
            this.macroContextMenu.Name = "macroContextMenu";
            this.macroContextMenu.Size = new System.Drawing.Size(204, 170);
            // 
            // editSelectedMenu
            // 
            this.editSelectedMenu.Image = ((System.Drawing.Image)(resources.GetObject("editSelectedMenu.Image")));
            this.editSelectedMenu.Name = "editSelectedMenu";
            this.editSelectedMenu.Size = new System.Drawing.Size(203, 22);
            this.editSelectedMenu.Text = "Edit..";
            this.editSelectedMenu.Click += new System.EventHandler(this.edit_Click);
            // 
            // cutSelectedMenu
            // 
            this.cutSelectedMenu.Image = ((System.Drawing.Image)(resources.GetObject("cutSelectedMenu.Image")));
            this.cutSelectedMenu.Name = "cutSelectedMenu";
            this.cutSelectedMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutSelectedMenu.Size = new System.Drawing.Size(203, 22);
            this.cutSelectedMenu.Text = "Cut";
            this.cutSelectedMenu.Click += new System.EventHandler(this.cutSelected_Click);
            // 
            // copySelectedMenu
            // 
            this.copySelectedMenu.Image = ((System.Drawing.Image)(resources.GetObject("copySelectedMenu.Image")));
            this.copySelectedMenu.Name = "copySelectedMenu";
            this.copySelectedMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copySelectedMenu.Size = new System.Drawing.Size(203, 22);
            this.copySelectedMenu.Text = "Copy";
            this.copySelectedMenu.Click += new System.EventHandler(this.copySelected_Click);
            // 
            // pasteSelectedMenu
            // 
            this.pasteSelectedMenu.Image = ((System.Drawing.Image)(resources.GetObject("pasteSelectedMenu.Image")));
            this.pasteSelectedMenu.Name = "pasteSelectedMenu";
            this.pasteSelectedMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteSelectedMenu.Size = new System.Drawing.Size(203, 22);
            this.pasteSelectedMenu.Text = "Paste";
            this.pasteSelectedMenu.Click += new System.EventHandler(this.paste_Click);
            // 
            // deleteSelectedMenu
            // 
            this.deleteSelectedMenu.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectedMenu.Image")));
            this.deleteSelectedMenu.Name = "deleteSelectedMenu";
            this.deleteSelectedMenu.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectedMenu.Size = new System.Drawing.Size(203, 22);
            this.deleteSelectedMenu.Text = "Delete";
            this.deleteSelectedMenu.Click += new System.EventHandler(this.deleteSelected_Click);
            // 
            // moveUpMenu
            // 
            this.moveUpMenu.Image = ((System.Drawing.Image)(resources.GetObject("moveUpMenu.Image")));
            this.moveUpMenu.Name = "moveUpMenu";
            this.moveUpMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.moveUpMenu.Size = new System.Drawing.Size(203, 22);
            this.moveUpMenu.Text = "Move Up";
            this.moveUpMenu.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDownMenu
            // 
            this.moveDownMenu.Image = ((System.Drawing.Image)(resources.GetObject("moveDownMenu.Image")));
            this.moveDownMenu.Name = "moveDownMenu";
            this.moveDownMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.moveDownMenu.Size = new System.Drawing.Size(203, 22);
            this.moveDownMenu.Text = "Move Down";
            this.moveDownMenu.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // macroToolStrip
            // 
            this.macroToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editButton,
            this.deleteButton,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.moveUpButton,
            this.moveDownButton,
            separator1,
            this.playButton,
            this.pauseButton,
            this.stopButton,
            toolStripSeparator2,
            this.debugStepButton,
            this.quickAttachButton});
            this.macroToolStrip.Location = new System.Drawing.Point(6, 1);
            this.macroToolStrip.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.macroToolStrip.Name = "macroToolStrip";
            this.macroToolStrip.Size = new System.Drawing.Size(433, 25);
            this.macroToolStrip.TabIndex = 0;
            this.macroToolStrip.Text = "toolStrip1";
            // 
            // editButton
            // 
            this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(23, 22);
            this.editButton.Text = "toolStripButton1";
            this.editButton.ToolTipText = "Edit Command";
            this.editButton.Click += new System.EventHandler(this.edit_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 22);
            this.deleteButton.Text = "toolStripButton2";
            this.deleteButton.ToolTipText = "Delete Command(s)";
            this.deleteButton.Click += new System.EventHandler(this.deleteSelected_Click);
            // 
            // cutButton
            // 
            this.cutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutButton.Image = ((System.Drawing.Image)(resources.GetObject("cutButton.Image")));
            this.cutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(23, 22);
            this.cutButton.Text = "toolStripButton3";
            this.cutButton.ToolTipText = "Cut Command(s)";
            this.cutButton.Click += new System.EventHandler(this.cutSelected_Click);
            // 
            // copyButton
            // 
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 22);
            this.copyButton.Text = "toolStripButton4";
            this.copyButton.ToolTipText = "Copy Command(s)";
            this.copyButton.Click += new System.EventHandler(this.copySelected_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteButton.Image")));
            this.pasteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(23, 22);
            this.pasteButton.Text = "toolStripButton5";
            this.pasteButton.ToolTipText = "Paste Command(s)";
            this.pasteButton.Click += new System.EventHandler(this.paste_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveUpButton.Image")));
            this.moveUpButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 22);
            this.moveUpButton.Text = "toolStripButton6";
            this.moveUpButton.ToolTipText = "Move Up";
            this.moveUpButton.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownButton.Image = ((System.Drawing.Image)(resources.GetObject("moveDownButton.Image")));
            this.moveDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 22);
            this.moveDownButton.Text = "toolStripButton7";
            this.moveDownButton.ToolTipText = "Move Down";
            this.moveDownButton.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // playButton
            // 
            this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 22);
            this.playButton.Text = "Start Macro";
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(23, 22);
            this.pauseButton.Text = "Pause Macro";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "Stop Macro";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // debugStepButton
            // 
            this.debugStepButton.CheckOnClick = true;
            this.debugStepButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.debugStepButton.Image = ((System.Drawing.Image)(resources.GetObject("debugStepButton.Image")));
            this.debugStepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugStepButton.Name = "debugStepButton";
            this.debugStepButton.Size = new System.Drawing.Size(34, 22);
            this.debugStepButton.Text = "Step";
            this.debugStepButton.ToolTipText = "Enable Debug Step Mode";
            this.debugStepButton.CheckedChanged += new System.EventHandler(this.debugStepButton_CheckedChanged);
            // 
            // quickAttachButton
            // 
            this.quickAttachButton.Image = ((System.Drawing.Image)(resources.GetObject("quickAttachButton.Image")));
            this.quickAttachButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quickAttachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quickAttachButton.Name = "quickAttachButton";
            this.quickAttachButton.Size = new System.Drawing.Size(108, 22);
            this.quickAttachButton.Text = " Quick Attach";
            this.quickAttachButton.ToolTipText = "Attach to Process";
            this.quickAttachButton.DropDownOpening += new System.EventHandler(this.quickAttachButton_DropDownOpening);
            this.quickAttachButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.quickAttachButton_DropDownItemClicked);
            // 
            // statusImageList
            // 
            this.statusImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusImageList.ImageStream")));
            this.statusImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.statusImageList.Images.SetKeyName(0, "macro_play.ico");
            this.statusImageList.Images.SetKeyName(1, "macro_pause.ico");
            this.statusImageList.Images.SetKeyName(2, "macro_stop.ico");
            this.statusImageList.Images.SetKeyName(3, "macro_error.ico");
            this.statusImageList.Images.SetKeyName(4, "services.ico");
            // 
            // processTimer
            // 
            this.processTimer.Enabled = true;
            this.processTimer.Interval = 250;
            // 
            // MacroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 461);
            this.Controls.Add(this.macroSplitContainer);
            this.Controls.Add(this.macroStatusBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MacroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Macro Data";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Closed);
            this.macroStatusBar.ResumeLayout(false);
            this.macroStatusBar.PerformLayout();
            this.macroSplitContainer.Panel1.ResumeLayout(false);
            this.macroSplitContainer.Panel2.ResumeLayout(false);
            this.macroSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroSplitContainer)).EndInit();
            this.macroSplitContainer.ResumeLayout(false);
            this.headerSplitContainer.Panel1.ResumeLayout(false);
            this.headerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerSplitContainer)).EndInit();
            this.headerSplitContainer.ResumeLayout(false);
            this.macroGroupBox.ResumeLayout(false);
            this.macroGroupBox.PerformLayout();
            this.hotkeyGroupBox.ResumeLayout(false);
            this.hotkeyGroupBox.PerformLayout();
            this.macroContextMenu.ResumeLayout(false);
            this.macroToolStrip.ResumeLayout(false);
            this.macroToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label characterNameLabel;
        private Label nameLabel;
        private TextBox nameTextBox;
        private ToolStripStatusLabel statusLabel;
        private ListView macroListView;
        private ImageList statusImageList;
        private ContextMenuStrip macroContextMenu;
        private ToolStripMenuItem editSelectedMenu;
        private ToolStripMenuItem cutSelectedMenu;
        private ToolStripMenuItem copySelectedMenu;
        private ToolStripMenuItem pasteSelectedMenu;
        private ToolStripMenuItem deleteSelectedMenu;
        private ToolStripMenuItem moveUpMenu;
        private ToolStripMenuItem moveDownMenu;
        private TextBox authorTextBox;
        private Label authorLabel;
        private TextBox hotkeyTextBox;
        private ToolStripButton debugStepButton;
        private Label hotkeyHelpText;
    }
}
