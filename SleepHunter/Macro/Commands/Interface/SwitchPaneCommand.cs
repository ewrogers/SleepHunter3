using System.Threading.Tasks;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Models;

namespace SleepHunter.Macro.Commands.Interface
{
    public sealed class SwitchPaneCommand : MacroCommand
    {
        public InterfacePanel Pane { get; }

        public SwitchPaneCommand(InterfacePanel pane)
        {
            Pane = pane;
        }

        public override Task<MacroCommandResult> ExecuteAsync(IMacroContext context)
        {
            // If the active pane is already the desired pane, do nothing
            if (context.Player.ActivePane == Pane)
            {
                return Task.FromResult(MacroCommandResult.Continue);
            }

            var keyboard = context.Keyboard;

            switch (Pane)
            {
                case InterfacePanel.Inventory:
                    keyboard.SendKeyPress('a');
                    break;
                
                case InterfacePanel.TemuairSkills:
                    keyboard.SendKeyPress('s');
                    break;
                
                case InterfacePanel.TemuairSpells:
                    keyboard.SendKeyPress('d');
                    break;
                
                case InterfacePanel.MedeniaSkills:
                    keyboard.SendModifierKeyDown(ModifierKeys.Shift);
                    keyboard.SendKeyPress('s');
                    keyboard.SendModifierKeyUp(ModifierKeys.Shift);
                    break;
                
                case InterfacePanel.MedeniaSpells:
                    keyboard.SendModifierKeyDown(ModifierKeys.Shift);
                    keyboard.SendKeyPress('d');
                    keyboard.SendModifierKeyUp(ModifierKeys.Shift);
                    break;
                
                case InterfacePanel.Chat:
                    keyboard.SendKeyPress('f');
                    break;
                
                case InterfacePanel.ChatHistory:
                    keyboard.SendModifierKeyDown(ModifierKeys.Shift);
                    keyboard.SendKeyPress('f');
                    keyboard.SendModifierKeyUp(ModifierKeys.Shift);
                    break;
                
                case InterfacePanel.Stats:
                    keyboard.SendKeyPress('g');
                    break;
                
                case InterfacePanel.Modifiers:
                    keyboard.SendModifierKeyDown(ModifierKeys.Shift);
                    keyboard.SendKeyPress('g');
                    keyboard.SendModifierKeyUp(ModifierKeys.Shift);
                    break;
                
                case InterfacePanel.WorldSkillSpells:
                    keyboard.SendKeyPress('h');
                    break;
            }
            
            return Task.FromResult(MacroCommandResult.Continue);
        }

        public override string ToString()
        {
            switch (Pane)
            {
                case InterfacePanel.Inventory: return "Switch to Inventory Pane";
                case InterfacePanel.TemuairSkills: return "Switch to Temuair Skill Pane";
                case InterfacePanel.TemuairSpells: return "Switch to Temuair Spell Pane";
                case InterfacePanel.MedeniaSkills: return "Switch to Medenia Skill Pane";
                case InterfacePanel.MedeniaSpells: return "Switch to Medenia Spell Pane";
                case InterfacePanel.Chat: return "Switch to Chat Pane";
                case InterfacePanel.ChatHistory: return "Switch to Chat History Pane";
                case InterfacePanel.Stats: return "Switch to Stats Pane";
                case InterfacePanel.Modifiers: return "Switch to Modifiers Pane";
                case InterfacePanel.WorldSkillSpells: return "Switch to World Skill/Spell Pane";
                default: return "Switch to Unknown Pane";
            }
        }
    }
}
