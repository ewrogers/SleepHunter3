using System.Collections.Generic;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public abstract class MacroCommand : IMacroCommand
    {
        public List<MacroParameterValue> Parameters { get; set; } = new List<MacroParameterValue>();

        public virtual bool CanExecute(IMacroContext context) => true;

        public abstract Task<MacroCommandResult> ExecuteAsync(IMacroContext context);
    }
}
