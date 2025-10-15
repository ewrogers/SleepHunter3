// Decompiled with JetBrains decompiler
// Type: SleepHunterv3.frmOptions
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SleepHunterv3;

public class frmOptions : Form
{
  private IContainer components = (IContainer) null;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmOptions));
    this.SuspendLayout();
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(292, 273);
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Name = nameof (frmOptions);
    this.Text = nameof (frmOptions);
    this.ResumeLayout(false);
  }

  public frmOptions() => this.InitializeComponent();
}
