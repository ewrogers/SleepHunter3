using System;

namespace SleepHunter.Interop.Win32
{
    [Flags]
    internal enum Win32ProcessAccessFlags : uint
    {
        None = 0,
        Terminate = 0x1,
        CreateThread = 0x2,
        VmOperation = 0x8,
        VmRead = 0x10,
        VmWrite = 0x20,
        QueryInformation = 0x400
    }
}
