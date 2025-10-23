using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public interface IMacroContext
    {
        IMacroController Controller { get; }
        PlayerState Player { get; }
        IVirtualKeyboard Keyboard { get; }
        IVirtualMouse Mouse { get; }
        CancellationToken CancellationToken { get; }
    }
}
