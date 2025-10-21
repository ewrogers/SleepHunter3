using System;
using System.Collections.Generic;
using System.Linq;

namespace SleepHunter.Macro.Conditions
{
    public class CompositeCondition : IMacroCondition
    {
        private LogicalOperator @operator;
        public List<IMacroCondition> Conditions;

        public CompositeCondition(LogicalOperator op, params IMacroCondition[] conditions)
        {
            @operator = op;
            Conditions = new List<IMacroCondition>(conditions);
        }

        public bool Evaluate(MacroContext context)
        {
            switch (@operator)
            {
                case LogicalOperator.And: return Conditions.All(c => c.Evaluate(context));
                case LogicalOperator.Or: return Conditions.Any(c => c.Evaluate(context));
                case LogicalOperator.Not: return !Conditions.Single().Evaluate(context);
                default:
                    throw new InvalidOperationException($"Invalid operator: {@operator}");
            }
        }
    }
}
