using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    partial class frmOptions
    {
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.SuspendLayout();
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Icon = ((System.Drawing.Icon)(componentResourceManager.GetObject("$this.Icon")));
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.ResumeLayout(false);
        }
    }
}
