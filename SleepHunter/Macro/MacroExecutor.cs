using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SleepHunter.Interop;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public sealed class MacroExecutor : IMacroExecutor, IMacroController
    {
        private readonly List<IMacroCommand> commands;
        private readonly PlayerState player;
        private readonly GameClientReader reader;
        private readonly IVirtualKeyboard keyboard;
        private readonly IVirtualMouse mouse;
        private readonly CancellationTokenSource cancellationTokenSource;

        private readonly IMacroContext context;

        private DateTime lastUpdateTime;
        private bool isDisposed;
        
        public MacroExecutor(IEnumerable<IMacroCommand> commands, GameClientReader reader, IVirtualKeyboard keyboard, IVirtualMouse mouse)
        {
            this.commands = commands.ToList();
            this.reader = reader;
            this.keyboard = keyboard;
            this.mouse = mouse;

            cancellationTokenSource = new CancellationTokenSource();

            player = new PlayerState();
            context = new MacroContext(this, this.player, this.keyboard, this.mouse, cancellationTokenSource.Token);
        }
        
        ~MacroExecutor() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                cancellationTokenSource?.Dispose();
            }

            isDisposed = true;
        }
    }
}
