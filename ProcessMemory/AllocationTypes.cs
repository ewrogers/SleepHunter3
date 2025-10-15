// Decompiled with JetBrains decompiler
// Type: ProcessMemory.AllocationTypes
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System;

#nullable disable
namespace ProcessMemory;

[Flags]
public enum AllocationTypes
{
  Commit = 4096, // 0x00001000
  Reserve = 8192, // 0x00002000
  Decommit = 16384, // 0x00004000
  Release = 32768, // 0x00008000
  Reset = 524288, // 0x00080000
  Physical = 4194304, // 0x00400000
  TopDown = 1048576, // 0x00100000
}
