using System;
using System.Collections.Generic;
using System.Linq;

namespace SleepHunter.Macro.Conditions
{
    public class CompositeCondition : IMacroCondition
    {
        private LogicalOperator _operator;
        public List<IMacroCondition> _conditions;

        public CompositeCondition(LogicalOperator op, params IMacroCondition[] conditions)
        {
            _operator = op;
            _conditions = new List<IMacroCondition>(conditions);
        }

        public bool Evaluate(MacroContext context)
        {
            switch (_operator)
            {
                case LogicalOperator.And: return _conditions.All(c => c.Evaluate(context));
                case LogicalOperator.Or: return _conditions.Any(c => c.Evaluate(context));
                case LogicalOperator.Not: return !_conditions.Single().Evaluate(context);
                default:
                    throw new InvalidOperationException($"Invalid operator: {_operator}");
            }
        }
    }
}
