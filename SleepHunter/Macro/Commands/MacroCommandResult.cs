using System;

namespace SleepHunter.Macro.Commands
{
    public readonly struct MacroCommandResult
    {
        public static MacroCommandResult Continue => new MacroCommandResult(MacroCommandResultAction.Continue);
        public static MacroCommandResult Pause => new MacroCommandResult(MacroCommandResultAction.Pause);
        public static MacroCommandResult Stop => new MacroCommandResult(MacroCommandResultAction.Stop);

        public MacroCommandResultAction Action { get; }
        public int? JumpIndex { get; }
        public string JumpLabel { get; }

        private MacroCommandResult(MacroCommandResultAction action, int? jumpToIndex = null, string jumpToLabel = null)
        {
            Action = action;
            JumpIndex = jumpToIndex;
            JumpLabel = jumpToLabel;
        }

        public override string ToString()
        {
            if (Action == MacroCommandResultAction.Jump)
            {
                return JumpIndex.HasValue ? $"Jump to line {JumpIndex.Value + 1}" : $"Jump to label @{JumpLabel}";
            }

            return Action.ToString();
        }

        public static MacroCommandResult JumpToLine(int lineNumber)
            => new MacroCommandResult(MacroCommandResultAction.Jump, jumpToIndex: Math.Max(0, lineNumber - 1));

        public static MacroCommandResult JumpToIndex(int index)
            => new MacroCommandResult(MacroCommandResultAction.Jump, jumpToIndex: Math.Max(0, index));

        public static MacroCommandResult JumpToLabel(string label)
            => new MacroCommandResult(MacroCommandResultAction.Jump, jumpToLabel: label);
    }
}