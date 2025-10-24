using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SleepHunter.Interop.Keyboard;

namespace SleepHunter.Macro.Commands.Keyboard
{
    public sealed class SendKeysCommand : MacroCommand
    {
        private readonly List<Keystroke> keys;

        public SendKeysCommand()
        {
            keys = new List<Keystroke>();
        }

        public SendKeysCommand(IEnumerable<Keystroke> keys)
        {
            this.keys = keys.ToList();
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var keyboard = context.Keyboard;
            foreach (var key in keys)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                keyboard.SendKeyPress(key);
            }

            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString()
        {
            var keyString = string.Join("", keys);
            return $"Send Keys: {keyString}";
        }
    }
}
