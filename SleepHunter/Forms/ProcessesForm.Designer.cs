using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ProcessesForm : Form
    {
        private IContainer components = null;
        private Panel pnlProcess;
        private ImageList ilsIcons;
        private ToolStrip toolStrip1;
        private ToolStripButton btnRefresh;
        public ListView lvwProcess;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessesForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("System Processes", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("User Processes", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Dark Ages Processes", System.Windows.Forms.HorizontalAlignment.Left);
            this.ilsIcons = new System.Windows.Forms.ImageList(this.components);
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.lvwProcess = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.pnlProcess.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilsIcons
            // 
            this.ilsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsIcons.ImageStream")));
            this.ilsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsIcons.Images.SetKeyName(0, "da-Main.ico");
            // 
            // pnlProcess
            // 
            this.pnlProcess.Controls.Add(this.lvwProcess);
            this.pnlProcess.Controls.Add(this.toolStrip1);
            this.pnlProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProcess.Location = new System.Drawing.Point(0, 0);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Padding = new System.Windows.Forms.Padding(5, 5, 4, 4);
            this.pnlProcess.Size = new System.Drawing.Size(581, 121);
            this.pnlProcess.TabIndex = 2;
            this.pnlProcess.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProcess_Paint);
            // 
            // lvwProcess
            // 
            this.lvwProcess.AllowDrop = true;
            this.lvwProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "System Processes";
            listViewGroup1.Name = "grpSystem";
            listViewGroup2.Header = "User Processes";
            listViewGroup2.Name = "grpUser";
            listViewGroup3.Header = "Dark Ages Processes";
            listViewGroup3.Name = "grpDA";
            this.lvwProcess.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lvwProcess.HideSelection = false;
            this.lvwProcess.LargeImageList = this.ilsIcons;
            this.lvwProcess.Location = new System.Drawing.Point(5, 47);
            this.lvwProcess.MultiSelect = false;
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(572, 70);
            this.lvwProcess.TabIndex = 3;
            this.lvwProcess.UseCompatibleStateImageBehavior = false;
            this.lvwProcess.View = System.Windows.Forms.View.Tile;
            this.lvwProcess.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwProcess_ItemDrag);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(572, 42);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(229, 36);
            this.btnRefresh.Text = " Refresh Processes";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ProcessesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 121);
            this.Controls.Add(this.pnlProcess);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Process Manager";
            this.Shown += new System.EventHandler(this.frmProcess_Shown);
            this.pnlProcess.ResumeLayout(false);
            this.pnlProcess.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}