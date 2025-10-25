using System;

namespace SleepHunter.Macro.Conditions
{
    public sealed class StringCondition : IMacroCondition
    {
        private readonly Func<IMacroContext, string> getter;
        private readonly StringCompareOperator op;
        private readonly string compareValue;

        public StringCondition(Func<IMacroContext, string> valueGetter, StringCompareOperator op, string compareValue)
        {
            getter = valueGetter;
            this.op = op;
            this.compareValue = compareValue;
        }

        public bool Evaluate(IMacroContext context)
        {
            var actualValue = getter(context);

            switch (op)
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
                    throw new InvalidOperationException($"Invalid operator: {op}");
            }
        }

        public override string ToString() => $"{op.ToSymbol()} '{compareValue}'";
    }
}