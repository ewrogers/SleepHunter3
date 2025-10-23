using System;
using System.Collections.Generic;
using System.Linq;

namespace SleepHunter.Macro.Conditions
{
    public class CompositeCondition : IMacroCondition
    {
        private LogicalOperator op;
        public List<IMacroCondition> Conditions;

        public CompositeCondition(LogicalOperator op, params IMacroCondition[] conditions)
        {
            this.op = op;
            Conditions = new List<IMacroCondition>(conditions);
        }

        public bool Evaluate(IMacroContext context)
        {
            switch (op)
            {
                case LogicalOperator.And: return Conditions.All(c => c.Evaluate(context));
                case LogicalOperator.Or: return Conditions.Any(c => c.Evaluate(context));
                case LogicalOperator.Not: return !Conditions.Single().Evaluate(context);
                default:
                    throw new InvalidOperationException($"Invalid operator: {op}");
            }
        }
    }
}
