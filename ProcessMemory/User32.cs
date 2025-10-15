// Decompiled with JetBrains decompiler
// Type: ProcessMemory.User32
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace ProcessMemory;

public class User32
{
  [DllImport("user32.dll")]
  public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern uint GetWindowThreadProcessId(ulong hWnd, out uint lpdwProcessId);
}
