using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    public partial class frmArgs : Form
    {
        public string[] ArgInput;
        public bool CancelSelected;
        public int MinArgCount;

        public frmArgs(string argsTitle, string argsCaption)
        {
            InitializeComponent();
            this.lblTitle.Text = argsTitle;
            this.lblCaption.Text = argsCaption;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.CancelSelected = true;
            this.ArgInput = null;
            this.Hide();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            this.AddCommand();
        }

        private void AddCommand()
        {
            string[] strArray = this.txtArgs.Text.Trim().Split(',');
            bool flag = false;
            foreach (string str in strArray)
            {
                if ((str == null || str.Trim() == "") && this.MinArgCount > 0)
                    flag = true;
            }
            if (strArray.Length != this.MinArgCount || flag)
            {
                this.lblInvalid.Visible = true;
            }
            else
            {
                this.CancelSelected = false;
                this.ArgInput = strArray;
                this.Hide();
            }
        }

        private void txtArgs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            e.SuppressKeyPress = true;
            this.AddCommand();
        }
    }
}