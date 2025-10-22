using SleepHunter.Macro.Commands.Interface;
using SleepHunter.Macro.Commands.Logic;
using SleepHunter.Macro.Commands.Loop;
using SleepHunter.Macro.Conditions;
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
                case MacroCommandCategory.Map:
                    return CreateMapCommand(command, parameters);
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

        private IMacroCommand CreateMapCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                // If Commands
                case MacroCommandKey.IfMapName:
                    {
                        var condition = new StringCondition(ctx => ctx.Player.MapName, parameters[0].AsStringCompareOperator(), parameters[1].AsString());
                        return new IfCommand(condition, "Map Name");
                    }
                case MacroCommandKey.IfMapNumber:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapId, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new IfCommand(condition, "Map Number");
                    }
                case MacroCommandKey.IfMapX:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapX, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new IfCommand(condition, "X");
                    }
                case MacroCommandKey.IfMapY:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapY, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new IfCommand(condition, "Y");
                    }
                // While Commands
                case MacroCommandKey.WhileMapName:
                    {
                        var condition = new StringCondition(ctx => ctx.Player.MapName, parameters[0].AsStringCompareOperator(), parameters[1].AsString());
                        return new WhileCommand(condition, "Map Name");
                    }
                case MacroCommandKey.WhileMapNumber:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapId, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new WhileCommand(condition, "Map Number");
                    }
                case MacroCommandKey.WhileMapX:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapX, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new WhileCommand(condition, "X");
                    }
                case MacroCommandKey.WhileMapY:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.MapY, parameters[0].AsCompareOperator(), parameters[1].AsInteger());
                        return new WhileCommand(condition, "Y");
                    }
                default:
                    throw new InvalidOperationException($"Invalid map command: {command}");
            }
        }
    }
}
