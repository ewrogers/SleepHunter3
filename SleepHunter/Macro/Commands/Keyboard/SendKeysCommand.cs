using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepHunter.Macro.Commands.Keyboard
{
    public sealed class SendKeysCommand : MacroCommand
    {
        private readonly List<Keys> keys = new List<Keys>();

        public SendKeysCommand(IEnumerable<Keys> keys)
        {
            this.keys = keys.ToList();
        }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Send Keys";
    }
}
