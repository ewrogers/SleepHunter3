using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class SaveMousePositionCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // Save the current mouse position
            var cursor = context.Mouse.GetCursorPosition();
            context.SavedMousePosition = cursor;
            
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "Save Mouse Position";
    }
}
