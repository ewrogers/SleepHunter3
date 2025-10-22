using System;

namespace SleepHunter.Macro.Conditions
{
    public class FloatCondition : IMacroCondition
    {
        private readonly Func<MacroContext, double> getter;
        private readonly CompareOperator op;
        private readonly double compareValue;

        public FloatCondition(Func<MacroContext, double> valueGetter, CompareOperator op, double compareValue)
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
