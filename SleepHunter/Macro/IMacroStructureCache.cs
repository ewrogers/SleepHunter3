using System.Collections.Generic;

namespace SleepHunter.Macro
{
    public interface IMacroStructureCache
    {
        IReadOnlyDictionary<string, int> Labels { get; }
        
        int GetElseIndex(int ifIndex);
        int GetEndIfIndex(int ifIndex);
        int GetEndIfIndexFromElse(int elseIndex);

        int GetWhileIndex(int endWhileIndex);
        int GetEndWhileIndex(int whileIndex);
        bool IsInsideWhile(int commandIndex);
        int GetInnerWhileIndex(int commandIndex);
        
        int GetLoopIndex(int endLoopIndex);
        int GetEndLoopIndex(int loopIndex);
        bool IsInsideLoop(int commandIndex);
        int GetInnerLoopIndex(int commandIndex);
    }
}