using System.Threading.Tasks;
using SleepHunter.Interop.Mouse;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseButtonUpCommand : MacroCommand
    {
        public MouseButton Button { get; }

        public MouseButtonUpCommand(MouseButton button)
        {
            Button = button;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            context.Mouse.SendButtonUp(Button);
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"{Button} Mouse Button Up";
    }
}