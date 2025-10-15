// Decompiled with JetBrains decompiler
// Type: ProcessMemory.MEMORY_BASIC_INFORMATION
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;

#nullable disable
namespace ProcessMemory;

public struct MEMORY_BASIC_INFORMATION
{
  public IntPtr BaseAddress;
  public IntPtr AllocationBase;
  public uint AllocationProtect;
  public uint RegionSize;
  public uint State;
  public uint Protect;
  public uint Type;
}
