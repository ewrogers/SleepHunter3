using System;

namespace SleepHunter.Macro.Conditions
{
    public class FloatCondition : IMacroCondition
    {
        private readonly Func<MacroContext, double> _getter;
        private readonly CompareOperator _operator;
        private readonly double _compareValue;

        public FloatCondition(Func<MacroContext, double> valueGetter, CompareOperator op, double compareValue)
        {
            _getter = valueGetter;
            _operator = op;
            _compareValue = compareValue;
        }

        public bool Evaluate(MacroContext context)
        {
            var actualValue = _getter(context);

            switch (_operator)
            {
                case CompareOperator.Equal:
                    return actualValue == _compareValue;
                case CompareOperator.NotEqual:
                    return actualValue != _compareValue;
                case CompareOperator.GreaterThan:
                    return actualValue > _compareValue;
                case CompareOperator.GreaterThanOrEqual:
                    return actualValue >= _compareValue;
                case CompareOperator.LessThan:
                    return actualValue < _compareValue;
                case CompareOperator.LessThanOrEqual:
                    return actualValue <= _compareValue;
                default:
                    throw new InvalidOperationException($"Invalid operator: {_operator}");
            }
        }

        public override string ToString() => $"FLOAT {_operator.ToSymbol()} {_compareValue}";
    }
}
