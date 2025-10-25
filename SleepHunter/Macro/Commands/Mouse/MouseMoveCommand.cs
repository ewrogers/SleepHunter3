
using System.Threading.Tasks;
using SleepHunter.Interop.Mouse;

namespace SleepHunter.Macro.Commands.Mouse
{
    public enum MouseMoveKind
    {
        Absolute,
        Relative,
    }
    
    public sealed class MouseMoveCommand : MacroCommand
    {
        public MouseMoveKind Kind { get; }
        
        public MousePoint Position { get; }

        public MouseMoveCommand(int x, int y, MouseMoveKind kind = MouseMoveKind.Absolute)
        :this(new MousePoint(x, y), kind) { }

        public MouseMoveCommand(MousePoint position, MouseMoveKind kind = MouseMoveKind.Absolute)
        {
            Kind = kind;
            Position = position;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var position = Position;

            if (Kind == MouseMoveKind.Relative)
            {
                position = context.MousePosition ?? MousePoint.Zero;
                position = new MousePoint(position.X + Position.X, position.Y + Position.Y);
            }

            context.Mouse.MoveMouse(position);
            context.MousePosition = position;

            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString()
        {
            return Kind == MouseMoveKind.Relative
                ? $"Move Mouse by {Position.X}, {Position.Y}"
                : $"Move Mouse to {Position.X}, {Position.Y}";
        }
    }
}
