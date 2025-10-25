using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SleepHunter.Interop.Mouse;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseDragMoveCommand : MacroCommand
    {
        private static readonly TimeSpan DragInterval = TimeSpan.FromMilliseconds(16);  // Roughly 60 FPS

        public MouseMoveKind Kind { get; }
        public MouseButton Button { get; }
        
        public MousePoint Position { get; }

        public float Step { get; set; } = 0.2f;

        public MouseDragMoveCommand(int x, int y, MouseButton button = MouseButton.Left, MouseMoveKind kind = MouseMoveKind.Absolute)
        :this(new MousePoint(x, y), button, kind) { }
        
        public MouseDragMoveCommand(MousePoint position, MouseButton button = MouseButton.Left, MouseMoveKind kind = MouseMoveKind.Absolute)
        {
            Kind = kind;
            Button = button;
            Position = position;
        }
        
        public override async Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            var current = context.MousePosition ?? MousePoint.Zero;
            var destination = Position;

            if (Kind == MouseMoveKind.Relative)
            {
                destination = new MousePoint(current.X + Position.X, current.Y + Position.Y);
            }

            // Press the mouse button
            context.Mouse.SendButtonDown(Button, current);
            
            // Basic linear interpolation loop
            do
            {
                var deltaX = destination.X - current.X;
                var deltaY = destination.Y - current.Y;
                var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                if (distance < 8)
                {
                    current = destination;
                }
                else
                {
                    var newX = LerpStep(current.X, destination.X, Step);
                    var newY = LerpStep(current.Y, destination.Y, Step);
                    current = new MousePoint(newX, newY);
                }

                // Move the mouse
                context.Mouse.MoveMouse(current);
                context.MousePosition = current;

                await Task.Delay(DragInterval, context.CancellationToken);

            } while (!context.CancellationToken.IsCancellationRequested && (current.X != destination.X || current.Y != destination.Y));

            // Finally release the mouse button
            context.Mouse.SendButtonUp(Button, current);
            
            return MacroCommandResult.Continue;
        }

        public override string ToString()
        {
            var dragString = Button == MouseButton.Left ? "Drag Mouse" : $"Drag {Button} Mouse";

            return Kind == MouseMoveKind.Relative ? $"{dragString} by {Position}" : $"{dragString} to {Position}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int LerpStep(int current, int target, float step)
        {
            if (current == target)
            {
                return target;
            }

            var distance = target - current;

            if (Math.Abs(distance) < 2)
            {
                return target;
            }

            var stepAmount = Math.Abs(distance) * step;
            var stepInt = Math.Max(1, (int)Math.Round(stepAmount));

            return distance > 0
                ? Math.Min(current + stepInt, target)
                : Math.Max(current - stepInt, target);
        }
    }
}