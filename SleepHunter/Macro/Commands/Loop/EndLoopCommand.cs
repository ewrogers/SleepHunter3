using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class EndLoopCommand : MacroCommand
    {
        // These are set by the macro execution engine
        public LoopCommand LoopStart { get; set; }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            // Effectly a no-op, mostly used as a marker
            return Task.FromResult(MacroCommandResult.NoOp);
        }

        public override string ToString() => "End Loop";
    }
}
