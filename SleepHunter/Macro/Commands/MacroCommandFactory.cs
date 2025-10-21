using System;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandFactory : IMacroCommandFactory
    {
        public IMacroCommand Create(MacroCommandDefinition definition) => Create(definition);
        public IMacroCommand Create(MacroCommandDefinition definition, params MacroParameterValue[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
