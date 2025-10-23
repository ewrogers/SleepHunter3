using System;

namespace SleepHunter.Interop.Keyboard
{
    public sealed class VirtualKeyboard : IVirtualKeyboard
    {
        private readonly IntPtr windowHandle;

        public VirtualKeyboard(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }
    }
}
