using SleepHunter.Macro.Commands.Interface;
using System;

namespace SleepHunter.Macro.Commands
{
    public class MacroCommandFactory : IMacroCommandFactory
    {
        public IMacroCommand Create(MacroCommandDefinition command) => Create(command);

        public IMacroCommand Create(MacroCommandDefinition command, params MacroParameterValue[] parameters)
        {
            if (parameters == null)
            {
                parameters = Array.Empty<MacroParameterValue>();
            }

            switch (command.Category)
            {
                case MacroCommandCategory.Interface:
                    return CreateInterfaceCommand(command, parameters);
                default:
                    throw new InvalidOperationException($"Invalid command category: {command.Category}");
            }
        }

        private IMacroCommand CreateInterfaceCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.SwitchToInventoryPane:
                    return new SwitchPaneCommand(InterfacePane.Inventory);
                case MacroCommandKey.SwitchToTemuairSkillPane:
                    return new SwitchPaneCommand(InterfacePane.TemuairSkills);
                case MacroCommandKey.SwitchToTemuairSpellPane:
                    return new SwitchPaneCommand(InterfacePane.TemuairSpells);
                case MacroCommandKey.SwitchToMedeniaSkillPane:
                    return new SwitchPaneCommand(InterfacePane.MedeniaSkills);
                case MacroCommandKey.SwitchToMedeniaSpellPane:
                    return new SwitchPaneCommand(InterfacePane.MedeniaSpells);
                case MacroCommandKey.SwitchToChatPane:
                    return new SwitchPaneCommand(InterfacePane.Chat);
                case MacroCommandKey.SwitchToStatsPane:
                    return new SwitchPaneCommand(InterfacePane.Stats);
                case MacroCommandKey.SwitchToWorldSkillSpellPane:
                    return new SwitchPaneCommand(InterfacePane.WorldSkillSpells);
                default:
                    throw new InvalidOperationException($"Invalid interface command: {command.Key}");
            }
        }
    }
}
