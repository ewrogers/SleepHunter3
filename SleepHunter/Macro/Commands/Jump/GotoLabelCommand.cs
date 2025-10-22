using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Jump
{
    public sealed class GotoLabelCommand : MacroCommand
    {
        public string Label { get; set; }

        public GotoLabelCommand(string label)
        {
            Label = label;
        }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"Goto @{Label}";
    }
}
