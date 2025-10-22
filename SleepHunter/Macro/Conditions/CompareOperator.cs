
namespace SleepHunter.Macro.Conditions
{
    public enum CompareOperator
    {
        Equal = 0,
        LessThan = -1,
        GreaterThan = 1,
        LessThanOrEqual,
        GreaterThanOrEqual,
        NotEqual
    }

    public static class CompareOperatorExtensions
    {
        public static string ToSymbol(this CompareOperator compareOperator)
        {
            switch (compareOperator)
            {
                case CompareOperator.Equal: return "==";
                case CompareOperator.NotEqual: return "!=";
                case CompareOperator.GreaterThan: return ">";
                case CompareOperator.GreaterThanOrEqual: return ">=";
                case CompareOperator.LessThan: return "<";
                case CompareOperator.LessThanOrEqual: return "<=";
                default: return "??";
            }
        }
    }
}
