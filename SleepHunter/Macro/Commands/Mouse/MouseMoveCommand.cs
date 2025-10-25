
using System.Threading.Tasks;
using SleepHunter.Interop.Mouse;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseMoveCommand : MacroCommand
    {
        public MousePoint Position { get; }

        public MouseMoveCommand(int x, int y)
        {
            Position = new MousePoint(x, y);
        }

        public MouseMoveCommand(MousePoint position)
        {
            Position = position;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            context.Mouse.MoveMouse(Position.X, Position.Y);
            context.MousePosition = Position;
            
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString() => $"Move Mouse to {Position.X}, {Position.Y}";
    }
}
