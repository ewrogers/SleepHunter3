
namespace SleepHunter.Macro.Commands
{
    public interface IMacroCommandFactory
    {
        IMacroCommand Create(MacroCommandDefinition definition);
        IMacroCommand Create(MacroCommandDefinition definition, params MacroParameterValue[] parameters);
    }
}
