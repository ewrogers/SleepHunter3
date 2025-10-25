using System;

namespace SleepHunter.Interop.Hotkey
{
    [Flags]
    public enum HotkeyModifiers : uint
    {
        None = 0,
        Alt = 0x1,
        Control = 0x2,
        Shift = 0x4,
        Windows = 0x8
    }
}