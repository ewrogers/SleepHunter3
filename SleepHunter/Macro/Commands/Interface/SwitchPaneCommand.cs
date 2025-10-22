using System;
using System.Threading.Tasks;

namespace SleepHunter.Macro.Commands.Interface
{
    public enum InterfacePane
    {
        Inventory,
        TemuairSkills,
        TemuairSpells,
        MedeniaSkills,
        MedeniaSpells,
        Chat,
        Stats,
        WorldSkillSpells
    }

    public sealed class SwitchPaneCommand : MacroCommand
    {
        public InterfacePane Pane { get; }

        public SwitchPaneCommand(InterfacePane pane)
        {
            Pane = pane;
        }

        public override Task<MacroCommandResult> ExecuteAsync(MacroContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            switch (Pane)
            {
                case InterfacePane.Inventory: return "Switch to Inventory Pane";
                case InterfacePane.TemuairSkills: return "Switch to Temuair Skill Pane";
                case InterfacePane.TemuairSpells: return "Switch to Temuair Spell Pane";
                case InterfacePane.MedeniaSkills: return "Switch to Medenia Skill Pane";
                case InterfacePane.MedeniaSpells: return "Switch to Medenia Spell Pane";
                case InterfacePane.Chat: return "Switch to Chat Pane";
                case InterfacePane.Stats: return "Switch to Stats Pane";
                case InterfacePane.WorldSkillSpells: return "Switch to World Skill/Spell Pane";
                default: return "Switch to Unknown Pane";
            }
        }
    }
}
