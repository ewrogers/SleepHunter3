using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter
{
    public class frmLogicSkel : Form
    {
        private IContainer components = (IContainer)null;
        private TabControl tabSkeleton;
        private TabPage tpgStruct;
        public RichTextBox rtbStruct;

        public frmLogicSkel() => this.InitializeComponent();

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLogicSkel));
            this.tabSkeleton = new TabControl();
            this.tpgStruct = new TabPage();
            this.rtbStruct = new RichTextBox();
            this.tabSkeleton.SuspendLayout();
            this.tpgStruct.SuspendLayout();
            this.SuspendLayout();
            this.tabSkeleton.Controls.Add((Control)this.tpgStruct);
            this.tabSkeleton.Dock = DockStyle.Fill;
            this.tabSkeleton.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.tabSkeleton.Location = new Point(4, 4);
            this.tabSkeleton.Name = "tabSkeleton";
            this.tabSkeleton.SelectedIndex = 0;
            this.tabSkeleton.Size = new Size(297, 445);
            this.tabSkeleton.TabIndex = 0;
            this.tpgStruct.Controls.Add((Control)this.rtbStruct);
            this.tpgStruct.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.tpgStruct.ForeColor = SystemColors.ControlText;
            this.tpgStruct.Location = new Point(4, 22);
            this.tpgStruct.Name = "tpgStruct";
            this.tpgStruct.Padding = new Padding(3);
            this.tpgStruct.Size = new Size(289, 419);
            this.tpgStruct.TabIndex = 1;
            this.tpgStruct.Text = "Structure View";
            this.rtbStruct.BackColor = SystemColors.Window;
            this.rtbStruct.Dock = DockStyle.Fill;
            this.rtbStruct.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.rtbStruct.Location = new Point(3, 3);
            this.rtbStruct.Name = "rtbStruct";
            this.rtbStruct.ReadOnly = true;
            this.rtbStruct.Size = new Size(283, 413);
            this.rtbStruct.TabIndex = 0;
            this.rtbStruct.Text = "";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(305, 453);
            this.Controls.Add((Control)this.tabSkeleton);
            this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmLogicSkel);
            this.Padding = new Padding(4);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Logic Skeleton [Debug]";
            this.tabSkeleton.ResumeLayout(false);
            this.tpgStruct.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}