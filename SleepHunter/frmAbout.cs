using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SleepHunter
{

    internal class frmAbout : Form
    {
        private IContainer components = (IContainer)null;
        private Label lblVersion;
        private Label lblThanks;
        private GroupBox Seperator;
        private Label label1;
        private Label label2;
        private WebBrowser webDonate;
        private Label lblAuthor;
        private Label label3;
        private Label label4;

        public frmAbout() => this.InitializeComponent();

        private void frmAbout_Load(object sender, EventArgs e)
        {
        }

        private void frmAbout_Shown(object sender, EventArgs e)
        {
            if (File.Exists("donate.htm"))
            {
                File.SetAttributes("donate.htm", FileAttributes.Normal);
                File.Delete("donate.htm");
            }
            StreamWriter streamWriter = new StreamWriter("donate.htm");
            streamWriter.WriteLine("<html>");
            streamWriter.WriteLine("<head>");
            streamWriter.WriteLine("<title>Donate to SleepHunterv3</title>");
            streamWriter.WriteLine("</head>");
            streamWriter.WriteLine("<body><body bgcolor=\"black\">");
            streamWriter.WriteLine("<form action=\"https://www.paypal.com/cgi-bin/webscr\" method=\"post\" target=\"paypal\">");
            streamWriter.WriteLine("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
            streamWriter.WriteLine("<input type=\"image\" src=\"https://www.paypal.com/en_US/i/btn/x-click-but04.gif\" border=\"0\" name=\"submit\" alt=\"Make payments with PayPal - it's fast, free and secure!\">");
            streamWriter.WriteLine("<input type=\"hidden\" name=\"encrypted\" value=\"-----BEGIN PKCS7-----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-----END PKCS7-----\">");
            streamWriter.WriteLine("</form>");
            streamWriter.WriteLine("</body>");
            streamWriter.WriteLine("</html>");
            streamWriter.Flush();
            streamWriter.Close();
            File.SetAttributes("donate.htm", FileAttributes.ReadOnly | FileAttributes.Hidden);
            this.webDonate.Navigate(Application.StartupPath + "\\donate.htm");
        }

        private void webDonate_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.webDonate.Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAbout));
            this.lblVersion = new Label();
            this.lblThanks = new Label();
            this.Seperator = new GroupBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.webDonate = new WebBrowser();
            this.lblAuthor = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.SuspendLayout();
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = Color.FromArgb(192 /*0xC0*/, (int)byte.MaxValue, (int)byte.MaxValue);
            this.lblVersion.Location = new Point(401, 328);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new Size(58, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Beta 1.2.5";
            this.lblThanks.AutoSize = true;
            this.lblThanks.ForeColor = Color.White;
            this.lblThanks.Location = new Point(19, 351);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new Size(94, 13);
            this.lblThanks.TabIndex = 2;
            this.lblThanks.Text = "Special Thanks to:";
            this.Seperator.Enabled = false;
            this.Seperator.FlatStyle = FlatStyle.System;
            this.Seperator.Location = new Point(13, 344);
            this.Seperator.Name = "Seperator";
            this.Seperator.Size = new Size(455, 4);
            this.Seperator.TabIndex = 3;
            this.Seperator.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.Silver;
            this.label1.Location = new Point(19, 364);
            this.label1.Name = "label1";
            this.label1.Size = new Size(102, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Eru -- Chat Pointers";
            this.label2.AutoSize = true;
            this.label2.ForeColor = Color.FromArgb(192 /*0xC0*/, (int)byte.MaxValue, (int)byte.MaxValue);
            this.label2.Location = new Point(19, 328);
            this.label2.Name = "label2";
            this.label2.Size = new Size(352, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Currently Developed By: Brandon 'saytheb' Blank -- saytheb@gmail.com";
            this.webDonate.AllowWebBrowserDrop = false;
            this.webDonate.IsWebBrowserContextMenuEnabled = false;
            this.webDonate.Location = new Point(381, 353);
            this.webDonate.Name = "webDonate";
            this.webDonate.ScriptErrorsSuppressed = true;
            this.webDonate.ScrollBarsEnabled = false;
            this.webDonate.Size = new Size(87, 48 /*0x30*/);
            this.webDonate.TabIndex = 0;
            this.webDonate.Url = new Uri("http://eriknet.no-ip.com", UriKind.Absolute);
            this.webDonate.Visible = false;
            this.webDonate.WebBrowserShortcutsEnabled = false;
            this.webDonate.Navigated += new WebBrowserNavigatedEventHandler(this.webDonate_Navigated);
            this.lblAuthor.ForeColor = Color.FromArgb(192 /*0xC0*/, 192 /*0xC0*/, (int)byte.MaxValue);
            this.lblAuthor.Location = new Point(186, 353);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new Size(189, 45);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Originally Developed By: Erik 'SiLo' Rogers -- ewrogers@gmail.com -- http://eriknet.no-ip.com";
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.ForeColor = Color.Silver;
            this.label3.Location = new Point(19, 377);
            this.label3.Name = "label3";
            this.label3.Size = new Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Swinky-- Chat Pointers";
            this.label4.ForeColor = Color.Silver;
            this.label4.Location = new Point(19, 404);
            this.label4.Name = "label4";
            this.label4.Size = new Size(440, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Updates (11/29/05): Fixed HP/MP, Map Name, XLoc, YLoc. Chat Disabled due to errors with new DA version.";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.None;
            this.ClientSize = new Size(480, 436);
            this.Controls.Add((Control)this.label4);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.webDonate);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.Seperator);
            this.Controls.Add((Control)this.lblThanks);
            this.Controls.Add((Control)this.lblAuthor);
            this.Controls.Add((Control)this.lblVersion);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmAbout);
            this.Padding = new Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "About SleepHunter";
            this.Shown += new EventHandler(this.frmAbout_Shown);
            this.Load += new EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}