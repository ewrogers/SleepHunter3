using SleepHunter.Interop.Mouse;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseClickCommand : MacroCommand
    {
        public MouseButton Button { get; }
        public bool IsDoubleClick { get; }

        public MouseClickCommand(MouseButton button, bool isDoubleClick = false)
        {
            Button = button;
            IsDoubleClick = isDoubleClick;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            context.Mouse.Click(Button);

            if (IsDoubleClick)
            {
                // The game does not respond to the Windows double-click message, so we send too standard clicks
                context.Mouse.Click(Button);
            }

            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => IsDoubleClick ? $"Double {Button} Click" : $"{Button} Click";
    }
}
