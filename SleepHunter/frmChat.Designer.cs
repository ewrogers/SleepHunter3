using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    partial class frmChat
    {
        private IContainer components = null;
        private RichTextBox rtbChatLog;
        private Label label1;
        private System.Windows.Forms.Timer tmrUpdate;
        private Label lblHelp;
        private TextBox txtChatInput;
        private Label lblEnterTxt;
        private Button btnSendChat;
        private ComboBox cmbChatType;
        private ToolStrip toolStrip1;
        private ToolStripButton btnFloat;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDock;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnToggleTopmost;
        private TextBox txtWhisperTrgt;
        private Label lblWhisperTo;

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
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.rtbChatLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblHelp = new System.Windows.Forms.Label();
            this.btnFloat = new System.Windows.Forms.ToolStripButton();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.lblEnterTxt = new System.Windows.Forms.Label();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.cmbChatType = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToggleTopmost = new System.Windows.Forms.ToolStripButton();
            this.txtWhisperTrgt = new System.Windows.Forms.TextBox();
            this.lblWhisperTo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChatLog
            // 
            this.rtbChatLog.Location = new System.Drawing.Point(10, 37);
            this.rtbChatLog.Name = "rtbChatLog";
            this.rtbChatLog.ReadOnly = true;
            this.rtbChatLog.Size = new System.Drawing.Size(419, 345);
            this.rtbChatLog.TabIndex = 0;
            this.rtbChatLog.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(453, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chat will appear to the left when you attach a DA process.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHelp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblHelp.Location = new System.Drawing.Point(431, 323);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(133, 59);
            this.lblHelp.TabIndex = 16;
            this.lblHelp.Text = "Drag the Dark Ages process icon anywhere on this window to attach for reading.";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnFloat
            // 
            this.btnFloat.Image = ((System.Drawing.Image)(componentResourceManager.GetObject("btnFloat.Image")));
            this.btnFloat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFloat.Name = "btnFloat";
            this.btnFloat.Size = new System.Drawing.Size(92, 22);
            this.btnFloat.Text = "Float Window";
            this.btnFloat.Click += new System.EventHandler(this.btnFloat_Click);
            // 
            // txtChatInput
            // 
            this.txtChatInput.Location = new System.Drawing.Point(97, 403);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(418, 20);
            this.txtChatInput.TabIndex = 18;
            this.txtChatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatInput_KeyDown);
            // 
            // lblEnterTxt
            // 
            this.lblEnterTxt.AutoSize = true;
            this.lblEnterTxt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEnterTxt.Location = new System.Drawing.Point(8, 385);
            this.lblEnterTxt.Name = "lblEnterTxt";
            this.lblEnterTxt.Size = new System.Drawing.Size(135, 13);
            this.lblEnterTxt.TabIndex = 19;
            this.lblEnterTxt.Text = "Enter Text To Send Below:";
            // 
            // btnSendChat
            // 
            this.btnSendChat.Location = new System.Drawing.Point(521, 403);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(43, 20);
            this.btnSendChat.TabIndex = 20;
            this.btnSendChat.Text = "Send";
            this.btnSendChat.UseVisualStyleBackColor = true;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // cmbChatType
            // 
            this.cmbChatType.FormattingEnabled = true;
            this.cmbChatType.Items.AddRange(new object[] {
            "Say",
            "Whisper",
            "Guild",
            "Group"});
            this.cmbChatType.Location = new System.Drawing.Point(11, 402);
            this.cmbChatType.Name = "cmbChatType";
            this.cmbChatType.Size = new System.Drawing.Size(85, 21);
            this.cmbChatType.TabIndex = 21;
            this.cmbChatType.SelectedIndexChanged += new System.EventHandler(this.cmbChatType_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFloat,
            this.toolStripSeparator1,
            this.btnDock,
            this.toolStripSeparator2,
            this.btnToggleTopmost});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(568, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDock
            // 
            this.btnDock.Enabled = false;
            this.btnDock.Image = ((System.Drawing.Image)(componentResourceManager.GetObject("btnDock.Image")));
            this.btnDock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDock.Name = "btnDock";
            this.btnDock.Size = new System.Drawing.Size(91, 22);
            this.btnDock.Text = "Dock Window";
            this.btnDock.Click += new System.EventHandler(this.btnDock_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnToggleTopmost
            // 
            this.btnToggleTopmost.Image = ((System.Drawing.Image)(componentResourceManager.GetObject("btnToggleTopmost.Image")));
            this.btnToggleTopmost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToggleTopmost.Name = "btnToggleTopmost";
            this.btnToggleTopmost.Size = new System.Drawing.Size(122, 22);
            this.btnToggleTopmost.Text = "Toggle Stay On Top";
            this.btnToggleTopmost.Visible = false;
            this.btnToggleTopmost.Click += new System.EventHandler(this.btnToggleTopmost_Click);
            // 
            // txtWhisperTrgt
            // 
            this.txtWhisperTrgt.Location = new System.Drawing.Point(165, 427);
            this.txtWhisperTrgt.Name = "txtWhisperTrgt";
            this.txtWhisperTrgt.Size = new System.Drawing.Size(153, 20);
            this.txtWhisperTrgt.TabIndex = 23;
            this.txtWhisperTrgt.Visible = false;
            // 
            // lblWhisperTo
            // 
            this.lblWhisperTo.AutoSize = true;
            this.lblWhisperTo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblWhisperTo.Location = new System.Drawing.Point(94, 430);
            this.lblWhisperTo.Name = "lblWhisperTo";
            this.lblWhisperTo.Size = new System.Drawing.Size(65, 13);
            this.lblWhisperTo.TabIndex = 24;
            this.lblWhisperTo.Text = "Whisper To:";
            this.lblWhisperTo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblWhisperTo.Visible = false;
            // 
            // frmChat
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 452);
            this.Controls.Add(this.lblWhisperTo);
            this.Controls.Add(this.txtWhisperTrgt);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmbChatType);
            this.Controls.Add(this.btnSendChat);
            this.Controls.Add(this.lblEnterTxt);
            this.Controls.Add(this.txtChatInput);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbChatLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(componentResourceManager.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChat";
            this.Text = "Chat Window";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmChat_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmChat_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
