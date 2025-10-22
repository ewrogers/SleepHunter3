
namespace SleepHunter.Macro.Conditions
{
    public enum LogicalOperator
    {
        And,
        Or,
        Not
    }

    public static class LogicalOperatorExtensions
    {
        public static string ToSymbol(this LogicalOperator logicalOperator)
        {
            switch (logicalOperator)
            {
                case LogicalOperator.And: return "&";
                case LogicalOperator.Or: return "|";
                case LogicalOperator.Not: return "~";
                default: return "??";
            }
        }
    }
}
