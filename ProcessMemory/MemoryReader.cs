// Decompiled with JetBrains decompiler
// Type: ProcessMemory.MemoryReader
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace ProcessMemory;

public class MemoryReader
{
  private uint m_ProcessID;
  private ulong m_WindowHandle;
  private bool m_IsAttached;
  private ulong m_ProcHandle;

  public MemoryReader()
  {
    this.m_ProcessID = 0U;
    this.m_WindowHandle = 0UL;
    this.m_IsAttached = false;
  }

  public MemoryReader(ulong WindowHandle)
  {
    this.m_WindowHandle = WindowHandle;
    int windowThreadProcessId = (int) User32.GetWindowThreadProcessId(WindowHandle, out this.m_ProcessID);
    if (this.m_ProcessID == 0U)
      return;
    this.AttachByPID(this.m_ProcessID);
  }

  public MemoryReader(uint ProcessID)
  {
    foreach (Process process in Process.GetProcesses())
    {
      if ((long) process.Id == (long) ProcessID)
      {
        this.m_ProcessID = (uint) process.Id;
        this.m_WindowHandle = (ulong) (long) process.MainWindowHandle;
        this.AttachByPID(this.m_ProcessID);
      }
    }
  }

  public MemoryReader(string WindowTitle)
  {
    foreach (Process process in Process.GetProcesses())
    {
      if (process.MainWindowTitle == WindowTitle)
      {
        this.m_ProcessID = (uint) process.Id;
        this.m_WindowHandle = (ulong) (long) process.MainWindowHandle;
        this.AttachByPID(this.m_ProcessID);
      }
    }
  }

  ~MemoryReader()
  {
    if (this.m_ProcHandle == 0UL)
      return;
    Kernel32.CloseHandle(this.m_ProcHandle);
  }

  public ulong ProcHandle => this.m_ProcHandle;

  public uint ProcessID => this.m_ProcessID;

  public ulong WindowHandle => this.m_WindowHandle;

  public string WindowTitle
  {
    get
    {
      if (this.m_WindowHandle == 0UL)
        return string.Empty;
      foreach (Process process in Process.GetProcesses())
      {
        if (process.MainWindowHandle == (IntPtr) (long) this.m_WindowHandle)
          return process.MainWindowTitle;
      }
      return string.Empty;
    }
  }

  public string ProcessName
  {
    get
    {
      if (this.m_ProcessID == 0U)
        return string.Empty;
      foreach (Process process in Process.GetProcesses())
      {
        if ((long) process.Id == (long) this.m_ProcessID)
          return process.ProcessName + ".exe";
      }
      return string.Empty;
    }
  }

  public bool IsAttached => this.m_IsAttached;

  public bool IsRunning => this.IsProcessRunning(this.m_ProcessID, this.ProcessName);

  public bool AttachByPID(uint ProcessID)
  {
    if (this.m_ProcHandle != 0UL)
      Kernel32.CloseHandle(this.m_ProcHandle);
    this.m_ProcHandle = (ulong) (long) Kernel32.OpenProcess(2035711U, false, ProcessID);
    this.m_IsAttached = this.m_ProcHandle != 0UL;
    return this.m_IsAttached;
  }

  public bool AttachByHwnd(ulong WindowHandle)
  {
    if (this.m_ProcHandle != 0UL)
      Kernel32.CloseHandle(this.m_ProcHandle);
    this.m_WindowHandle = WindowHandle;
    int windowThreadProcessId = (int) User32.GetWindowThreadProcessId(WindowHandle, out this.m_ProcessID);
    this.m_ProcHandle = (ulong) (long) Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
    this.m_IsAttached = this.m_ProcHandle != 0UL;
    return this.m_IsAttached;
  }

  public bool AttachByWinTitle(string WinTitle)
  {
    if (this.m_ProcHandle != 0UL)
      Kernel32.CloseHandle(this.m_ProcHandle);
    foreach (Process process in Process.GetProcesses())
    {
      if (process.MainWindowTitle == this.WindowTitle)
      {
        this.m_ProcessID = (uint) process.Id;
        this.m_WindowHandle = (ulong) (long) process.MainWindowHandle;
      }
    }
    this.m_ProcHandle = (ulong) (long) Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
    this.m_IsAttached = this.m_ProcHandle != 0UL;
    return this.m_IsAttached;
  }

  public bool AttachByEXEName(string EXEName)
  {
    if (this.m_ProcHandle != 0UL)
      Kernel32.CloseHandle(this.m_ProcHandle);
    foreach (Process process in Process.GetProcesses())
    {
      if ((process.ProcessName + ".exe").ToUpper() == EXEName.ToUpper())
      {
        this.m_ProcessID = (uint) process.Id;
        this.m_WindowHandle = (ulong) (long) process.MainWindowHandle;
      }
    }
    this.m_ProcHandle = (ulong) (long) Kernel32.OpenProcess(2035711U, false, this.m_ProcessID);
    this.m_IsAttached = this.m_ProcHandle != 0UL;
    return this.m_IsAttached;
  }

