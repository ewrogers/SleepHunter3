using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class EndLoopCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Effectly a no-op, mostly used as a marker
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "End Loop";
    }
}
