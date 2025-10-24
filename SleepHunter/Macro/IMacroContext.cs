using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public interface IMacroContext
    {
        PlayerState Player { get; }
        IVirtualKeyboard Keyboard { get; }
        IVirtualMouse Mouse { get; }
        CancellationToken CancellationToken { get; }
        int CurrentCommandIndex { get; }
    }
}
