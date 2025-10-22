namespace SleepHunter.Macro.Conditions
{
    public enum StringCompareOperator
    {
        Equal = 0,
        LessThan = -1,
        GreaterThan = 1,
        NotEqual = 2,
        Contains = 3,
        NotContains = -3,
        StartsWith = 4,
        NotStartsWith = -4,
        EndsWith = 5,
        NotEndsWith = -5
    }

    public static class StringCompareOperatorExtensions
    {
        public static string ToKeyword(this StringCompareOperator compareOperator)
        {
            switch (compareOperator)
            {
                case StringCompareOperator.Equal: return "Is";
                case StringCompareOperator.NotEqual: return "Is Not";
                case StringCompareOperator.LessThan: return "Is Before";
                case StringCompareOperator.GreaterThan: return "Is After";
                case StringCompareOperator.Contains: return "Contains";
                case StringCompareOperator.NotContains: return "Does Not Contain";
                case StringCompareOperator.StartsWith: return "Starts With";
                case StringCompareOperator.NotStartsWith: return "Does Not Start With";
                case StringCompareOperator.EndsWith: return "Ends With";
                case StringCompareOperator.NotEndsWith: return "Does Not End With";
                default: return "Unknown";
            }
        }

        public static string ToSymbol(this StringCompareOperator compareOperator)
        {
            switch (compareOperator)
            {
                case StringCompareOperator.Equal: return "==";
                case StringCompareOperator.NotEqual: return "!=";
                case StringCompareOperator.LessThan: return "<";
                case StringCompareOperator.GreaterThan: return ">";
                case StringCompareOperator.Contains: return "%";
                case StringCompareOperator.NotContains: return "!%";
                case StringCompareOperator.StartsWith: return "^";
                case StringCompareOperator.NotStartsWith: return "!^";
                case StringCompareOperator.EndsWith: return "$";
                case StringCompareOperator.NotEndsWith: return "!$";
                default: return "??";
            }
        }
    }
}