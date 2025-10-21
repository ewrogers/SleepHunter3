using System;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandResult
    {
        public bool IsSuccess { get; private set; }
        public object Result { get; private set; }
        public Exception Exception { get; private set; }

        private MacroCommandResult() { }

        public static MacroCommandResult Success(object result = null)
        {
            return new MacroCommandResult
            {
                IsSuccess = true,
                Result = result
            };
        }

        public static MacroCommandResult Error(Exception exception = null)
        {
            return new MacroCommandResult
            {
                Exception = exception
            };
        }
    }
}
