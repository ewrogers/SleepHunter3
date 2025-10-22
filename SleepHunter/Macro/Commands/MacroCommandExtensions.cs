
using SleepHunter.Macro.Commands.Logic;
using SleepHunter.Macro.Commands.Loop;

namespace SleepHunter.Macro.Commands
{
    public static class MacroCommandExtensions
    {
        public static bool IsOpeningCommand(this IMacroCommand command)
            => command is IfCommand || command is ElseCommand || command is WhileCommand || command is LoopCommand;

        public static bool IsClosingCommand(this IMacroCommand command)
            => command is EndIfCommand || command is EndWhileCommand || command is EndLoopCommand;

        public static IMacroCommand GetClosingCommand(this IMacroCommand command)
        {
            if (command is IfCommand)
            {
                return new EndIfCommand();
            }

            if (command is WhileCommand)
            {
                return new EndWhileCommand();
            }

            if (command is LoopCommand)
            {
                return new EndLoopCommand();
            }

            return null;
        }
    }
}
