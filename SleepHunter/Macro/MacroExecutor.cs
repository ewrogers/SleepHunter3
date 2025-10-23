using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SleepHunter.Macro.Commands;

namespace SleepHunter.Macro
{
    public sealed class MacroExecutor : IMacroExecutor
    {
        private readonly List<IMacroCommand> commands;
        
        private CancellationTokenSource cancellationTokenSource;
        private bool isDisposed;
        
        public MacroExecutor(IEnumerable<IMacroCommand> commands)
        {
            this.commands = commands.ToList();
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
