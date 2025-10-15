
namespace SleepHunter
{
    public class LogicStructure
    {
        public LogicStructure.LogicItem[] CreateLogicStructure(string[] CommandList, string[] Args)
        {
            LogicStructure.LogicItem[] logicStructure = new LogicStructure.LogicItem[this.GetLogicCount(CommandList)];
            if (logicStructure.Length < 1)
                return (LogicStructure.LogicItem[])null;
            int num1 = 1;
            int index = 0;
            foreach (string command in CommandList)
            {
                logicStructure[index].CommandType = this.GetLogicType(command);
                if (logicStructure[index].CommandType != LogicStructure.LogicCommandType.NonLogic)
                {
                    if (command.EndsWith("G"))
                        logicStructure[index].CompareType = LogicStructure.CompareOpType.GreaterThan;
                    if (command.EndsWith("L"))
                        logicStructure[index].CompareType = LogicStructure.CompareOpType.LessThan;
                    if (command.EndsWith("E"))
                        logicStructure[index].CompareType = LogicStructure.CompareOpType.EqualTo;
                    if (command.EndsWith("N"))
                        logicStructure[index].CompareType = LogicStructure.CompareOpType.NotEqualTo;
                    int startIndex = 0;
                    switch (logicStructure[index].CommandType)
                    {
                        case LogicStructure.LogicCommandType.IfStatement:
                            startIndex = 5;
                            break;
                        case LogicStructure.LogicCommandType.WhileStatement:
                            startIndex = 8;
                            break;
                        case LogicStructure.LogicCommandType.LoopStatement:
                            startIndex = -1;
                            break;
                    }
                    if (startIndex > 0)
                    {
                        if (command.IndexOf("HP", startIndex) > 0)
                            logicStructure[index].CriteriaType = LogicStructure.CompareCriteriaType.HP;
                        if (command.IndexOf("MP", startIndex) > 0)
                            logicStructure[index].CriteriaType = LogicStructure.CompareCriteriaType.MP;
                        if (command.IndexOf("MAP", startIndex) > 0)
                            logicStructure[index].CriteriaType = LogicStructure.CompareCriteriaType.MAP;
                        if (command.IndexOf("X", startIndex) > 0)
                            logicStructure[index].CriteriaType = LogicStructure.CompareCriteriaType.XLOC;
                        if (command.IndexOf("Y", startIndex) > 0)
                            logicStructure[index].CriteriaType = LogicStructure.CompareCriteriaType.YLOC;
                    }
                    long.TryParse(Args[num1 - 1], out logicStructure[index].Value);
                    ++index;
                    if (index > logicStructure.Length - 1)
                        break;
                }
                ++num1;
            }
            int num2 = 0;
            int num3 = 1;
            foreach (string command in CommandList)
            {
                if (this.IsAStartLogicCommand(command))
                {
                    ++num2;
                    while (logicStructure[num2 - 1].Handled)
                    {
                        ++num2;
                        if (num2 > logicStructure.Length)
                            break;
                    }
                    logicStructure[num2 - 1].StartLine = num3;
                }
                if (num2 > 0 && this.IsAnElseCommand(command) & !logicStructure[num2 - 1].HasElse)
                {
                    logicStructure[num2 - 1].HasElse = true;
                    logicStructure[num2 - 1].ElseLine = num3;
                }
                if (this.IsAnEndCommand(command) & this.GetLogicType(command) == logicStructure[num2 - 1].CommandType)
                {
                    logicStructure[num2 - 1].EndLine = num3;
                    logicStructure[num2 - 1].Handled = true;
                    --num2;
                    if (num2 > 0)
                    {
                        while (logicStructure[num2 - 1].Handled)
                        {
                            --num2;
                            if (num2 == 0)
                                break;
                        }
                    }
                }
                ++num3;
            }
            return logicStructure;
        }

        public ulong GetLogicCount(string[] CommandList)
        {
            ulong logicCount = 0;
            foreach (string command in CommandList)
            {
                if (command.Trim().StartsWith("LO_IF") | command.Trim().StartsWith("LO_WHILE") | command.Trim().StartsWith("LP_START"))
                    ++logicCount;
            }
            return logicCount;
        }

