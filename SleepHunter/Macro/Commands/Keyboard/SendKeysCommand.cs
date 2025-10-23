using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SleepHunter.Macro.Keyboard;

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

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var keyString = string.Join("", keys);
            return $"Send Keys: {keyString}";
        }
    }
}
