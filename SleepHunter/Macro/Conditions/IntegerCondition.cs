using System;

namespace SleepHunter.Macro.Conditions
{
    public class IntegerCondition : IMacroCondition
    {
        private readonly Func<MacroContext, long> getter;
        private readonly CompareOperator op;
        private readonly long compareValue;

        public IntegerCondition(Func<MacroContext, long> valueGetter, CompareOperator op, long compareValue)
        {
            getter = valueGetter;
            this.op = op;
            this.compareValue = compareValue;
        }

        public bool Evaluate(MacroContext context)
        {
            var actualValue = getter(context);

            switch (op)
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
                    throw new InvalidOperationException($"Invalid operator: {op}");
            }
        }

        public override string ToString() => $"{op.ToSymbol()} {compareValue}";
    }
}
