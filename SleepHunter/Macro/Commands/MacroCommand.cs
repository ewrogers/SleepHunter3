using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands
{
    public abstract class MacroCommand : IMacroCommand
    {
        public MacroParameterValue Parameter { get; set; }

        public virtual bool CanExecute(MacroContext context) => true;

        public abstract Task<MacroCommandResult> ExecuteAsync(MacroContext context);
    }
}
