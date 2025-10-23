
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Mouse
{
    public sealed class MouseMoveCommand : MacroCommand
    {
        public int X { get; }
        public int Y { get; }

        public MouseMoveCommand(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => $"Move Mouse to {X}, {Y}";
    }
}
