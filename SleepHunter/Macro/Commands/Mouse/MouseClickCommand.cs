using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public enum MouseButton
    {
        Left, Right
    };

    public sealed class MouseClickCommand : MacroCommand
    {
        public MouseButton Button;

        public MouseClickCommand(MouseButton button)
        {
            Button = button;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{Button} Click";
    }
}
