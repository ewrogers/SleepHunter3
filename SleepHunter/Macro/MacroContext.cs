using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public class MacroContext : IMacroContext
    {
        public IMacroController Controller { get; }
        public PlayerState Player { get; }
        public IVirtualKeyboard Keyboard { get; }
        public IVirtualMouse Mouse { get; }
        public CancellationToken CancellationToken { get; }

        public MacroContext(IMacroController controller, PlayerState player, IVirtualKeyboard keyboard, IVirtualMouse mouse, CancellationToken token = default)
        {
            Controller = controller;
            Player = player;
            Keyboard = keyboard;
            Mouse = mouse;
            CancellationToken = token;
        }
    }
}
