// Decompiled with JetBrains decompiler
// Type: SleepHunterv3.frmArgs
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SleepHunterv3;

public class frmArgs : Form
{
  public string[] ArgInput;
  public bool CancelSelected;
  public int MinArgCount;
  private IContainer components = (IContainer) null;
  private TextBox txtArgs;
  private Button cmdCancel;
  private Panel pnlHelp;
  private Label lblCaption;
  private Label lblTitle;
  private Label lblInvalid;
  public Button cmdAdd;

  public frmArgs(string argsTitle, string argsCaption)
  {
    this.InitializeComponent();
    this.lblTitle.Text = argsTitle;
    this.lblCaption.Text = argsCaption;
  }

  private void cmdCancel_Click(object sender, EventArgs e)
  {
    this.CancelSelected = true;
    this.ArgInput = (string[]) null;
    this.Hide();
  }

  private void cmdAdd_Click(object sender, EventArgs e) => this.AddCommand();

  private void AddCommand()
  {
    string[] strArray = this.txtArgs.Text.Trim().Split(',');
    bool flag = false;
    foreach (string str in strArray)
    {
      if (str.Trim() == "" | str == null && this.MinArgCount > 0)
        flag = true;
    }
    if (strArray.Length != this.MinArgCount | flag)
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

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmArgs));
    this.txtArgs = new TextBox();
    this.cmdAdd = new Button();
    this.cmdCancel = new Button();
    this.pnlHelp = new Panel();
    this.lblInvalid = new Label();
    this.lblCaption = new Label();
    this.lblTitle = new Label();
    this.pnlHelp.SuspendLayout();
    this.SuspendLayout();
    this.txtArgs.Location = new Point(12, 181);
    this.txtArgs.Multiline = true;
    this.txtArgs.Name = "txtArgs";
    this.txtArgs.Size = new Size(413, 59);
    this.txtArgs.TabIndex = 1;
    this.txtArgs.KeyDown += new KeyEventHandler(this.txtArgs_KeyDown);
    this.cmdAdd.AutoSize = true;
    this.cmdAdd.FlatStyle = FlatStyle.Popup;
    this.cmdAdd.Image = (Image) componentResourceManager.GetObject("cmdAdd.Image");
    this.cmdAdd.Location = new Point(12, 246);
    this.cmdAdd.Name = "cmdAdd";
    this.cmdAdd.Size = new Size(139, 28);
    this.cmdAdd.TabIndex = 2;
    this.cmdAdd.Text = "Add Command";
    this.cmdAdd.TextAlign = ContentAlignment.MiddleRight;
    this.cmdAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
    this.cmdAdd.Click += new EventHandler(this.cmdAdd_Click);
    this.cmdCancel.AutoSize = true;
    this.cmdCancel.FlatStyle = FlatStyle.Popup;
    this.cmdCancel.Image = (Image) componentResourceManager.GetObject("cmdCancel.Image");
    this.cmdCancel.Location = new Point(286, 246);
    this.cmdCancel.Name = "cmdCancel";
    this.cmdCancel.Size = new Size(139, 28);
    this.cmdCancel.TabIndex = 3;
    this.cmdCancel.Text = "Cancel";
    this.cmdCancel.TextAlign = ContentAlignment.MiddleRight;
    this.cmdCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
    this.cmdCancel.Click += new EventHandler(this.cmdCancel_Click);
    this.pnlHelp.BackColor = SystemColors.Window;
    this.pnlHelp.BorderStyle = BorderStyle.FixedSingle;
    this.pnlHelp.Controls.Add((Control) this.lblInvalid);
    this.pnlHelp.Controls.Add((Control) this.lblCaption);
    this.pnlHelp.Controls.Add((Control) this.lblTitle);
    this.pnlHelp.Location = new Point(12, 13);
    this.pnlHelp.Name = "pnlHelp";
    this.pnlHelp.Padding = new Padding(4);
    this.pnlHelp.Size = new Size(413, 162);
    this.pnlHelp.TabIndex = 4;
    this.lblInvalid.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.lblInvalid.ForeColor = Color.Red;
    this.lblInvalid.Location = new Point(8, 113);
    this.lblInvalid.Name = "lblInvalid";
    this.lblInvalid.Size = new Size(396, 43);
    this.lblInvalid.TabIndex = 2;
    this.lblInvalid.Text = "You entered invalid arguments for this function. Please enter valid arguments or consult the documentation for more information.";
    this.lblInvalid.TextAlign = ContentAlignment.MiddleCenter;
    this.lblInvalid.Visible = false;
    this.lblCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.lblCaption.Location = new Point(7, 30);
    this.lblCaption.Name = "lblCaption";
    this.lblCaption.Size = new Size(397, 83);
    this.lblCaption.TabIndex = 1;
    this.lblCaption.Text = "Command help text goes here.\r\n";
    this.lblTitle.AutoSize = true;
    this.lblTitle.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
    this.lblTitle.Location = new Point(7, 4);
    this.lblTitle.Name = "lblTitle";
    this.lblTitle.Size = new Size(95, 13);
    this.lblTitle.TabIndex = 0;
    this.lblTitle.Text = "Command Name";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(437, 286);
    this.Controls.Add((Control) this.pnlHelp);
    this.Controls.Add((Control) this.cmdCancel);
    this.Controls.Add((Control) this.cmdAdd);
    this.Controls.Add((Control) this.txtArgs);
    this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (frmArgs);
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = "Input Arguments";
    this.pnlHelp.ResumeLayout(false);
    this.pnlHelp.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
