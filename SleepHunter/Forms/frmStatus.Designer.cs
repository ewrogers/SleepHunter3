using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class frmStatus
    {
        private IContainer components = null;
        private PictureBox picHP;
        private Label lblHPCaption;
        private PictureBox picMP;
        private Label lblMPCaption;
        private Label lblMAPCaption;
        private Label lblXCaption;
        private Label lblYCaption;
        private Timer tmrUpdate;
        private Label lblHP;
        private Label lblMP;
        private Label lblHPPercent;
        private Label lblMPPercent;
        private Label lblMAP;
        private Label lblX;
        private Label lblY;
        private Label lblHelp;
        private RichTextBox rtbChatLog;
        private CheckBox cbShowChat;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatus));
            this.picHP = new System.Windows.Forms.PictureBox();
            this.lblHPCaption = new System.Windows.Forms.Label();
            this.picMP = new System.Windows.Forms.PictureBox();
            this.lblMPCaption = new System.Windows.Forms.Label();
            this.lblMAPCaption = new System.Windows.Forms.Label();
            this.lblXCaption = new System.Windows.Forms.Label();
            this.lblYCaption = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblHP = new System.Windows.Forms.Label();
            this.lblMP = new System.Windows.Forms.Label();
            this.lblHPPercent = new System.Windows.Forms.Label();
            this.lblMPPercent = new System.Windows.Forms.Label();
            this.lblMAP = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.rtbChatLog = new System.Windows.Forms.RichTextBox();
            this.cbShowChat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMP)).BeginInit();
            this.SuspendLayout();
            // 
            // picHP
            // 
            this.picHP.BackColor = System.Drawing.SystemColors.Control;
            this.picHP.Location = new System.Drawing.Point(13, 25);
            this.picHP.Name = "picHP";
            this.picHP.Size = new System.Drawing.Size(271, 17);
            this.picHP.TabIndex = 0;
            this.picHP.TabStop = false;
            this.picHP.Paint += new System.Windows.Forms.PaintEventHandler(this.picHP_Paint);
            // 
            // lblHPCaption
            // 
            this.lblHPCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPCaption.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.lblHPCaption.Location = new System.Drawing.Point(12, 9);
            this.lblHPCaption.Name = "lblHPCaption";
            this.lblHPCaption.Size = new System.Drawing.Size(25, 12);
            this.lblHPCaption.TabIndex = 1;
            this.lblHPCaption.Text = "HP:";
            // 
            // picMP
            // 
            this.picMP.Location = new System.Drawing.Point(12, 67);
            this.picMP.Name = "picMP";
            this.picMP.Size = new System.Drawing.Size(271, 17);
            this.picMP.TabIndex = 2;
            this.picMP.TabStop = false;
            this.picMP.Paint += new System.Windows.Forms.PaintEventHandler(this.picMP_Paint);
            // 
            // lblMPCaption
            // 
            this.lblMPCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPCaption.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            this.lblMPCaption.Location = new System.Drawing.Point(12, 52);
            this.lblMPCaption.Name = "lblMPCaption";
            this.lblMPCaption.Size = new System.Drawing.Size(27, 12);
            this.lblMPCaption.TabIndex = 3;
            this.lblMPCaption.Text = "MP:";
            // 
            // lblMAPCaption
            // 
            this.lblMAPCaption.Image = ((System.Drawing.Image)(resources.GetObject("lblMAPCaption.Image")));
            this.lblMAPCaption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMAPCaption.Location = new System.Drawing.Point(11, 87);
            this.lblMAPCaption.Name = "lblMAPCaption";
            this.lblMAPCaption.Size = new System.Drawing.Size(56, 23);
            this.lblMAPCaption.TabIndex = 5;
            this.lblMAPCaption.Text = "       MAP:";
            this.lblMAPCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblXCaption
            // 
            this.lblXCaption.Image = ((System.Drawing.Image)(resources.GetObject("lblXCaption.Image")));
            this.lblXCaption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblXCaption.Location = new System.Drawing.Point(11, 110);
            this.lblXCaption.Name = "lblXCaption";
            this.lblXCaption.Size = new System.Drawing.Size(56, 22);
            this.lblXCaption.TabIndex = 6;
            this.lblXCaption.Text = "       X:";
            this.lblXCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYCaption
            // 
            this.lblYCaption.Image = ((System.Drawing.Image)(resources.GetObject("lblYCaption.Image")));
            this.lblYCaption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblYCaption.Location = new System.Drawing.Point(10, 132);
            this.lblYCaption.Name = "lblYCaption";
            this.lblYCaption.Size = new System.Drawing.Size(57, 22);
            this.lblYCaption.TabIndex = 7;
            this.lblYCaption.Text = "       Y:";
            this.lblYCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblHP
            // 
            this.lblHP.Location = new System.Drawing.Point(39, 9);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(174, 13);
            this.lblHP.TabIndex = 8;
            this.lblHP.Text = "0/0";
            this.lblHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMP
            // 
            this.lblMP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMP.Location = new System.Drawing.Point(39, 51);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(174, 13);
            this.lblMP.TabIndex = 9;
            this.lblMP.Text = "0/0";
            this.lblMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHPPercent
            // 
            this.lblHPPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPPercent.Location = new System.Drawing.Point(220, 9);
            this.lblHPPercent.Name = "lblHPPercent";
            this.lblHPPercent.Size = new System.Drawing.Size(63, 13);
            this.lblHPPercent.TabIndex = 10;
            this.lblHPPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMPPercent
            // 
            this.lblMPPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPPercent.Location = new System.Drawing.Point(221, 51);
            this.lblMPPercent.Name = "lblMPPercent";
            this.lblMPPercent.Size = new System.Drawing.Size(63, 13);
            this.lblMPPercent.TabIndex = 11;
            this.lblMPPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMAP
            // 
            this.lblMAP.AutoSize = true;
            this.lblMAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMAP.Location = new System.Drawing.Point(73, 92);
            this.lblMAP.Name = "lblMAP";
            this.lblMAP.Size = new System.Drawing.Size(22, 13);
            this.lblMAP.TabIndex = 12;
            this.lblMAP.Text = "???";
            this.lblMAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblX.Location = new System.Drawing.Point(73, 115);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(22, 13);
            this.lblX.TabIndex = 13;
            this.lblX.Text = "???";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblY.Location = new System.Drawing.Point(73, 137);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(22, 13);
            this.lblY.TabIndex = 14;
            this.lblY.Text = "???";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHelp
            // 
            this.lblHelp.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblHelp.Location = new System.Drawing.Point(98, 115);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(186, 41);
            this.lblHelp.TabIndex = 15;
            this.lblHelp.Text = "Drag the Dark Ages process icon anywhere on this window to attach.";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // rtbChatLog
            // 
            this.rtbChatLog.Enabled = false;
            this.rtbChatLog.Location = new System.Drawing.Point(13, 175);
            this.rtbChatLog.Name = "rtbChatLog";
            this.rtbChatLog.Size = new System.Drawing.Size(272, 199);
            this.rtbChatLog.TabIndex = 16;
            this.rtbChatLog.Text = "";
            // 
            // cbShowChat
            // 
            this.cbShowChat.AutoSize = true;
            this.cbShowChat.Enabled = false;
            this.cbShowChat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbShowChat.Location = new System.Drawing.Point(203, 110);
            this.cbShowChat.Name = "cbShowChat";
            this.cbShowChat.Size = new System.Drawing.Size(84, 17);
            this.cbShowChat.TabIndex = 17;
            this.cbShowChat.Text = "Enable Chat";
            this.cbShowChat.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmStatus
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 162);
            this.Controls.Add(this.cbShowChat);
            this.Controls.Add(this.rtbChatLog);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblMAP);
            this.Controls.Add(this.lblMPPercent);
            this.Controls.Add(this.lblHPPercent);
            this.Controls.Add(this.lblMP);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblYCaption);
            this.Controls.Add(this.lblXCaption);
            this.Controls.Add(this.lblMAPCaption);
            this.Controls.Add(this.lblMPCaption);
            this.Controls.Add(this.picMP);
            this.Controls.Add(this.lblHPCaption);
            this.Controls.Add(this.picHP);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStatus";
            this.Text = "Status Window";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmStatus_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmStatus_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.picHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}