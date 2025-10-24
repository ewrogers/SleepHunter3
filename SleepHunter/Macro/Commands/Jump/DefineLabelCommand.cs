using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Jump
{
    public sealed class DefineLabelCommand : MacroCommand
    {
        public string Label { get; set; }

        public DefineLabelCommand(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentException("Label cannot be null or whitespace", nameof(label));
            }

            Label = label;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Labels are a passive marker
            // The label location is registered in the macro structure
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"@{Label}";
    }
}