  public bool DetachProcess()
  {
    bool flag;
    if (this.m_ProcHandle != 0UL)
    {
      Kernel32.CloseHandle(this.m_ProcHandle);
      flag = true;
    }
    else
      flag = false;
    this.m_IsAttached = false;
    this.m_ProcessID = 0U;
    this.m_ProcHandle = 0UL;
    this.m_WindowHandle = 0UL;
    return flag;
  }

  private bool IsProcessRunning(uint ProcessID, string EXEName)
  {
    foreach (Process process in Process.GetProcesses())
    {
      if ((long) process.Id == (long) this.ProcessID & process.ProcessName + ".exe" == this.ProcessName)
        return true;
    }
    return false;
  }

  private byte[] ReadProcessMemory(IntPtr BaseAddress, uint BytesToRead, out int BytesRead)
  {
    byte[] buffer = new byte[(IntPtr) BytesToRead];
    IntPtr lpNumberOfBytesRead;
    Kernel32.ReadProcessMemory((IntPtr) (long) this.m_ProcHandle, BaseAddress, buffer, BytesToRead, out lpNumberOfBytesRead);
    BytesRead = lpNumberOfBytesRead.ToInt32();
    return buffer;
  }

  public byte ReadUByte(IntPtr BaseAddress)
  {
    return this.ReadProcessMemory(BaseAddress, 1U, out int _)[0];
  }

  public sbyte ReadByte(IntPtr BaseAddress)
  {
    return (sbyte) this.ReadProcessMemory(BaseAddress, 1U, out int _)[0];
  }

  public ushort ReadUInt16(IntPtr BaseAddress)
  {
    return BitConverter.ToUInt16(this.ReadProcessMemory(BaseAddress, 2U, out int _), 0);
  }

  public short ReadInt16(IntPtr BaseAddress)
  {
    return BitConverter.ToInt16(this.ReadProcessMemory(BaseAddress, 2U, out int _), 0);
  }

  public uint ReadUInt32(IntPtr BaseAddress)
  {
    return BitConverter.ToUInt32(this.ReadProcessMemory(BaseAddress, 4U, out int _), 0);
  }

  public int ReadInt32(IntPtr BaseAddress)
  {
    return BitConverter.ToInt32(this.ReadProcessMemory(BaseAddress, 4U, out int _), 0);
  }

  public ulong ReadUInt64(IntPtr BaseAddress)
  {
    return BitConverter.ToUInt64(this.ReadProcessMemory(BaseAddress, 8U, out int _), 0);
  }

  public long ReadInt64(IntPtr BaseAddress)
  {
    return BitConverter.ToInt64(this.ReadProcessMemory(BaseAddress, 8U, out int _), 0);
  }

  public float ReadSingle(IntPtr BaseAddress)
  {
    return BitConverter.ToSingle(this.ReadProcessMemory(BaseAddress, 4U, out int _), 0);
  }

  public double ReadDouble(IntPtr BaseAddress)
  {
    return BitConverter.ToDouble(this.ReadProcessMemory(BaseAddress, 8U, out int _), 0);
  }

  public char ReadChar(IntPtr BaseAddress)
  {
    return Encoding.ASCII.GetChars(this.ReadProcessMemory(BaseAddress, 2U, out int _))[0];
  }

  public string ReadString(IntPtr BaseAddress)
  {
    StringBuilder stringBuilder = new StringBuilder(1);
    int BytesRead;
    for (byte[] bytes = this.ReadProcessMemory(BaseAddress, 1U, out BytesRead); bytes[0] != (byte) 0; bytes = this.ReadProcessMemory(BaseAddress, 1U, out BytesRead))
    {
      if (bytes[0] == (byte) 10)
        stringBuilder.AppendLine(Encoding.ASCII.GetString(bytes));
      else
        stringBuilder.Append(Encoding.ASCII.GetString(bytes));
      BaseAddress = (IntPtr) (BaseAddress.ToInt32() + 1);
    }
    return stringBuilder.ToString();
  }

  public string ReadStringX(IntPtr BaseAddress, uint Length)
  {
    return Encoding.ASCII.GetString(this.ReadProcessMemory(BaseAddress, Length, out int _));
  }

  public IntPtr ReadChainPointer(IntPtr BaseAddress, int[] Offsets)
  {
    foreach (int offset in Offsets)
      BaseAddress = (IntPtr) ((long) this.ReadUInt32(BaseAddress) + (long) offset);
    return BaseAddress;
  }
}
