using System.Collections.Generic;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Models;
using System.Threading;

namespace SleepHunter.Macro
{
    public sealed class MacroContext : IMacroContext
    {
        private readonly Stack<MacroLoopState> loopStack = new Stack<MacroLoopState>();
        
        public IMacroStructureCache StructureCache { get; }
        public PlayerState Player { get; }
        public IVirtualKeyboard Keyboard { get; }
        public IVirtualMouse Mouse { get; }
        public CancellationToken CancellationToken { get; }
        public int CurrentCommandIndex { get; set; }
        
        public bool HasActiveLoops => loopStack.Count > 0;

        public MacroContext(IMacroStructureCache structureCache, PlayerState player, IVirtualKeyboard keyboard, IVirtualMouse mouse, CancellationToken token = default)
        {
            StructureCache = structureCache;
            Player = player;
            Keyboard = keyboard;
            Mouse = mouse;
            CancellationToken = token;
        }
        
        public void PushLoopState(MacroLoopState state) => loopStack.Push(state);
        public MacroLoopState PopLoopState() => loopStack.Count > 0 ? loopStack.Pop() : null;
        public MacroLoopState PeekLoopState() => loopStack.Count > 0 ? loopStack.Peek() : null;
    }
}
