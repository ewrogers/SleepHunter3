using System;

namespace SleepHunter.Macro.Conditions
{
    public sealed class BooleanCondition : IMacroCondition
    {
        private readonly Func<IMacroContext, bool> getter;
        private readonly string fieldName;

        public BooleanCondition(Func<IMacroContext, bool> valueGetter, string fieldName = null)
        {
            getter = valueGetter;
            this.fieldName = fieldName ?? "Value";
        }

        public bool Evaluate(IMacroContext context) => getter(context);

        public override string ToString() => fieldName;
    }
}