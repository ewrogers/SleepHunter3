using System;

namespace SleepHunter.Macro.Conditions
{
    public class StringCondition : IMacroCondition
    {
        private readonly Func<MacroContext, string> getter;
        private readonly StringCompareOperator @operator;
        private readonly string compareValue;
        
        public StringCondition(Func<MacroContext, string> valueGetter, StringCompareOperator op, string compareValue)
        {
            getter = valueGetter;
            @operator = op;
            this.compareValue = compareValue;
        }

        public bool Evaluate(MacroContext context)
        {
            var actualValue = getter(context);

            switch (@operator)
            {
                case StringCompareOperator.Equal:
                    return string.Equals(actualValue, compareValue, StringComparison.OrdinalIgnoreCase);
                case StringCompareOperator.NotEqual:
                    return !string.Equals(actualValue, compareValue, StringComparison.OrdinalIgnoreCase);
                case StringCompareOperator.Contains:
                    return actualValue.IndexOf(compareValue, StringComparison.OrdinalIgnoreCase) >= 0;
                case StringCompareOperator.NotContains:
                    return actualValue.IndexOf(compareValue, StringComparison.OrdinalIgnoreCase) < 0;
                case StringCompareOperator.LessThan:
                    return string.Compare(actualValue, compareValue, StringComparison.OrdinalIgnoreCase) < 0;
                case StringCompareOperator.GreaterThan:
                    return string.Compare(actualValue, compareValue, StringComparison.OrdinalIgnoreCase) > 0;
                case StringCompareOperator.StartsWith:
                    return actualValue.StartsWith(compareValue, StringComparison.OrdinalIgnoreCase);
                case StringCompareOperator.NotStartsWith:
                    return !actualValue.StartsWith(compareValue, StringComparison.OrdinalIgnoreCase);
                case StringCompareOperator.EndsWith:
                    return actualValue.EndsWith(compareValue, StringComparison.OrdinalIgnoreCase);
                case StringCompareOperator.NotEndsWith:
                    return !actualValue.EndsWith(compareValue, StringComparison.OrdinalIgnoreCase);
                default:
                    throw new InvalidOperationException($"Invalid operator: {@operator}");
            }
        }
    }
}