using System.Collections.Generic;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommand
    {
        List<MacroParameterValue> Parameters { get; set; }

        bool CanExecute(MacroContext context);
        Task<MacroCommandResult> ExecuteAsync(MacroContext context);
    }
}
