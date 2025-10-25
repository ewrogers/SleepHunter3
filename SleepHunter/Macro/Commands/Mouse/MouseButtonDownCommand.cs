using System.Threading.Tasks;
using SleepHunter.Interop.Mouse;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseButtonDownCommand : MacroCommand
    {
        public MouseButton Button { get; }
        
        public MouseButtonDownCommand(MouseButton button)
        {
            Button = button;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            context.Mouse.SendButtonDown(Button);
            return Task.FromResult(MacroCommandResult.Continue);
        }
        
        public override string ToString() => $"{Button} Mouse Button Down";
    }
}