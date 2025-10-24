using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Logic
{
    public sealed class EndIfCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Effectively a no-op, all logic is handled by the If and Else commands
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "End If";
    }
}
