using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ProcessesForm : Form
    {
        private IContainer components = null;
        private Panel processPanel;
        private ImageList iconsImageList;
        private ToolStrip processToolStrip;
        private ToolStripButton refreshButton;
        public ListView processListView;

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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Dark Ages Windows", System.Windows.Forms.HorizontalAlignment.Left);
            this.iconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.processPanel = new System.Windows.Forms.Panel();
            this.processListView = new System.Windows.Forms.ListView();
            this.processToolStrip = new System.Windows.Forms.ToolStrip();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.processPanel.SuspendLayout();
            this.processToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconsImageList
            // 
            this.iconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsImageList.ImageStream")));
            this.iconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsImageList.Images.SetKeyName(0, "da-Main.ico");
            // 
            // processPanel
            // 
            this.processPanel.Controls.Add(this.processListView);
            this.processPanel.Controls.Add(this.processToolStrip);
            this.processPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processPanel.Location = new System.Drawing.Point(0, 0);
            this.processPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.processPanel.Name = "processPanel";
            this.processPanel.Padding = new System.Windows.Forms.Padding(6, 7, 5, 5);
            this.processPanel.Size = new System.Drawing.Size(524, 201);
            this.processPanel.TabIndex = 0;
            this.processPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.processPanel_Paint);
            // 
            // processListView
            // 
            this.processListView.AllowDrop = true;
            this.processListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewGroup1.Header = "Dark Ages Windows";
            listViewGroup1.Name = "darkagesGroup";
            this.processListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.processListView.HideSelection = false;
            this.processListView.LargeImageList = this.iconsImageList;
            this.processListView.Location = new System.Drawing.Point(6, 32);
            this.processListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.processListView.MultiSelect = false;
            this.processListView.Name = "processListView";
            this.processListView.Size = new System.Drawing.Size(513, 164);
            this.processListView.TabIndex = 1;
            this.processListView.UseCompatibleStateImageBehavior = false;
            this.processListView.View = System.Windows.Forms.View.Tile;
            this.processListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.processListView_ItemDrag);
            // 
            // processToolStrip
            // 
            this.processToolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.processToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshButton});
            this.processToolStrip.Location = new System.Drawing.Point(6, 7);
            this.processToolStrip.Name = "processToolStrip";
            this.processToolStrip.Size = new System.Drawing.Size(513, 25);
            this.processToolStrip.TabIndex = 0;
            this.processToolStrip.Text = "toolStrip1";
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(138, 22);
            this.refreshButton.Text = " Refresh Processes";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // ProcessesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 201);
            this.Controls.Add(this.processPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProcessesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Process Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProcessesForm_FormClosed);
            this.Shown += new System.EventHandler(this.form_Shown);
            this.processPanel.ResumeLayout(false);
            this.processPanel.PerformLayout();
            this.processToolStrip.ResumeLayout(false);
            this.processToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}