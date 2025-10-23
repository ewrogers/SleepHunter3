
using System;

namespace SleepHunter.Interop.Keyboard
{
    [Flags]
    public enum ModifierKeys
    {
        None = 0,
        Shift = 0x1,
        Control = 0x2,
        Alt = 0x4,
        Hanakaku = 0x8
    }
}
