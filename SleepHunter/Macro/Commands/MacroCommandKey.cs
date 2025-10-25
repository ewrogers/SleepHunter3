
namespace SleepHunter.Macro.Commands
{
    public static class MacroCommandKey
    {
        // Interface Commands
        public const string SwitchToInventoryPane = "SWITCH_TO_INVENTORY";
        public const string SwitchToTemuairSkillPane = "SWITCH_TO_TEMUAIR_SKILL";
        public const string SwitchToTemuairSpellPane = "SWITCH_TO_TEMUAIR_SPELL";
        public const string SwitchToMedeniaSkillPane = "SWITCH_TO_MEDENIA_SKILL";
        public const string SwitchToMedeniaSpellPane = "SWITCH_TO_MEDENIA_SPELL";
        public const string SwitchToChatPane = "SWITCH_TO_CHAT";
        public const string SwitchToChatHistoryPane = "SWITCH_TO_CHAT_HISTORY";
        public const string SwitchToStatsPane = "SWITCH_TO_STATS";
        public const string SwitchToModifiersPane = "SWITCH_TO_MODIFIERS";
        public const string SwitchToWorldSkillSpellPane = "SWITCH_TO_WORLD_SKILL_SPELL";
        public const string IfChatInputOpen = "IF_CHAT_INPUT_OPEN";
        public const string WhileChatInputOpen = "WHILE_CHAT_INPUT_OPEN";
        public const string IfMinimizedMode = "IF_MINIMIZED_MODE";
        public const string IfInventoryExpanded = "IF_INVENTORY_EXPANDED";

        // Map Commands
        public const string IfMapName = "IF_MAP_NAME";
        public const string IfMapNumber = "IF_MAP_NUMBER";
        public const string IfMapX = "IF_MAP_X";
        public const string IfMapY = "IF_MAPY";
        public const string WhileMapName = "WHILE_MAP_NAME";
        public const string WhileMapNumber = "WHILE_MAP_NUMBER";
        public const string WhileMapX = "WHILE_MAP_X";
        public const string WhileMapY = "WHILE_MAP_Y";

        // Health Commands
        public const string IfHealthValue = "IF_HP_VALUE";
        public const string IfHealthPercent = "IF_HP_PERCENT";
        public const string WhileHealthValue = "WHILE_HP_VALUE";
        public const string WhileHealthPercent = "WHILE_HP_PERCENT";

        // Mana Commands
        public const string IfManaValue = "IF_MP_VALUE";
        public const string IfManaPercent = "IF_MP_PERCENT";
        public const string WhileManaValue = "WHILE_MP_VALUE";
        public const string WhileManaPercent = "WHILE_MP_PERCENT";

        // Keyboard Commands
        public const string SendKeystrokes = "KEYBOARD_SEND_KEYS";

        // Mouse Commands
        public const string MouseLeftClick = "MOUSE_LEFT_CLICK";
        public const string MouseLeftDoubleClick = "MOUSE_LEFT_DOUBLE_CLICK";
        public const string MouseRightClick = "MOUSE_RIGHT_CLICK";
        public const string MouseRightDoubleClick = "MOUSE_RIGHT_DOUBLE_CLICK";
        public const string MouseLeftButtonDown = "MOUSE_LEFT_BUTTON_DOWN";
        public const string MouseLeftButtonUp = "MOUSE_LEFT_BUTTON_UP";
        public const string MouseRightButtonDown = "MOUSE_RIGHT_BUTTON_DOWN";
        public const string MouseRightButtonUp = "MOUSE_RIGHT_BUTTON_UP";
        public const string MouseMove = "MOUSE_MOVE";
        public const string MouseMoveOffset = "MOUSE_MOVE_OFFSET";
        public const string MouseSavePosition = "MOUSE_SAVE_POSITION";
        public const string MouseRecallPosition = "MOUSE_RECALL_POSITION";

        // If Commands
        public const string Else = "ELSE";
        public const string EndIf = "IF_END";

        // Loop Commands
        public const string LoopInfinite = "LOOP_INFINITE";
        public const string LoopCount = "LOOP_COUNT";
        public const string LoopReset = "LOOP_RESET";
        public const string Continue = "CONTINUE";
        public const string Break = "BREAK";
        public const string EndLoop = "LOOP_END";
        public const string EndWhile = "WHILE_END";

        // Jump Commands
        public const string DefineLabel = "DEFINE_LABEL";
        public const string GotoLabel = "GOTO_LABEL";
        public const string GotoLine = "GOTO_LINE";

        // Wait Commands
        public const string WaitDelay = "WAIT_DELAY";
    }
}
