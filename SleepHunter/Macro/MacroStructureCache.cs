using System;
using System.Collections.Generic;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Commands.Jump;
using SleepHunter.Macro.Commands.Logic;
using SleepHunter.Macro.Commands.Loop;

namespace SleepHunter.Macro
{
    public sealed class MacroStructureCache : IMacroStructureCache
    {
        // If/Else/EndIf mappings
        private readonly Dictionary<int, int> ifToElse = new Dictionary<int, int>();
        private readonly Dictionary<int, int> ifToEndIf = new Dictionary<int, int>();
        private readonly Dictionary<int, int> elseToEndIf = new Dictionary<int, int>();

        // While mappings
        private readonly Dictionary<int, int> whileToEndWhile = new Dictionary<int, int>();
        private readonly Dictionary<int, int> endWhileToWhile = new Dictionary<int, int>();

        // Loop mappings
        private readonly Dictionary<int, int> loopToEndLoop = new Dictionary<int, int>();
        private readonly Dictionary<int, int> endLoopToLoop = new Dictionary<int, int>();

        // Break/Continue mappings
        private readonly Dictionary<int, List<(int Start, int End)>> commandToWhileBlock =
            new Dictionary<int, List<(int Start, int End)>>();

        private readonly Dictionary<int, List<(int Start, int End)>> commandToLoopBlock =
            new Dictionary<int, List<(int Start, int End)>>();

        // Labels mappings
        private readonly Dictionary<string, int> labels = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public IReadOnlyDictionary<string, int> Labels => labels;

        public MacroStructureCache(IReadOnlyList<IMacroCommand> commands)
        {
            BuildStructure(commands);
            BuildContainmentMaps(commands);
        }

        #region If/Else/EndIf Methods

        public int GetElseIndex(int ifIndex) =>
            ifToElse.TryGetValue(ifIndex, out var elseIndex) ? elseIndex : -1;

        public int GetEndIfIndex(int ifIndex)
            => ifToEndIf.TryGetValue(ifIndex, out var endIfIndex) ? endIfIndex : -1;

        public int GetEndIfIndexFromElse(int elseIndex)
            => elseToEndIf.TryGetValue(elseIndex, out var endIfIndex) ? endIfIndex : -1;

        #endregion

        #region While Methods

        public int GetWhileIndex(int endWhileIndex)
            => endWhileToWhile.TryGetValue(endWhileIndex, out var whileIndex) ? whileIndex : -1;

        public int GetEndWhileIndex(int whileIndex)
            => whileToEndWhile.TryGetValue(whileIndex, out var endWhileIndex) ? endWhileIndex : -1;

        public bool IsInsideWhile(int commandIndex) =>
            commandToWhileBlock.ContainsKey(commandIndex);

        public int GetInnerWhileIndex(int commandIndex)
        {
            if (!commandToWhileBlock.TryGetValue(commandIndex, out var list) || list.Count == 0)
            {
                return -1;
            }

            return list[list.Count - 1].Start;
        }

        #endregion

        #region Loop Methods

        public int GetLoopIndex(int endLoopIndex)
            => endLoopToLoop.TryGetValue(endLoopIndex, out var loopIndex) ? loopIndex : -1;

        public int GetEndLoopIndex(int loopIndex)
            => loopToEndLoop.TryGetValue(loopIndex, out var endLoopIndex) ? endLoopIndex : -1;

        public bool IsInsideLoop(int commandIndex) =>
            commandToLoopBlock.ContainsKey(commandIndex);

        public int GetInnerLoopIndex(int commandIndex)
        {
            if (!commandToLoopBlock.TryGetValue(commandIndex, out var list) || list.Count == 0)
            {
                return -1;
            }

            return list[list.Count - 1].Start;
        }

        #endregion

        private void BuildStructure(IReadOnlyList<IMacroCommand> commands)
        {
            var ifStack = new Stack<int>();
            var whileStack = new Stack<int>();
            var loopStack = new Stack<int>();

            for (var i = 0; i < commands.Count; i++)
            {
                var command = commands[i];

                switch (command)
                {
                    // If/Else/EndIf processing
                    case IfCommand _:
                        ifStack.Push(i);
                        break;

                    case ElseCommand _:
                        if (ifStack.Count == 0)
                        {
                            throw new MacroValidationException("Else has no matching If command", i);
                        }

                        var ifIndex = ifStack.Peek();
                        ifToElse[ifIndex] = i;
                        break;

                    case EndIfCommand _:
                        if (ifStack.Count == 0)
                        {
                            throw new MacroValidationException("EndIf has no matching If command", i);
                        }

                        var matchingIf = ifStack.Pop();
                        ifToEndIf[matchingIf] = i;

                        // If there was an else in this block, map it too
                        if (ifToElse.TryGetValue(matchingIf, out var elseIndex))
                        {
                            elseToEndIf[elseIndex] = i;
                        }

                        break;

                    // Loop processing
                    case LoopCommand _:
                        loopStack.Push(i);
                        break;

                    case EndLoopCommand _:
                        if (loopStack.Count == 0)
                        {
                            throw new MacroValidationException("EndLoop has no matching Loop command", i);
                        }

                        var matchingLoop = loopStack.Pop();
                        loopToEndLoop[matchingLoop] = i;
                        endLoopToLoop[i] = matchingLoop;
                        break;

                    // While processing
                    case WhileCommand _:
                        whileStack.Push(i);
                        break;

                    case EndWhileCommand _:
                        if (whileStack.Count == 0)
                        {
                            throw new MacroValidationException("EndWhile has no matching While command", i);
                        }

                        var matchingWhile = whileStack.Pop();
                        whileToEndWhile[matchingWhile] = i;
                        endWhileToWhile[i] = matchingWhile;
                        break;

                    // Label processing
                    case DefineLabelCommand labelCommand:
                        if (labels.ContainsKey(labelCommand.Label))
                        {
                            throw new MacroValidationException($"Duplicate label '{labelCommand.Label}'", i);
                        }

                        labels[labelCommand.Label] = i;
                        break;
                }
            }

            if (ifStack.Count > 0)
            {
                throw new MacroValidationException("Unterminated If command", ifStack.Peek());
            }

            if (whileStack.Count > 0)
            {
                throw new MacroValidationException("Unterminated While command", whileStack.Peek());
            }

            if (loopStack.Count > 0)
            {
                throw new MacroValidationException("Unterminated Loop command", loopStack.Peek());
            }
        }

        private void BuildContainmentMaps(IReadOnlyList<IMacroCommand> commands)
        {
            // Build maps of which commands are inside which while/loop blocks
            // We can use our existing loop and while dictionaries to do this

            foreach (var range in whileToEndWhile)
            {
                var whileStart = range.Key;
                var whileEnd = range.Value;

                for (var i = whileStart; i < whileEnd; i++)
                {
                    if (!commandToWhileBlock.TryGetValue(i, out var list))
                    {
                        list = new List<(int Start, int End)>();
                        commandToWhileBlock[i] = list;
                    }

                    list.Add((whileStart, whileEnd));
                }
            }

            foreach (var range in loopToEndLoop)
            {
                var loopStart = range.Key;
                var loopEnd = range.Value;

                for (var i = loopStart; i < loopEnd; i++)
                {
                    if (!commandToLoopBlock.TryGetValue(i, out var list))
                    {
                        list = new List<(int Start, int End)>();
                        commandToLoopBlock[i] = list;
                    }

                    list.Add((loopStart, loopEnd));
                }
            }
        }
    }
}