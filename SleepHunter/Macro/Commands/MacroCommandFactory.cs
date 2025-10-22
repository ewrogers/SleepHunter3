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
                case "INTERFACE_INVENTORY":
                    return new SwitchPaneCommand(InterfacePane.Inventory);
                case "INTERFACE_TEMUAIR_SKILL":
                    return new SwitchPaneCommand(InterfacePane.TemuairSkills);
                case "INTERFACE_TEMUAIR_SPELL":
                    return new SwitchPaneCommand(InterfacePane.TemuairSpells);
                case "INTERFACE_MEDENIA_SKILL":
                    return new SwitchPaneCommand(InterfacePane.MedeniaSkills);
                case "INTERFACE_MEDENIA_SPELL":
                    return new SwitchPaneCommand(InterfacePane.MedeniaSpells);
                case "INTERFACE_CHAT":
                    return new SwitchPaneCommand(InterfacePane.Chat);
                case "INTERFACE_STATS":
                    return new SwitchPaneCommand(InterfacePane.Stats);
                case "INTERFACE_WORLD_SKILL_SPELL":
                    return new SwitchPaneCommand(InterfacePane.WorldSkillSpells);
                default:
                    throw new InvalidOperationException($"Invalid interface command: {command.Key}");
            }
        }
    }
}
