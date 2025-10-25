using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class RecallMousePositionCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // If a saved mouse position exists, move the mouse to it
            if (context.SavedMousePosition.HasValue)
            {
                context.Mouse.MoveMouse(context.SavedMousePosition.Value);
                context.MousePosition = context.SavedMousePosition.Value;
            }

            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "Recall Mouse Position";
    }
}
