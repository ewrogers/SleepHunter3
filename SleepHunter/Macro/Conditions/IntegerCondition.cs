using System;

namespace SleepHunter.Macro.Conditions
{
    public class IntegerCondition : IMacroCondition
    {
        private readonly Func<MacroContext, long> _getter;
        private readonly CompareOperator _operator;
        private readonly long _compareValue;

        public IntegerCondition(Func<MacroContext, long> valueGetter, CompareOperator op, long compareValue)
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

        public override string ToString() => $"INTEGER {_operator.ToSymbol()} {_compareValue}";
    }
}
