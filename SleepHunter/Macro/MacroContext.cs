using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public class MacroContext : IMacroContext
    {
        public PlayerState Player { get; }
        public IVirtualKeyboard Keyboard { get; }
        public IVirtualMouse Mouse { get; }

        public MacroContext(PlayerState player, IVirtualKeyboard keyboard, IVirtualMouse mouse)
        {
            Player = player;
            Keyboard = keyboard;
            Mouse = mouse;
        }
    }
}
