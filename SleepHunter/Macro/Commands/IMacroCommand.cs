using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommand
    {
        MacroParameterValue Parameter { get; set; }

        bool CanExecute(MacroContext context);
        Task<MacroCommandResult> ExecuteAsync(MacroContext context);
    }
}
