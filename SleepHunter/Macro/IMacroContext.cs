using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public interface IMacroContext
    {
        PlayerState Player { get; }
        IVirtualKeyboard Keyboard { get; }
        IVirtualMouse Mouse { get; }
    }
}
