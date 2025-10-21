using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    partial class ArgumentsForm
    {
        private IContainer components = null;
        private Button cancelButton;
        private Panel helpPanel;
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
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.helpPanel = new System.Windows.Forms.Panel();
            this.validationLabel = new System.Windows.Forms.Label();
            this.helpTextLabel = new System.Windows.Forms.Label();
            this.commandNameLabel = new System.Windows.Forms.Label();
            this.operatorLabel = new System.Windows.Forms.Label();
            this.numericOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.numericValueLabel = new System.Windows.Forms.Label();
            this.numericValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.numericComparisonGroupBox = new System.Windows.Forms.GroupBox();
            this.stringComparisonGroupBox = new System.Windows.Forms.GroupBox();
            this.stringValueTextBox = new System.Windows.Forms.TextBox();
            this.stringCompareOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stringValueLabel = new System.Windows.Forms.Label();
            this.pointGroupBox = new System.Windows.Forms.GroupBox();
            this.xValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.yValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.keystrokesGroupBox = new System.Windows.Forms.GroupBox();
            this.keystrokesTextbox = new System.Windows.Forms.TextBox();
            this.argsAnchorPanel = new System.Windows.Forms.Panel();
            this.waitGroupBox = new System.Windows.Forms.GroupBox();
            this.waitNumeric = new System.Windows.Forms.NumericUpDown();
            this.waitLabel = new System.Windows.Forms.Label();
            this.waitUnitLabel = new System.Windows.Forms.Label();
            this.stringInputGroupBox = new System.Windows.Forms.GroupBox();
            this.stringInputLabel = new System.Windows.Forms.Label();
            this.stringInputTextBox = new System.Windows.Forms.TextBox();
            this.numericInputGroupBox = new System.Windows.Forms.GroupBox();
            this.numericInputLabel = new System.Windows.Forms.Label();
            this.numericInputNumeric = new System.Windows.Forms.NumericUpDown();
            this.helpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValueNumeric)).BeginInit();
            this.numericComparisonGroupBox.SuspendLayout();
            this.stringComparisonGroupBox.SuspendLayout();
            this.pointGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueNumeric)).BeginInit();
            this.keystrokesGroupBox.SuspendLayout();
            this.waitGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitNumeric)).BeginInit();
            this.stringInputGroupBox.SuspendLayout();
            this.numericInputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInputNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.AutoSize = true;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(14, 815);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 32);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add Command";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSize = true;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(269, 815);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(162, 32);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // helpPanel
            // 
            this.helpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpPanel.BackColor = System.Drawing.SystemColors.Window;
            this.helpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpPanel.Controls.Add(this.validationLabel);
            this.helpPanel.Controls.Add(this.helpTextLabel);
            this.helpPanel.Controls.Add(this.commandNameLabel);
            this.helpPanel.Location = new System.Drawing.Point(14, 15);
            this.helpPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Padding = new System.Windows.Forms.Padding(5);
            this.helpPanel.Size = new System.Drawing.Size(418, 187);
            this.helpPanel.TabIndex = 0;
            // 
            // validationLabel
            // 
            this.validationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validationLabel.ForeColor = System.Drawing.Color.Red;
            this.validationLabel.Location = new System.Drawing.Point(9, 130);
            this.validationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.validationLabel.Name = "validationLabel";
            this.validationLabel.Size = new System.Drawing.Size(399, 50);
            this.validationLabel.TabIndex = 2;
            this.validationLabel.Text = "Validation Error!";
            this.validationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.validationLabel.Visible = false;
            // 
            // helpTextLabel
            // 
            this.helpTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpTextLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTextLabel.Location = new System.Drawing.Point(8, 35);
            this.helpTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpTextLabel.Name = "helpTextLabel";
            this.helpTextLabel.Size = new System.Drawing.Size(400, 96);
            this.helpTextLabel.TabIndex = 1;
            this.helpTextLabel.Text = "Command help text goes here.\r\n";
            // 
            // commandNameLabel
            // 
            this.commandNameLabel.AutoSize = true;
            this.commandNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandNameLabel.Location = new System.Drawing.Point(8, 5);
            this.commandNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commandNameLabel.Name = "commandNameLabel";
            this.commandNameLabel.Size = new System.Drawing.Size(111, 17);
            this.commandNameLabel.TabIndex = 0;
            this.commandNameLabel.Text = "Command Name";
            // 
            // operatorLabel
            // 
            this.operatorLabel.AutoSize = true;
            this.operatorLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorLabel.Location = new System.Drawing.Point(11, 30);
            this.operatorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.operatorLabel.Name = "operatorLabel";
            this.operatorLabel.Size = new System.Drawing.Size(60, 14);
            this.operatorLabel.TabIndex = 0;
            this.operatorLabel.Text = "Operator:";
            // 
            // numericOperatorComboBox
            // 
            this.numericOperatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numericOperatorComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericOperatorComboBox.FormattingEnabled = true;
            this.numericOperatorComboBox.Items.AddRange(new object[] {
            "==",
            "!=",
            ">",
            ">=",
            "<",
            "<="});
            this.numericOperatorComboBox.Location = new System.Drawing.Point(79, 26);
            this.numericOperatorComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericOperatorComboBox.Name = "numericOperatorComboBox";
            this.numericOperatorComboBox.Size = new System.Drawing.Size(133, 24);
            this.numericOperatorComboBox.TabIndex = 1;
            // 
            // numericValueLabel
            // 
            this.numericValueLabel.AutoSize = true;
            this.numericValueLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericValueLabel.Location = new System.Drawing.Point(220, 30);
            this.numericValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numericValueLabel.Name = "numericValueLabel";
            this.numericValueLabel.Size = new System.Drawing.Size(41, 14);
            this.numericValueLabel.TabIndex = 2;
            this.numericValueLabel.Text = "Value:";
            // 
            // numericValueNumeric
            // 
            this.numericValueNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericValueNumeric.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericValueNumeric.Location = new System.Drawing.Point(269, 27);
            this.numericValueNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericValueNumeric.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericValueNumeric.Name = "numericValueNumeric";
            this.numericValueNumeric.Size = new System.Drawing.Size(140, 23);
            this.numericValueNumeric.TabIndex = 3;
            this.numericValueNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericValueNumeric.ThousandsSeparator = true;
            // 
            // numericComparisonGroupBox
            // 
            this.numericComparisonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericComparisonGroupBox.Controls.Add(this.numericOperatorComboBox);
            this.numericComparisonGroupBox.Controls.Add(this.numericValueNumeric);
            this.numericComparisonGroupBox.Controls.Add(this.operatorLabel);
            this.numericComparisonGroupBox.Controls.Add(this.numericValueLabel);
            this.numericComparisonGroupBox.Location = new System.Drawing.Point(12, 435);
            this.numericComparisonGroupBox.Name = "numericComparisonGroupBox";
            this.numericComparisonGroupBox.Size = new System.Drawing.Size(419, 68);
            this.numericComparisonGroupBox.TabIndex = 5;
            this.numericComparisonGroupBox.TabStop = false;
            this.numericComparisonGroupBox.Text = "Value Comparison";
            // 
            // stringComparisonGroupBox
            // 
            this.stringComparisonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringComparisonGroupBox.Controls.Add(this.stringValueTextBox);
            this.stringComparisonGroupBox.Controls.Add(this.stringCompareOperatorComboBox);
            this.stringComparisonGroupBox.Controls.Add(this.label1);
            this.stringComparisonGroupBox.Controls.Add(this.stringValueLabel);
            this.stringComparisonGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringComparisonGroupBox.Location = new System.Drawing.Point(13, 509);
            this.stringComparisonGroupBox.Name = "stringComparisonGroupBox";
            this.stringComparisonGroupBox.Size = new System.Drawing.Size(419, 104);
            this.stringComparisonGroupBox.TabIndex = 6;
            this.stringComparisonGroupBox.TabStop = false;
            this.stringComparisonGroupBox.Text = "Text Comparison";
            // 
            // stringValueTextBox
            // 
            this.stringValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringValueTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringValueTextBox.Location = new System.Drawing.Point(78, 62);
            this.stringValueTextBox.Name = "stringValueTextBox";
            this.stringValueTextBox.Size = new System.Drawing.Size(331, 25);
            this.stringValueTextBox.TabIndex = 3;
            // 
            // stringCompareOperatorComboBox
            // 
            this.stringCompareOperatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringCompareOperatorComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringCompareOperatorComboBox.FormattingEnabled = true;
            this.stringCompareOperatorComboBox.Items.AddRange(new object[] {
            "Equals",
            "Does Not Equal",
            "Contains",
            "Does Not Contain",
            "Starts With",
            "Does Not Start With",
            "Ends With",
            "Does Not End With",
            "Is Before",
            "Is After"});
            this.stringCompareOperatorComboBox.Location = new System.Drawing.Point(79, 26);
            this.stringCompareOperatorComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stringCompareOperatorComboBox.Name = "stringCompareOperatorComboBox";
            this.stringCompareOperatorComboBox.Size = new System.Drawing.Size(167, 24);
            this.stringCompareOperatorComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operator:";
            // 
            // stringValueLabel
            // 
            this.stringValueLabel.AutoSize = true;
            this.stringValueLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringValueLabel.Location = new System.Drawing.Point(29, 67);
            this.stringValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stringValueLabel.Name = "stringValueLabel";
            this.stringValueLabel.Size = new System.Drawing.Size(41, 14);
            this.stringValueLabel.TabIndex = 2;
            this.stringValueLabel.Text = "Value:";
            // 
            // pointGroupBox
            // 
            this.pointGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pointGroupBox.Controls.Add(this.xValueNumeric);
            this.pointGroupBox.Controls.Add(this.xValueLabel);
            this.pointGroupBox.Controls.Add(this.yValueNumeric);
            this.pointGroupBox.Controls.Add(this.yValueLabel);
            this.pointGroupBox.Location = new System.Drawing.Point(13, 619);
            this.pointGroupBox.Name = "pointGroupBox";
            this.pointGroupBox.Size = new System.Drawing.Size(419, 68);
            this.pointGroupBox.TabIndex = 7;
            this.pointGroupBox.TabStop = false;
            this.pointGroupBox.Text = "Point";
            // 
            // xValueNumeric
            // 
            this.xValueNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xValueNumeric.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xValueNumeric.Location = new System.Drawing.Point(101, 27);
            this.xValueNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.xValueNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xValueNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.xValueNumeric.Name = "xValueNumeric";
            this.xValueNumeric.Size = new System.Drawing.Size(100, 23);
            this.xValueNumeric.TabIndex = 1;
            this.xValueNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xValueLabel
            // 
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xValueLabel.Location = new System.Drawing.Point(11, 30);
            this.xValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(81, 14);
            this.xValueLabel.TabIndex = 0;
            this.xValueLabel.Text = "X Coordinate:";
            // 
            // yValueNumeric
            // 
            this.yValueNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yValueNumeric.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yValueNumeric.Location = new System.Drawing.Point(308, 27);
            this.yValueNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.yValueNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yValueNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.yValueNumeric.Name = "yValueNumeric";
            this.yValueNumeric.Size = new System.Drawing.Size(100, 23);
            this.yValueNumeric.TabIndex = 3;
            this.yValueNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yValueLabel
            // 
            this.yValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yValueLabel.AutoSize = true;
            this.yValueLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yValueLabel.Location = new System.Drawing.Point(218, 30);
            this.yValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(82, 14);
            this.yValueLabel.TabIndex = 2;
            this.yValueLabel.Text = "Y Coordinate:";
            // 
            // keystrokesGroupBox
            // 
            this.keystrokesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keystrokesGroupBox.Controls.Add(this.keystrokesTextbox);
            this.keystrokesGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keystrokesGroupBox.Location = new System.Drawing.Point(13, 693);
            this.keystrokesGroupBox.Name = "keystrokesGroupBox";
            this.keystrokesGroupBox.Size = new System.Drawing.Size(419, 112);
            this.keystrokesGroupBox.TabIndex = 8;
            this.keystrokesGroupBox.TabStop = false;
            this.keystrokesGroupBox.Text = "Keystrokes";
            // 
            // keystrokesTextbox
            // 
            this.keystrokesTextbox.AcceptsReturn = true;
            this.keystrokesTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keystrokesTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keystrokesTextbox.Location = new System.Drawing.Point(12, 22);
            this.keystrokesTextbox.Multiline = true;
            this.keystrokesTextbox.Name = "keystrokesTextbox";
            this.keystrokesTextbox.Size = new System.Drawing.Size(396, 76);
            this.keystrokesTextbox.TabIndex = 0;
            // 
            // argsAnchorPanel
            // 
            this.argsAnchorPanel.Location = new System.Drawing.Point(12, 209);
            this.argsAnchorPanel.Name = "argsAnchorPanel";
            this.argsAnchorPanel.Size = new System.Drawing.Size(24, 26);
            this.argsAnchorPanel.TabIndex = 1;
            this.argsAnchorPanel.Visible = false;
            // 
            // waitGroupBox
            // 
            this.waitGroupBox.Controls.Add(this.waitUnitLabel);
            this.waitGroupBox.Controls.Add(this.waitLabel);
            this.waitGroupBox.Controls.Add(this.waitNumeric);
            this.waitGroupBox.Location = new System.Drawing.Point(14, 361);
            this.waitGroupBox.Name = "waitGroupBox";
            this.waitGroupBox.Size = new System.Drawing.Size(419, 68);
            this.waitGroupBox.TabIndex = 4;
            this.waitGroupBox.TabStop = false;
            this.waitGroupBox.Text = "Time";
            // 
            // waitNumeric
            // 
            this.waitNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waitNumeric.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitNumeric.Location = new System.Drawing.Point(79, 26);
            this.waitNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.waitNumeric.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.waitNumeric.Name = "waitNumeric";
            this.waitNumeric.Size = new System.Drawing.Size(131, 23);
            this.waitNumeric.TabIndex = 1;
            this.waitNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waitNumeric.ThousandsSeparator = true;
            // 
            // waitLabel
            // 
            this.waitLabel.AutoSize = true;
            this.waitLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLabel.Location = new System.Drawing.Point(12, 30);
            this.waitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(40, 14);
            this.waitLabel.TabIndex = 0;
            this.waitLabel.Text = "Delay:";
            // 
            // waitUnitLabel
            // 
            this.waitUnitLabel.AutoSize = true;
            this.waitUnitLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitUnitLabel.Location = new System.Drawing.Point(218, 30);
            this.waitUnitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.waitUnitLabel.Name = "waitUnitLabel";
            this.waitUnitLabel.Size = new System.Drawing.Size(69, 14);
            this.waitUnitLabel.TabIndex = 2;
            this.waitUnitLabel.Text = "milliseconds";
            // 
            // stringInputGroupBox
            // 
            this.stringInputGroupBox.Controls.Add(this.stringInputTextBox);
            this.stringInputGroupBox.Controls.Add(this.stringInputLabel);
            this.stringInputGroupBox.Location = new System.Drawing.Point(13, 287);
            this.stringInputGroupBox.Name = "stringInputGroupBox";
            this.stringInputGroupBox.Size = new System.Drawing.Size(419, 68);
            this.stringInputGroupBox.TabIndex = 3;
            this.stringInputGroupBox.TabStop = false;
            this.stringInputGroupBox.Text = "Text";
            // 
            // stringInputLabel
            // 
            this.stringInputLabel.AutoSize = true;
            this.stringInputLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringInputLabel.Location = new System.Drawing.Point(12, 30);
            this.stringInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stringInputLabel.Name = "stringInputLabel";
            this.stringInputLabel.Size = new System.Drawing.Size(41, 14);
            this.stringInputLabel.TabIndex = 0;
            this.stringInputLabel.Text = "Value:";
            // 
            // stringInputTextBox
            // 
            this.stringInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stringInputTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringInputTextBox.Location = new System.Drawing.Point(77, 25);
            this.stringInputTextBox.Name = "stringInputTextBox";
            this.stringInputTextBox.Size = new System.Drawing.Size(331, 25);
            this.stringInputTextBox.TabIndex = 1;
            // 
            // numericInputGroupBox
            // 
            this.numericInputGroupBox.Controls.Add(this.numericInputNumeric);
            this.numericInputGroupBox.Controls.Add(this.numericInputLabel);
            this.numericInputGroupBox.Location = new System.Drawing.Point(12, 213);
            this.numericInputGroupBox.Name = "numericInputGroupBox";
            this.numericInputGroupBox.Size = new System.Drawing.Size(419, 68);
            this.numericInputGroupBox.TabIndex = 2;
            this.numericInputGroupBox.TabStop = false;
            this.numericInputGroupBox.Text = "Number";
            // 
            // numericInputLabel
            // 
            this.numericInputLabel.AutoSize = true;
            this.numericInputLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericInputLabel.Location = new System.Drawing.Point(12, 30);
            this.numericInputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numericInputLabel.Name = "numericInputLabel";
            this.numericInputLabel.Size = new System.Drawing.Size(41, 14);
            this.numericInputLabel.TabIndex = 0;
            this.numericInputLabel.Text = "Value:";
            // 
            // numericInputNumeric
            // 
            this.numericInputNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericInputNumeric.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericInputNumeric.Location = new System.Drawing.Point(81, 27);
            this.numericInputNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericInputNumeric.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericInputNumeric.Name = "numericInputNumeric";
            this.numericInputNumeric.Size = new System.Drawing.Size(131, 23);
            this.numericInputNumeric.TabIndex = 1;
            this.numericInputNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericInputNumeric.ThousandsSeparator = true;
            // 
            // ArgumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 861);
            this.Controls.Add(this.numericInputGroupBox);
            this.Controls.Add(this.stringInputGroupBox);
            this.Controls.Add(this.waitGroupBox);
            this.Controls.Add(this.keystrokesGroupBox);
            this.Controls.Add(this.pointGroupBox);
            this.Controls.Add(this.stringComparisonGroupBox);
            this.Controls.Add(this.numericComparisonGroupBox);
            this.Controls.Add(this.argsAnchorPanel);
            this.Controls.Add(this.helpPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArgumentsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Arguments";
            this.helpPanel.ResumeLayout(false);
            this.helpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValueNumeric)).EndInit();
            this.numericComparisonGroupBox.ResumeLayout(false);
            this.numericComparisonGroupBox.PerformLayout();
            this.stringComparisonGroupBox.ResumeLayout(false);
            this.stringComparisonGroupBox.PerformLayout();
            this.pointGroupBox.ResumeLayout(false);
            this.pointGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValueNumeric)).EndInit();
            this.keystrokesGroupBox.ResumeLayout(false);
            this.keystrokesGroupBox.PerformLayout();
            this.waitGroupBox.ResumeLayout(false);
            this.waitGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitNumeric)).EndInit();
            this.stringInputGroupBox.ResumeLayout(false);
            this.stringInputGroupBox.PerformLayout();
            this.numericInputGroupBox.ResumeLayout(false);
            this.numericInputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInputNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label operatorLabel;
        private ComboBox numericOperatorComboBox;
        private Label numericValueLabel;
        private NumericUpDown numericValueNumeric;
        private GroupBox numericComparisonGroupBox;
        private GroupBox stringComparisonGroupBox;
        private TextBox stringValueTextBox;
        private ComboBox stringCompareOperatorComboBox;
        private Label label1;
        private Label stringValueLabel;
        private GroupBox pointGroupBox;
        private NumericUpDown yValueNumeric;
        private Label yValueLabel;
        private NumericUpDown xValueNumeric;
        private Label xValueLabel;
        private GroupBox keystrokesGroupBox;
        private TextBox keystrokesTextbox;
        private Panel argsAnchorPanel;
        private GroupBox waitGroupBox;
        private Label waitUnitLabel;
        private Label waitLabel;
        private NumericUpDown waitNumeric;
        private GroupBox stringInputGroupBox;
        private TextBox stringInputTextBox;
        private Label stringInputLabel;
        private GroupBox numericInputGroupBox;
        private NumericUpDown numericInputNumeric;
        private Label numericInputLabel;
    }
}