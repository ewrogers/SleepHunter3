using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Conditions;
using System;

namespace SleepHunter.Macro.Serialization
{
    public sealed class LegacySerializer : ILegacySerializer
    {
        private static readonly char[] NewLineChars = { '\r', '\n' };
        private static readonly char[] SplitChars = { '|' };

        public SerializableMacroDocument DeserializeDocument(string contents)
        {
            var lines = contents.Split(NewLineChars, System.StringSplitOptions.RemoveEmptyEntries);

            // First line is the count of entries
            var count = 0;
            if (lines.Length > 0)
            {
                var parsedCount = int.Parse(lines[0].Trim());
                count = Math.Min(parsedCount, lines.Length - 2);
            }

            // Second line is the macro name
            var name = string.Empty;
            if (lines.Length > 1)
            {
                name = lines[1].Trim();
            }

            var document = new SerializableMacroDocument { Name = name };

            if (count <= 0)
            {
                return document;
            }

            // Parse each line into a modern serializable command
            for (var i = 0; i < count; i++)
            {
                var line = lines[i].Trim();
                var command = DeserializeCommand(line);

                document.Commands.Add(command);
            }

            return document;
        }

        public SerializableMacroCommand DeserializeCommand(string line)
        {
            var tokens = line.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                throw new FormatException("Invalid line format");
            }

            var command = tokens[0].ToUpperInvariant();

