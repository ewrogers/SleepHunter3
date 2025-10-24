namespace SleepHunter.Macro
{
    public sealed class MacroLoopState
    {
        public MacroLoopType LoopType { get; set; } = MacroLoopType.Loop;
        public int LoopStartIndex { get; set; }
        public int EndLoopIndex { get; set; }
        public int CurrentIteration { get; set; }
        public int MaxIterations { get; set; }
        public bool IsInfinite => MaxIterations < 1;
    }
}