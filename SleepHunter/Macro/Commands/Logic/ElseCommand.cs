using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class ElseCommand : MacroCommand
    {
        // These are set by the macro execution engine
        public IfCommand If { get; set; }
        public EndIfCommand EndIf { get; set; }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            // Effectly a no-op, mostly used as a marker
            return Task.FromResult(MacroCommandResult.NoOp);
        }

        public override string ToString() => "Else";
    }
}
