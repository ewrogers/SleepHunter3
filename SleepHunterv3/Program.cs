// Decompiled with JetBrains decompiler
// Type: SleepHunterv3.Program
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;
using System.Windows.Forms;

#nullable disable
namespace SleepHunterv3;

internal static class Program
{
  [STAThread]
  private static void Main()
  {
    Application.EnableVisualStyles();
    Application.Run((Form) new frmMain());
  }
}
