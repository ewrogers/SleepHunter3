using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class SaveMousePositionCommand : MacroCommand
    {
        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            context.SavedMousePosition = context.MousePosition;
            
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => "Save Mouse Position";
    }
}
