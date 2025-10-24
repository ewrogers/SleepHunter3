using System.Collections.Generic;

namespace SleepHunter.Macro
{
    public interface IMacroStructureCache
    {
        IReadOnlyDictionary<string, int> Labels { get; }
        
        int GetElseIndex(int ifIndex);
        int GetEndIfIndex(int ifIndex);
        int GetEndIfIndexFromElse(int elseIndex);

        int GetLoopIndex(int endLoopIndex);
        int GetEndLoopIndex(int loopIndex);

        int GetWhileIndex(int endWhileIndex);
        int GetEndWhileIndex(int whileIndex);
    }
}