using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Jump
{
    public sealed class DefineLabelCommand : MacroCommand
    {
        public string Label { get; set; }

        public DefineLabelCommand(string label)
        {
            Label = label;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Effectly a no-op, mostly used as a marker
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"@{Label}";
    }
}
