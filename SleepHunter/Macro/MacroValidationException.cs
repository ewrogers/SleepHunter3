using System;

namespace SleepHunter.Macro
{
    public sealed class MacroValidationException : Exception
    {
        public int CommandIndex { get; }

        public MacroValidationException(string message, int commandIndex)
            : base(message)
        {
            CommandIndex = commandIndex;
        }
    }
}