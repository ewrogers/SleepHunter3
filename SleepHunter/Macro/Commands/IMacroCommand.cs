using System.Collections.Generic;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommand
    {
        List<MacroParameterValue> Parameters { get; set; }

        bool CanExecute(IMacroContext context);
        Task<MacroCommandResult> ExecuteAsync(IMacroContext context);
    }
}
