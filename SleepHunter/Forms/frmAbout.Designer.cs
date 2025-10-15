using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class frmAbout
    {
        private IContainer components = null;
        private Label lblVersion;
        private Label lblThanks;
        private GroupBox Seperator;
        private Label label1;
        private Label label2;
        private WebBrowser webDonate;
        private Label lblAuthor;
        private Label label3;
        private Label label4;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));

            this.lblVersion = new System.Windows.Forms.Label();
            this.lblThanks = new System.Windows.Forms.Label();
            this.Seperator = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.webDonate = new System.Windows.Forms.WebBrowser();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(192, 255, 255);
            this.lblVersion.Location = new System.Drawing.Point(401, 328);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(58, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Beta 1.2.5";
            // 
            // lblThanks
            // 
            this.lblThanks.AutoSize = true;
            this.lblThanks.ForeColor = System.Drawing.Color.White;
            this.lblThanks.Location = new System.Drawing.Point(19, 351);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(94, 13);
            this.lblThanks.TabIndex = 2;
            this.lblThanks.Text = "Special Thanks to:";
            // 
            // Seperator
            // 
            this.Seperator.Enabled = false;
            this.Seperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Seperator.Location = new System.Drawing.Point(13, 344);
            this.Seperator.Name = "Seperator";
            this.Seperator.Size = new System.Drawing.Size(455, 4);
            this.Seperator.TabIndex = 3;
            this.Seperator.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(19, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Eru -- Chat Pointers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(192, 255, 255);
            this.label2.Location = new System.Drawing.Point(19, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Currently Developed By: Brandon 'saytheb' Blank -- saytheb@gmail.com";
            // 
            // webDonate
            // 
            this.webDonate.AllowWebBrowserDrop = false;
            this.webDonate.IsWebBrowserContextMenuEnabled = false;
            this.webDonate.Location = new System.Drawing.Point(381, 353);
            this.webDonate.Name = "webDonate";
            this.webDonate.ScriptErrorsSuppressed = true;
            this.webDonate.ScrollBarsEnabled = false;
            this.webDonate.Size = new System.Drawing.Size(87, 48);
            this.webDonate.TabIndex = 0;
            this.webDonate.Url = new System.Uri("http://eriknet.no-ip.com", System.UriKind.Absolute);
            this.webDonate.Visible = false;
            this.webDonate.WebBrowserShortcutsEnabled = false;
            this.webDonate.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webDonate_Navigated);
            // 
            // lblAuthor
            // 
            this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(192, 192, 255);
            this.lblAuthor.Location = new System.Drawing.Point(186, 353);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(189, 45);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Originally Developed By: Erik 'SiLo' Rogers -- ewrogers@gmail.com -- http://eriknet.no-ip.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(19, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Swinky-- Chat Pointers";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(19, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(440, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Updates (11/29/05): Fixed HP/MP, Map Name, XLoc, YLoc. Chat Disabled due to errors with new DA version.";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(480, 436);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.webDonate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Seperator);
            this.Controls.Add(this.lblThanks);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblVersion);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About SleepHunter";
            this.Shown += new System.EventHandler(this.frmAbout_Shown);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}