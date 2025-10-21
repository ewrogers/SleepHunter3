using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class ArgumentsForm
    {
        private IContainer components = null;
        private TextBox argumentsTextBox;
        private Button cancelButton;
        private Panel pnlHelp;
        private Label helpTextLabel;
        private Label commandNameLabel;
        private Label validationLabel;
        internal Button addButton;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArgumentsForm));
            this.argumentsTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.validationLabel = new System.Windows.Forms.Label();
            this.helpTextLabel = new System.Windows.Forms.Label();
            this.commandNameLabel = new System.Windows.Forms.Label();
            this.pnlHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // argumentsTextBox
            // 
            this.argumentsTextBox.Location = new System.Drawing.Point(12, 181);
            this.argumentsTextBox.Multiline = true;
            this.argumentsTextBox.Name = "argumentsTextBox";
            this.argumentsTextBox.Size = new System.Drawing.Size(413, 59);
            this.argumentsTextBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(12, 246);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(139, 28);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add Command";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(286, 246);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(139, 28);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.SystemColors.Window;
            this.pnlHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHelp.Controls.Add(this.validationLabel);
            this.pnlHelp.Controls.Add(this.helpTextLabel);
            this.pnlHelp.Controls.Add(this.commandNameLabel);
            this.pnlHelp.Location = new System.Drawing.Point(12, 13);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Padding = new System.Windows.Forms.Padding(4);
            this.pnlHelp.Size = new System.Drawing.Size(413, 162);
            this.pnlHelp.TabIndex = 4;
            // 
            // validationLabel
            // 
            this.validationLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validationLabel.ForeColor = System.Drawing.Color.Red;
            this.validationLabel.Location = new System.Drawing.Point(8, 113);
            this.validationLabel.Name = "validationLabel";
            this.validationLabel.Size = new System.Drawing.Size(396, 43);
            this.validationLabel.TabIndex = 2;
            this.validationLabel.Text = "You entered invalid arguments for this function. Please enter valid arguments or " +
    "consult the documentation for more information.";
            this.validationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.validationLabel.Visible = false;
            // 
            // helpTextLabel
            // 
            this.helpTextLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTextLabel.Location = new System.Drawing.Point(7, 30);
            this.helpTextLabel.Name = "helpTextLabel";
            this.helpTextLabel.Size = new System.Drawing.Size(397, 83);
            this.helpTextLabel.TabIndex = 1;
            this.helpTextLabel.Text = "Command help text goes here.\r\n";
            // 
            // commandNameLabel
            // 
            this.commandNameLabel.AutoSize = true;
            this.commandNameLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandNameLabel.Location = new System.Drawing.Point(7, 4);
            this.commandNameLabel.Name = "commandNameLabel";
            this.commandNameLabel.Size = new System.Drawing.Size(99, 13);
            this.commandNameLabel.TabIndex = 0;
            this.commandNameLabel.Text = "Command Name";
            // 
            // ArgumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 286);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.argumentsTextBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArgumentsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Arguments";
            this.pnlHelp.ResumeLayout(false);
            this.pnlHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}