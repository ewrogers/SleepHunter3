using System;
using SleepHunter.Interop.Mouse;
using SleepHunter.Macro.Commands.Interface;
using SleepHunter.Macro.Commands.Jump;
using SleepHunter.Macro.Commands.Keyboard;
using SleepHunter.Macro.Commands.Logic;
using SleepHunter.Macro.Commands.Loop;
using SleepHunter.Macro.Commands.Mouse;
using SleepHunter.Macro.Commands.Time;
using SleepHunter.Macro.Conditions;

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
                case MacroCommandCategory.Health:
                    return CreateHealthCommand(command, parameters);
                case MacroCommandCategory.Mana:
                    return CreateManaCommand(command, parameters);
                case MacroCommandCategory.Keyboard:
                    return CreateKeyboardCommand(command, parameters);
                case MacroCommandCategory.Mouse:
                    return CreateMouseCommand(command, parameters);
                case MacroCommandCategory.Logic:
                    return CreateLogicCommand(command, parameters);
                case MacroCommandCategory.Loop:
                    return CreateLoopCommand(command, parameters);
                case MacroCommandCategory.Jump:
                    return CreateJumpCommand(command, parameters);
                case MacroCommandCategory.Time:
                    return CreateTimeCommand(command, parameters);
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
                case MacroCommandKey.IfChatInputOpen:
                {
                    var condition = new BooleanCondition(ctx => ctx.Player.ChatHasFocus, "Open");
                    return new IfCommand(condition, "Chat Input");
                }
                case MacroCommandKey.WhileChatInputOpen:
                {
                    var condition = new BooleanCondition(ctx => ctx.Player.ChatHasFocus, "Open");
                    return new WhileCommand(condition, "Chat Input");
                }
                case MacroCommandKey.IfMinimizedMode:
                {
                    var condition = new BooleanCondition(ctx => ctx.Player.IsMinimizedMode, "Mode");
                    return new IfCommand(condition, "Minimized");
                }
                case MacroCommandKey.IfInventoryExpanded:
                {
                    var condition = new BooleanCondition(ctx => ctx.Player.IsInventoryExpanded, "Expanded");
                    return new IfCommand(condition, "Inventory");   
                }
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

        private IMacroCommand CreateHealthCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.IfHealthValue:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.CurrentHealth, parameters[0].AsCompareOperator(), parameters[1].AsLong());
                        return new IfCommand(condition, "HP");
                    }
                case MacroCommandKey.IfHealthPercent:
                    {
                        var condition = new FloatCondition(ctx => ctx.Player.HealthPercentage, parameters[0].AsCompareOperator(), parameters[1].AsDouble());
                        return new IfCommand(condition, "HP %");
                    }
                case MacroCommandKey.WhileHealthValue:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.CurrentHealth, parameters[0].AsCompareOperator(), parameters[1].AsLong());
                        return new WhileCommand(condition, "HP");
                    }
                case MacroCommandKey.WhileHealthPercent:
                    {
                        var condition = new FloatCondition(ctx => ctx.Player.HealthPercentage, parameters[0].AsCompareOperator(), parameters[1].AsDouble());
                        return new WhileCommand(condition, "HP %");
                    }
                default:
                    throw new InvalidOperationException($"Invalid health command: {command}");
            }
        }

        private IMacroCommand CreateManaCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.IfManaValue:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.CurrentMana, parameters[0].AsCompareOperator(), parameters[1].AsLong());
                        return new IfCommand(condition, "MP");
                    }
                case MacroCommandKey.IfManaPercent:
                    {
                        var condition = new FloatCondition(ctx => ctx.Player.ManaPercentage, parameters[0].AsCompareOperator(), parameters[1].AsDouble());
                        return new IfCommand(condition, "MP %");
                    }
                case MacroCommandKey.WhileManaValue:
                    {
                        var condition = new IntegerCondition(ctx => ctx.Player.CurrentMana, parameters[0].AsCompareOperator(), parameters[1].AsLong());
                        return new WhileCommand(condition, "MP");
                    }
                case MacroCommandKey.WhileManaPercent:
                    {
                        var condition = new FloatCondition(ctx => ctx.Player.ManaPercentage, parameters[0].AsCompareOperator(), parameters[1].AsDouble());
                        return new WhileCommand(condition, "MP %");
                    }
                default:
                    throw new InvalidOperationException($"Invalid mana command: {command}");
            }
        }

        private IMacroCommand CreateKeyboardCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.SendKeystrokes:
                    return new SendKeysCommand(parameters[0].AsKeystrokes());
                default:
                    throw new InvalidOperationException($"Invalid keyboard command: {command}");
            }
        }

        private IMacroCommand CreateMouseCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.MouseLeftClick:
                    return new MouseClickCommand(MouseButton.Left);
                case MacroCommandKey.MouseRightClick:
                    return new MouseClickCommand(MouseButton.Right);
                case MacroCommandKey.MouseMove:
                    return new MouseMoveCommand(parameters[0].AsInteger(), parameters[1].AsInteger());
                case MacroCommandKey.MouseSavePosition:
                    return new SaveMousePositionCommand();
                case MacroCommandKey.MouseRecallPosition:
                    return new RecallMousePositionCommand();
                default:
                    throw new InvalidOperationException($"Invalid mouse command: {command}");
            }
        }

        private IMacroCommand CreateLogicCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.Else:
                    return new ElseCommand();
                case MacroCommandKey.EndIf:
                    return new EndIfCommand();
                default:
                    throw new InvalidOperationException($"Invalid logic command: {command}");
            }
        }

        private IMacroCommand CreateLoopCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.LoopInfinite:
                    return new LoopCommand();
                case MacroCommandKey.LoopCount:
                    return new LoopCommand(parameters[0].AsInteger());
                case MacroCommandKey.LoopReset:
                    return new LoopResetCommand();
                case MacroCommandKey.Continue:
                    return new ContinueCommand();
                case MacroCommandKey.Break:
                    return new BreakCommand();
                case MacroCommandKey.EndLoop:
                    return new EndLoopCommand();
                case MacroCommandKey.EndWhile:
                    return new EndWhileCommand();
                default:
                    throw new InvalidOperationException($"Invalid loop command: {command}");
            }
        }

        private IMacroCommand CreateJumpCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.DefineLabel:
                    return new DefineLabelCommand(parameters[0].AsString());
                case MacroCommandKey.GotoLabel:
                    return new GotoLabelCommand(parameters[0].AsString());
                case MacroCommandKey.GotoLine:
                    return new GotoLineCommand(parameters[0].AsInteger());
                default:
                    throw new InvalidOperationException($"Invalid jump command: {command}");
            }
        }

        private IMacroCommand CreateTimeCommand(MacroCommandDefinition command, MacroParameterValue[] parameters)
        {
            switch (command.Key.ToUpperInvariant())
            {
                case MacroCommandKey.WaitDelay:
                    return new WaitDelayCommand(parameters[0].AsInteger());
                default:
                    throw new InvalidOperationException($"Invalid wait command: {command}");
            }
        }
    }
}
