using System;
using System.IO;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    internal partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

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
            streamWriter.WriteLine("</form>");
            streamWriter.WriteLine("</body>");
            streamWriter.WriteLine("</html>");
            streamWriter.Flush();
            streamWriter.Close();
            File.SetAttributes("donate.htm", FileAttributes.ReadOnly | FileAttributes.Hidden);
            webDonate.Navigate(Application.StartupPath + "\\donate.htm");
        }

        private void webDonate_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            webDonate.Visible = true;
        }
    }
}