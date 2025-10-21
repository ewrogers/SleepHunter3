using System.Collections.Generic;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public abstract class MacroCommand : IMacroCommand
    {
        public List<MacroParameterValue> Parameters { get; protected set; } = new List<MacroParameterValue>();

        public virtual bool CanExecute(MacroContext context) => true;

        public abstract Task<MacroCommandResult> ExecuteAsync(MacroContext context);

        public virtual void SetParameters(params MacroParameterValue[] parameters) =>
            Parameters = new List<MacroParameterValue>(parameters);
    }
}
