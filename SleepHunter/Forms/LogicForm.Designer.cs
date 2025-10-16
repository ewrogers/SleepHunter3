using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class LogicForm
    {
        private IContainer components = null;
        private TabControl tabSkeleton;
        private TabPage tpgStruct;
        internal RichTextBox rtbStruct;

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
            this.components = (IContainer)new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogicForm));
            this.tabSkeleton = new System.Windows.Forms.TabControl();
            this.tpgStruct = new System.Windows.Forms.TabPage();
            this.rtbStruct = new System.Windows.Forms.RichTextBox();
            this.tabSkeleton.SuspendLayout();
            this.tpgStruct.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSkeleton
            // 
            this.tabSkeleton.Controls.Add(this.tpgStruct);
            this.tabSkeleton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSkeleton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSkeleton.Location = new System.Drawing.Point(4, 4);
            this.tabSkeleton.Name = "tabSkeleton";
            this.tabSkeleton.SelectedIndex = 0;
            this.tabSkeleton.Size = new System.Drawing.Size(297, 445);
            this.tabSkeleton.TabIndex = 0;
            // 
            // tpgStruct
            // 
            this.tpgStruct.Controls.Add(this.rtbStruct);
            this.tpgStruct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgStruct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgStruct.Location = new System.Drawing.Point(4, 22);
            this.tpgStruct.Name = "tpgStruct";
            this.tpgStruct.Padding = new System.Windows.Forms.Padding(3);
            this.tpgStruct.Size = new System.Drawing.Size(289, 419);
            this.tpgStruct.TabIndex = 1;
            this.tpgStruct.Text = "Structure View";
            // 
            // rtbStruct
            // 
            this.rtbStruct.BackColor = System.Drawing.SystemColors.Window;
            this.rtbStruct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbStruct.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStruct.Location = new System.Drawing.Point(3, 3);
            this.rtbStruct.Name = "rtbStruct";
            this.rtbStruct.ReadOnly = true;
            this.rtbStruct.Size = new System.Drawing.Size(283, 413);
            this.rtbStruct.TabIndex = 0;
            this.rtbStruct.Text = "";
            // 
            // LogicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 453);
            this.Controls.Add(this.tabSkeleton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogicForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logic Skeleton [Debug]";
            this.tabSkeleton.ResumeLayout(false);
            this.tpgStruct.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