            switch (command)
            {
                case "GS_STATUS": return new SerializableMacroCommand(MacroCommandKey.SwitchToStatsPane);
                case "GS_CHAT": return new SerializableMacroCommand(MacroCommandKey.SwitchToChatPane);
                case "GS_INVENTORY": return new SerializableMacroCommand(MacroCommandKey.SwitchToInventoryPane);
                case "GS_MEDSKILL": return new SerializableMacroCommand(MacroCommandKey.SwitchToMedeniaSkillPane);
                case "GS_MEDSPELL": return new SerializableMacroCommand(MacroCommandKey.SwitchToMedeniaSpellPane);
                case "GS_TEMSKILL": return new SerializableMacroCommand(MacroCommandKey.SwitchToTemuairSkillPane);
                case "GS_TEMSPELL": return new SerializableMacroCommand(MacroCommandKey.SwitchToTemuairSpellPane);
                case "KB_SENDKEYS":
                    {
                        var keysParameter = DeserializeParameter(tokens[1], MacroParameterType.Keystrokes);
                        return new SerializableMacroCommand(MacroCommandKey.SendKeystrokes, keysParameter);
                    }
                case "LO_BREAK": return new SerializableMacroCommand(MacroCommandKey.Break);
                case "LO_ELSE": return new SerializableMacroCommand(MacroCommandKey.Else);
                case "LO_ENDIF": return new SerializableMacroCommand(MacroCommandKey.EndIf);
                case "LO_ENDWHILE": return new SerializableMacroCommand(MacroCommandKey.EndWhile);
                case "LO_IFHPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfHealthValue, opParameter, hpParameter);
                    }
                case "LO_IFHPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfHealthValue, opParameter, hpParameter);
                    }
                case "LO_IFHPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfHealthValue, opParameter, hpParameter);
                    }
                case "LO_IFHPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfHealthValue, opParameter, hpParameter);
                    }
                case "LO_IFMAPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapNumber, opParameter, mapParameter);
                    }
                case "LO_IFMAPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapNumber, opParameter, mapParameter);
                    }
                case "LO_IFMAPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapNumber, opParameter, mapParameter);
                    }
                case "LO_IFMAPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapNumber, opParameter, mapParameter);
                    }
                case "LO_IFMPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfManaValue, opParameter, mpParameter);
                    }
                case "LO_IFMPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfManaValue, opParameter, mpParameter);
                    }
                case "LO_IFMPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfManaValue, opParameter, mpParameter);
                    }
                case "LO_IFMPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfManaValue, opParameter, mpParameter);
                    }
                case "LO_IFXL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapX, opParameter, xParameter);
                    }
                case "LO_IFXE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapX, opParameter, xParameter);
                    }
                case "LO_IFXG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapX, opParameter, xParameter);
                    }
                case "LO_IFXN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapX, opParameter, xParameter);
                    }
                case "LO_IFYL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapY, opParameter, yParameter);
                    }
                case "LO_IFYE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapY, opParameter, yParameter);
                    }
                case "LO_IFYG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapY, opParameter, yParameter);
                    }
                case "LO_IFYN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.IfMapY, opParameter, yParameter);
                    }
                case "LO_WHILEHPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileHealthValue, opParameter, hpParameter);
                    }
                case "LO_WHILEHPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileHealthValue, opParameter, hpParameter);
                    }
                case "LO_WHILEHPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileHealthValue, opParameter, hpParameter);
                    }
                case "LO_WHILEHPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var hpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileHealthValue, opParameter, hpParameter);
                    }
                case "LO_WHILEMAPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapNumber, opParameter, mapParameter);
                    }
                case "LO_WHILEMAPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapNumber, opParameter, mapParameter);
                    }
                case "LO_WHILEMAPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapNumber, opParameter, mapParameter);
                    }
                case "LO_WHILEMAPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var mapParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapNumber, opParameter, mapParameter);
                    }
                case "LO_WHILEMPL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileManaValue, opParameter, mpParameter);
                    }
                case "LO_WHILEMPE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileManaValue, opParameter, mpParameter);
                    }
                case "LO_WHILEMPG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileManaValue, opParameter, mpParameter);
                    }
                case "LO_WHILEMPN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var mpParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileManaValue, opParameter, mpParameter);
                    }
                case "LO_WHILEXL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapX, opParameter, xParameter);
                    }
                case "LO_WHILEXE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapX, opParameter, xParameter);
                    }
                case "LO_WHILEXG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapX, opParameter, xParameter);
                    }
                case "LO_WHILEXN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapX, opParameter, xParameter);
                    }
                case "LO_WHILEYL":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.LessThan);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapY, opParameter, yParameter);
                    }
                case "LO_WHILEYE":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.Equal);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapY, opParameter, yParameter);
                    }
                case "LO_WHILEYG":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.GreaterThan);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapY, opParameter, yParameter);
                    }
                case "LO_WHILEYN":
                    {
                        var opParameter = new SerializableMacroParameter(MacroParameterType.CompareOperator, CompareOperator.NotEqual);
                        var yParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WhileMapY, opParameter, yParameter);
                    }
                case "LP_BREAK": return new SerializableMacroCommand(MacroCommandKey.Break);
                case "LP_GOTO":
                    {
                        var lineNumberParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.GotoLine, lineNumberParameter);
                    }
                case "LP_END": return new SerializableMacroCommand(MacroCommandKey.EndLoop);
                case "LP_RESET": return new SerializableMacroCommand(MacroCommandKey.LoopReset);
                case "LP_RESTART": return new SerializableMacroCommand(MacroCommandKey.Continue);
                case "LP_START":
                    {
                        var countParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        var count = Convert.ToInt64(countParameter.Value);

                        return count > 0
                            ? new SerializableMacroCommand(MacroCommandKey.LoopCount, countParameter)
                            : new SerializableMacroCommand(MacroCommandKey.LoopInfinite);
                    }
                case "MO_LEFTCLICK": return new SerializableMacroCommand(MacroCommandKey.MouseLeftClick);
                case "MO_RIGHTCLICK": return new SerializableMacroCommand(MacroCommandKey.MouseRightClick);
                case "MO_MOVE":
                    {
                        var xParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        var yParameter = DeserializeParameter(tokens[2], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.MouseMove, xParameter, yParameter);
                    }
                case "MO_RECALL": return new SerializableMacroCommand(MacroCommandKey.MouseRecallPosition);
                case "MO_SAVE": return new SerializableMacroCommand(MacroCommandKey.MouseSavePosition);
                case "TI_WAIT":
                    {
                        var delayParameter = DeserializeParameter(tokens[1], MacroParameterType.Integer);
                        return new SerializableMacroCommand(MacroCommandKey.WaitDelay, delayParameter);
                    }
                default:
                    throw new FormatException($"Invalid command: {command}");
            }
        }

        public SerializableMacroParameter DeserializeParameter(string value, MacroParameterType expectedType)
        {
            if (expectedType == MacroParameterType.Boolean)
            {
                var boolValue = bool.Parse(value.Trim());
                return new SerializableMacroParameter(expectedType, boolValue);
            }
            
            if (expectedType == MacroParameterType.Integer)
            {
                var longValue = long.Parse(value.Trim());
                return new SerializableMacroParameter(expectedType, longValue);
            }
            
            if (expectedType == MacroParameterType.Float)
            {
                var doubleValue = double.Parse(value.Trim());
                return new SerializableMacroParameter(expectedType, doubleValue);
            }
            
            if (expectedType == MacroParameterType.String)
            {
                return new SerializableMacroParameter(expectedType, value);
            }
            
            if (expectedType == MacroParameterType.Keystrokes)
            {
                // TODO: 
                
            }

            throw new FormatException($"Invalid value format: {value}");
        }

    }
}
