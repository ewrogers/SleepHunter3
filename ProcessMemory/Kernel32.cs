// Decompiled with JetBrains decompiler
// Type: ProcessMemory.Kernel32
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace ProcessMemory;

public class Kernel32
{
  [DllImport("kernel32.dll")]
  public static extern IntPtr OpenProcess(
    uint dwDesiredAccess,
    bool bInheritHandle,
    uint dwProcessId);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern bool CloseHandle(ulong hObject);

  [DllImport("kernel32.dll")]
  public static extern int ReadProcessMemory(
    IntPtr hProcess,
    IntPtr lpBaseAddress,
    [In, Out] byte[] buffer,
    uint size,
    out IntPtr lpNumberOfBytesRead);

  [DllImport("kernel32.dll")]
  public static extern bool WriteProcessMemory(
    IntPtr hProcess,
    IntPtr lpBaseAddress,
    byte[] lpBuffer,
    uint nSize,
    out IntPtr lpNumberOfBytesWritten);

  [DllImport("kernel32.dll")]
  private static extern IntPtr VirtualAllocEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    UIntPtr dwSize,
    uint flAllocationType,
    uint flProtect);

  [DllImport("kernel32.dll")]
  private static extern bool VirtualFreeEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    UIntPtr dwSize,
    uint dwFreeType);

  [DllImport("kernel32.dll")]
  private static extern bool VirtualLock(IntPtr lpAddress, UIntPtr dwSize);

  [DllImport("kernel32.dll")]
  private static extern bool VirtualUnlock(IntPtr lpAddress, UIntPtr dwSize);

  [DllImport("kernel32.dll")]
  private static extern bool VirtualProtectEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    UIntPtr dwSize,
    uint flNewProtect,
    out uint lpflOldProtect);

  [DllImport("kernel32.dll")]
  private static extern uint VirtualQueryEx(
    IntPtr hProcess,
    IntPtr lpAddress,
    out MEMORY_BASIC_INFORMATION lpBuffer,
    UIntPtr dwLength);
}
