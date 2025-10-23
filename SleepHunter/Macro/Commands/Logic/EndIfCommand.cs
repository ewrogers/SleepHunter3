using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class EndIfCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Effectly a no-op, mostly used as a marker
            return Task.FromResult(MacroCommandResult.NoOp);
        }

        public override string ToString() => "End If";
    }
}
