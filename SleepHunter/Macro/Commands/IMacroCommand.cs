using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommand
    {
        bool CanExecute(MacroContext context);
        Task<MacroCommandResult> ExecuteAsync(MacroContext context);
    }
}
