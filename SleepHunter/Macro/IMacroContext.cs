using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public interface IMacroContext
    {
        IMacroStructureCache StructureCache { get; }
        PlayerState Player { get; }
        IVirtualKeyboard Keyboard { get; }
        IVirtualMouse Mouse { get; }
        CancellationToken CancellationToken { get; }
        int CurrentCommandIndex { get; }

        bool HasActiveLoops { get; }
        void PushLoopState(MacroLoopState state);
        MacroLoopState PopLoopState();
        MacroLoopState PeekLoopState();
    }
}
