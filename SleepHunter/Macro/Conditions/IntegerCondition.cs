using System;

namespace SleepHunter.Macro.Conditions
{
    public class IntegerCondition : IMacroCondition
    {
        private readonly Func<MacroContext, long> getter;
        private readonly CompareOperator @operator;
        private readonly long compareValue;

        public IntegerCondition(Func<MacroContext, long> valueGetter, CompareOperator op, long compareValue)
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
                case CompareOperator.Equal:
                    return actualValue == compareValue;
                case CompareOperator.NotEqual:
                    return actualValue != compareValue;
                case CompareOperator.GreaterThan:
                    return actualValue > compareValue;
                case CompareOperator.GreaterThanOrEqual:
                    return actualValue >= compareValue;
                case CompareOperator.LessThan:
                    return actualValue < compareValue;
                case CompareOperator.LessThanOrEqual:
                    return actualValue <= compareValue;
                default:
                    throw new InvalidOperationException($"Invalid operator: {@operator}");
            }
        }

        public override string ToString() => $"INTEGER {@operator.ToSymbol()} {compareValue}";
    }
}
