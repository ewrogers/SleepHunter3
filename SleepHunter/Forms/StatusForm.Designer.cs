using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class StatusForm
    {
        private IContainer components = null;
        private PictureBox healthPictureBox;
        private Label healthCaptionLabel;
        private PictureBox manaPictureBox;
        private Label manaCaptionLabel;
        private Label mapCaptionLabel;
        private Label mapXCaptionLabel;
        private Label mapYCaptionLabel;
        private Timer updateTimer;
        private Label healthLabel;
        private Label manaLabel;
        private Label healthPercentLabel;
        private Label manaPercentLabel;
        private Label mapLabel;
        private Label mapXLabel;
        private Label mapYLabel;
        private Label helpLabel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.healthPictureBox = new System.Windows.Forms.PictureBox();
            this.healthCaptionLabel = new System.Windows.Forms.Label();
            this.manaPictureBox = new System.Windows.Forms.PictureBox();
            this.manaCaptionLabel = new System.Windows.Forms.Label();
            this.mapCaptionLabel = new System.Windows.Forms.Label();
            this.mapXCaptionLabel = new System.Windows.Forms.Label();
            this.mapYCaptionLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.healthLabel = new System.Windows.Forms.Label();
            this.manaLabel = new System.Windows.Forms.Label();
            this.healthPercentLabel = new System.Windows.Forms.Label();
            this.manaPercentLabel = new System.Windows.Forms.Label();
            this.mapLabel = new System.Windows.Forms.Label();
            this.mapXLabel = new System.Windows.Forms.Label();
            this.mapYLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.healthPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // healthPictureBox
            // 
            this.healthPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.healthPictureBox.Location = new System.Drawing.Point(15, 33);
            this.healthPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.healthPictureBox.Name = "healthPictureBox";
            this.healthPictureBox.Size = new System.Drawing.Size(316, 22);
            this.healthPictureBox.TabIndex = 0;
            this.healthPictureBox.TabStop = false;
            this.healthPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.healthPictureBox_Paint);
            // 
            // healthCaptionLabel
            // 
            this.healthCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthCaptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.healthCaptionLabel.Location = new System.Drawing.Point(14, 12);
            this.healthCaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.healthCaptionLabel.Name = "healthCaptionLabel";
            this.healthCaptionLabel.Size = new System.Drawing.Size(29, 16);
            this.healthCaptionLabel.TabIndex = 0;
            this.healthCaptionLabel.Text = "HP:";
            // 
            // manaPictureBox
            // 
            this.manaPictureBox.Location = new System.Drawing.Point(14, 89);
            this.manaPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manaPictureBox.Name = "manaPictureBox";
            this.manaPictureBox.Size = new System.Drawing.Size(316, 22);
            this.manaPictureBox.TabIndex = 2;
            this.manaPictureBox.TabStop = false;
            this.manaPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.manaPictureBox_Paint);
            // 
            // manaCaptionLabel
            // 
            this.manaCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manaCaptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.manaCaptionLabel.Location = new System.Drawing.Point(14, 69);
            this.manaCaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manaCaptionLabel.Name = "manaCaptionLabel";
            this.manaCaptionLabel.Size = new System.Drawing.Size(31, 16);
            this.manaCaptionLabel.TabIndex = 3;
            this.manaCaptionLabel.Text = "MP:";
            // 
            // mapCaptionLabel
            // 
            this.mapCaptionLabel.Image = ((System.Drawing.Image)(resources.GetObject("mapCaptionLabel.Image")));
            this.mapCaptionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mapCaptionLabel.Location = new System.Drawing.Point(14, 115);
            this.mapCaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapCaptionLabel.Name = "mapCaptionLabel";
            this.mapCaptionLabel.Size = new System.Drawing.Size(75, 30);
            this.mapCaptionLabel.TabIndex = 6;
            this.mapCaptionLabel.Text = "       MAP:";
            this.mapCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapXCaptionLabel
            // 
            this.mapXCaptionLabel.Image = ((System.Drawing.Image)(resources.GetObject("mapXCaptionLabel.Image")));
            this.mapXCaptionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mapXCaptionLabel.Location = new System.Drawing.Point(13, 142);
            this.mapXCaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapXCaptionLabel.Name = "mapXCaptionLabel";
            this.mapXCaptionLabel.Size = new System.Drawing.Size(65, 29);
            this.mapXCaptionLabel.TabIndex = 8;
            this.mapXCaptionLabel.Text = "       X:";
            this.mapXCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapYCaptionLabel
            // 
            this.mapYCaptionLabel.Image = ((System.Drawing.Image)(resources.GetObject("mapYCaptionLabel.Image")));
            this.mapYCaptionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mapYCaptionLabel.Location = new System.Drawing.Point(128, 142);
            this.mapYCaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapYCaptionLabel.Name = "mapYCaptionLabel";
            this.mapYCaptionLabel.Size = new System.Drawing.Size(51, 29);
            this.mapYCaptionLabel.TabIndex = 10;
            this.mapYCaptionLabel.Text = "       Y:";
            this.mapYCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // healthLabel
            // 
            this.healthLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.Location = new System.Drawing.Point(46, 12);
            this.healthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(208, 17);
            this.healthLabel.TabIndex = 1;
            this.healthLabel.Text = "0/0";
            this.healthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manaLabel
            // 
            this.manaLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manaLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.manaLabel.Location = new System.Drawing.Point(46, 68);
            this.manaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manaLabel.Name = "manaLabel";
            this.manaLabel.Size = new System.Drawing.Size(208, 17);
            this.manaLabel.TabIndex = 4;
            this.manaLabel.Text = "0/0";
            this.manaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // healthPercentLabel
            // 
            this.healthPercentLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthPercentLabel.Location = new System.Drawing.Point(260, 12);
            this.healthPercentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.healthPercentLabel.Name = "healthPercentLabel";
            this.healthPercentLabel.Size = new System.Drawing.Size(70, 17);
            this.healthPercentLabel.TabIndex = 2;
            this.healthPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manaPercentLabel
            // 
            this.manaPercentLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manaPercentLabel.Location = new System.Drawing.Point(264, 68);
            this.manaPercentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manaPercentLabel.Name = "manaPercentLabel";
            this.manaPercentLabel.Size = new System.Drawing.Size(68, 17);
            this.manaPercentLabel.TabIndex = 5;
            this.manaPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapLabel.Location = new System.Drawing.Point(85, 124);
            this.mapLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(28, 14);
            this.mapLabel.TabIndex = 7;
            this.mapLabel.Text = "???";
            this.mapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapXLabel
            // 
            this.mapXLabel.AutoSize = true;
            this.mapXLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapXLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapXLabel.Location = new System.Drawing.Point(85, 150);
            this.mapXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapXLabel.Name = "mapXLabel";
            this.mapXLabel.Size = new System.Drawing.Size(28, 14);
            this.mapXLabel.TabIndex = 9;
            this.mapXLabel.Text = "???";
            this.mapXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapYLabel
            // 
            this.mapYLabel.AutoSize = true;
            this.mapYLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapYLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mapYLabel.Location = new System.Drawing.Point(202, 150);
            this.mapYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mapYLabel.Name = "mapYLabel";
            this.mapYLabel.Size = new System.Drawing.Size(28, 14);
            this.mapYLabel.TabIndex = 11;
            this.mapYLabel.Text = "???";
            this.mapYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.helpLabel.Location = new System.Drawing.Point(10, 171);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(322, 21);
            this.helpLabel.TabIndex = 12;
            this.helpLabel.Text = "Drag the Dark Ages process icon anywhere on this window.";
            this.helpLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // StatusForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 201);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.mapYLabel);
            this.Controls.Add(this.mapXLabel);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.manaPercentLabel);
            this.Controls.Add(this.healthPercentLabel);
            this.Controls.Add(this.manaLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.mapYCaptionLabel);
            this.Controls.Add(this.mapXCaptionLabel);
            this.Controls.Add(this.mapCaptionLabel);
            this.Controls.Add(this.manaCaptionLabel);
            this.Controls.Add(this.manaPictureBox);
            this.Controls.Add(this.healthCaptionLabel);
            this.Controls.Add(this.healthPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "StatusForm";
            this.Text = "Status Window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Closed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.form_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.healthPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}