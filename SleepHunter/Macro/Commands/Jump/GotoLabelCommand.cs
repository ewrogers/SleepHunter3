using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Jump
{
    public sealed class GotoLabelCommand : MacroCommand
    {
        public string Label { get; set; }

        public GotoLabelCommand(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentException("Label cannot be null or whitespace", nameof(label));
            }
            
            Label = label;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Use the label index to jump to the label location
            if (context.StructureCache.Labels.TryGetValue(Label, out var labelIndex))
            {
                return Task.FromResult(MacroCommandResult.JumpToIndex(labelIndex));
            }

            // Label not found, continue normally
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"Goto @{Label}";
    }
}
