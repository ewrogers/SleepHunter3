using System;

namespace SleepHunter.Macro.Conditions
{
    public sealed class IntegerCondition : IMacroCondition
    {
        private readonly Func<IMacroContext, long> getter;
        private readonly CompareOperator op;
        private readonly long compareValue;

        public IntegerCondition(Func<IMacroContext, long> valueGetter, CompareOperator op, long compareValue)
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