        public LogicStructure.LogicCommandType GetLogicType(string ArgCode)
        {
            if (ArgCode.IndexOf("IF", 3) > 0)
                return LogicStructure.LogicCommandType.IfStatement;
            if (ArgCode.IndexOf("WHILE", 3) > 0)
                return LogicStructure.LogicCommandType.WhileStatement;
            return ArgCode.StartsWith("LP") ? LogicStructure.LogicCommandType.LoopStatement : LogicStructure.LogicCommandType.NonLogic;
        }

        public bool IsAStartLogicCommand(string ArgCode)
        {
            return ArgCode.Trim().StartsWith("LO_IF") | ArgCode.Trim().StartsWith("LO_WHILE") | ArgCode.Trim().StartsWith("LP_START");
        }

        public bool IsAnEndCommand(string ArgCode)
        {
            return ArgCode.Trim().StartsWith("LO_END") | ArgCode.Trim().StartsWith("LP_END");
        }

        public bool IsAnElseCommand(string ArgCode) => ArgCode.Trim().StartsWith("LO_ELSE");

        public bool IsABreakCommand(string ArgCode)
        {
            return ArgCode.Trim().StartsWith("LO_BREAK") | ArgCode.Trim().StartsWith("LP_BREAK");
        }

        public int GetLogicStartRef(LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            int logicStartRef = 0;
            foreach (LogicStructure.LogicItem logicItem in LogicData)
            {
                if (logicItem.StartLine == LineNo)
                    return logicStartRef;
                ++logicStartRef;
            }
            return -1;
        }

        public int GetLogicElseRef(LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            int logicElseRef = 0;
            foreach (LogicStructure.LogicItem logicItem in LogicData)
            {
                if (logicItem.ElseLine == LineNo)
                    return logicElseRef;
                ++logicElseRef;
            }
            return -1;
        }

        public int GetLogicEndRef(LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            int logicEndRef = 0;
            foreach (LogicStructure.LogicItem logicItem in LogicData)
            {
                if (logicItem.EndLine == LineNo)
                    return logicEndRef;
                ++logicEndRef;
            }
            return -1;
        }

        public int GetWithinRef(int ListItemCount, LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            for (int LineNo1 = LineNo; LineNo1 <= ListItemCount & LineNo1 > 0; --LineNo1)
            {
                int logicStartRef = this.GetLogicStartRef(LogicData, LineNo1);
                if (logicStartRef >= 0)
                    return logicStartRef;
            }
            return -1;
        }

        public int GetWithinLoopRef(int ListItemCount, LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            for (int LineNo1 = LineNo; LineNo1 <= ListItemCount & LineNo1 > 0; --LineNo1)
            {
                int logicStartRef = this.GetLogicStartRef(LogicData, LineNo1);
                if (logicStartRef >= 0 && LogicData[logicStartRef].CommandType == LogicStructure.LogicCommandType.LoopStatement)
                    return logicStartRef;
            }
            return -1;
        }

        public int GetLoopRefByEnd(LogicStructure.LogicItem[] LogicData, int LineNo)
        {
            int loopRefByEnd = 0;
            foreach (LogicStructure.LogicItem logicItem in LogicData)
            {
                if (logicItem.EndLine == LineNo)
                    return loopRefByEnd;
                ++loopRefByEnd;
            }
            return -1;
        }

        public int GetLoopDataRef(LogicStructure.LoopData[] LoopData, int StartLine)
        {
            int loopDataRef = 0;
            foreach (LogicStructure.LoopData loopData in LoopData)
            {
                if (loopData.LineNo == StartLine)
                    return loopDataRef;
                ++loopDataRef;
            }
            return -1;
        }

        public enum CompareOpType
        {
            None,
            GreaterThan,
            LessThan,
            EqualTo,
            NotEqualTo,
        }

        public enum LogicCommandType
        {
            NonLogic,
            IfStatement,
            WhileStatement,
            LoopStatement,
        }

        public enum CompareCriteriaType
        {
            NONE,
            HP,
            MP,
            MAP,
            XLOC,
            YLOC,
        }

        public struct LogicItem
        {
            public LogicStructure.LogicCommandType CommandType;
            public LogicStructure.CompareOpType CompareType;
            public LogicStructure.CompareCriteriaType CriteriaType;
            public bool HasElse;
            public bool Handled;
            public long Value;
            public int StartLine;
            public int EndLine;
            public int ElseLine;
            public object Tag;
        }

        public struct LoopData
        {
            public ulong LoopCounter;
            public ulong LoopMax;
            public int LineNo;
        }
    }
}