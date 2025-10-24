using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Loop
{
    public sealed class EndWhileCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var loopState = context.PeekLoopState();

            // If not in a while loop, do nothing and proceed
            if (loopState == null || loopState.LoopType != MacroLoopType.While)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            // Jump back to the while command to re-evaluate the condition
            // The while command will handle checking the loop state and continuing/ending as necessary
            return Task.FromResult(MacroCommandResult.JumpToIndex(loopState.LoopStartIndex));
        }

        public override string ToString() => "End While";
    }
}
