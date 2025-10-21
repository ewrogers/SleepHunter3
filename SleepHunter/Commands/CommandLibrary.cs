using System;

namespace SleepHunter.Commands
{

    internal class CommandLibrary
    {
        public int GetArgumentCount(string ArgCode)
        {
            switch (ArgCode.ToUpper())
            {
                case "GS_STATUS":
                    return 0;
                case "GS_CHAT":
                    return 0;
                case "GS_INVENTORY":
                    return 0;
                case "GS_MEDSKILL":
                    return 0;
                case "GS_MEDSPELL":
                    return 0;
                case "GS_TEMSKILL":
                    return 0;
                case "GS_TEMSPELL":
                    return 0;
                case "KB_SENDKEYS":
                    return 1;
                case "LO_BREAK":
                    return 0;
                case "LO_ELSE":
                    return 0;
                case "LO_ENDIF":
                    return 0;
                case "LO_ENDWHILE":
                    return 0;
                case "LO_IFHPL":
                    return 1;
                case "LO_IFHPE":
                    return 1;
                case "LO_IFHPG":
                    return 1;
                case "LO_IFHPN":
                    return 1;
                case "LO_IFMAPL":
                    return 1;
                case "LO_IFMAPE":
                    return 1;
                case "LO_IFMAPG":
                    return 1;
                case "LO_IFMAPN":
                    return 1;
                case "LO_IFMPL":
                    return 1;
                case "LO_IFMPE":
                    return 1;
                case "LO_IFMPG":
                    return 1;
                case "LO_IFMPN":
                    return 1;
                case "LO_IFXL":
                    return 1;
                case "LO_IFXE":
                    return 1;
                case "LO_IFXG":
                    return 1;
                case "LO_IFXN":
                    return 1;
                case "LO_IFYL":
                    return 1;
                case "LO_IFYE":
                    return 1;
                case "LO_IFYG":
                    return 1;
                case "LO_IFYN":
                    return 1;
                case "LO_WHILEHPL":
                    return 1;
                case "LO_WHILEHPE":
                    return 1;
                case "LO_WHILEHPG":
                    return 1;
                case "LO_WHILEHPN":
                    return 1;
                case "LO_WHILEMAPL":
                    return 1;
                case "LO_WHILEMAPE":
                    return 1;
                case "LO_WHILEMAPG":
                    return 1;
                case "LO_WHILEMAPN":
                    return 1;
                case "LO_WHILEMPL":
                    return 1;
                case "LO_WHILEMPE":
                    return 1;
                case "LO_WHILEMPG":
                    return 1;
                case "LO_WHILEMPN":
                    return 1;
                case "LO_WHILEXL":
                    return 1;
                case "LO_WHILEXE":
                    return 1;
                case "LO_WHILEXG":
                    return 1;
                case "LO_WHILEXN":
                    return 1;
                case "LO_WHILEYL":
                    return 1;
                case "LO_WHILEYE":
                    return 1;
                case "LO_WHILEYG":
                    return 1;
                case "LO_WHILEYN":
                    return 1;
                case "LP_BREAK":
                    return 0;
                case "LP_GOTO":
                    return 1;
                case "LP_END":
                    return 0;
                case "LP_RESET":
                    return 0;
                case "LP_RESTART":
                    return 0;
                case "LP_START":
                    return 1;
                case "MO_LEFTCLICK":
                    return 0;
                case "MO_MOVE":
                    return 2;
                case "MO_RECALL":
                    return 0;
                case "MO_RIGHTCLICK":
                    return 0;
                case "MO_SAVE":
                    return 0;
                case "TI_WAIT":
                    return 1;
                default:
                    return -1;
            }
        }

        public string GetFormattedString(string ArgCode, string[] Args)
        {
            switch (ArgCode.ToUpper())
            {
                case "GS_STATUS":
                    return "Switch to Status Pane";
                case "GS_CHAT":
                    return "Switch to Chat Pane";
                case "GS_INVENTORY":
                    return "Switch to Inventory Pane";
                case "GS_MEDSKILL":
                    return "Switch to Medenia Skill Pane";
                case "GS_MEDSPELL":
                    return "Switch to Medenia Spell Pane";
                case "GS_TEMSKILL":
                    return "Switch to Temuair Skill Pane";
                case "GS_TEMSPELL":
                    return "Switch to Temuair Spell Pane";
                case "KB_SENDKEYS":
                    return "Send Keystrokes: " + Args[0];
                case "LO_BREAK":
                    return "Break";
                case "LO_ELSE":
                    return "Else";
                case "LO_ENDIF":
                    return "End If";
                case "LO_ENDWHILE":
                    return "End While";
                case "LO_IFHPL":
                    return "If HP < " + Args[0];
                case "LO_IFHPE":
                    return "If HP = " + Args[0];
                case "LO_IFHPG":
                    return "If HP > " + Args[0];
                case "LO_IFHPN":
                    return "If HP ≠ " + Args[0];
                case "LO_IFMAPL":
                    return "If MAP < " + Args[0];
                case "LO_IFMAPE":
                    return "If MAP = " + Args[0];
                case "LO_IFMAPG":
                    return "If MAP > " + Args[0];
                case "LO_IFMAPN":
                    return "If MAP ≠ " + Args[0];
                case "LO_IFMPL":
                    return "If MP < " + Args[0];
                case "LO_IFMPE":
                    return "If MP = " + Args[0];
                case "LO_IFMPG":
                    return "If MP > " + Args[0];
                case "LO_IFMPN":
                    return "If MP ≠ " + Args[0];
                case "LO_IFXL":
                    return "If X < " + Args[0];
                case "LO_IFXE":
                    return "If X = " + Args[0];
                case "LO_IFXG":
                    return "If X > " + Args[0];
                case "LO_IFXN":
                    return "If X ≠ " + Args[0];
                case "LO_IFYL":
                    return "If Y < " + Args[0];
                case "LO_IFYE":
                    return "If Y = " + Args[0];
                case "LO_IFYG":
                    return "If Y > " + Args[0];
                case "LO_IFYN":
                    return "If Y ≠ " + Args[0];
                case "LO_WHILEHPL":
                    return "While HP < " + Args[0];
                case "LO_WHILEHPE":
                    return "While HP = " + Args[0];
                case "LO_WHILEHPG":
                    return "While HP > " + Args[0];
                case "LO_WHILEHPN":
                    return "While HP ≠ " + Args[0];
                case "LO_WHILEMAPL":
                    return "While MAP < " + Args[0];
                case "LO_WHILEMAPE":
                    return "While MAP = " + Args[0];
                case "LO_WHILEMAPG":
                    return "While MAP > " + Args[0];
                case "LO_WHILEMAPN":
                    return "While MAP ≠ " + Args[0];
                case "LO_WHILEMPL":
                    return "While MP < " + Args[0];
                case "LO_WHILEMPE":
                    return "While MP = " + Args[0];
                case "LO_WHILEMPG":
                    return "While MP > " + Args[0];
                case "LO_WHILEMPN":
                    return "While MP ≠ " + Args[0];
                case "LO_WHILEXL":
                    return "While X < " + Args[0];
                case "LO_WHILEXE":
                    return "While X = " + Args[0];
                case "LO_WHILEXG":
                    return "While X > " + Args[0];
                case "LO_WHILEXN":
                    return "While X ≠ " + Args[0];
                case "LO_WHILEYL":
                    return "While Y < " + Args[0];
                case "LO_WHILEYE":
                    return "While Y = " + Args[0];
                case "LO_WHILEYG":
                    return "While Y > " + Args[0];
                case "LO_WHILEYN":
                    return "While Y ≠ " + Args[0];
                case "LP_BREAK":
                    return "Break";
                case "LP_GOTO":
                    return "Goto Line " + Args[0];
                case "LP_END":
                    return "Loop End";
                case "LP_RESET":
                    return "Loop Reset";
                case "LP_RESTART":
                    return "Loop Restart";
                case "LP_START":
                    return $"Loop Start ({Args[0]} Repeats)";
                case "MO_LEFTCLICK":
                    return "Left Click";
                case "MO_MOVE":
                    return $"Move Mouse to {Args[0]},{Args[1]}";
                case "MO_RECALL":
                    return "Recall Mouse Position";
                case "MO_RIGHTCLICK":
                    return "Right Click";
                case "MO_SAVE":
                    return "Save Mouse Position";
                case "TI_WAIT":
                    return $"Wait {Args[0]} milliseconds";
                default:
                    return $"UNKNOWN COMMAND: {ArgCode} - {Args.Length.ToString()} Arguments";
            }
        }

        public string GetArgumentHelp(string ArgCode)
        {
            switch (ArgCode.ToUpper())
            {
                case "GS_STATUS":
                    return (string)null;
                case "GS_CHAT":
                    return (string)null;
                case "GS_INVENTORY":
                    return (string)null;
                case "GS_MEDSKILL":
                    return (string)null;
                case "GS_MEDSPELL":
                    return (string)null;
                case "GS_TEMSKILL":
                    return (string)null;
                case "GS_TEMSPELL":
                    return (string)null;
                case "KB_SENDKEYS":
                    return $"Please input the keys that you want to be pressed. You can enter them simply as 'asdf' or '1234' for a string of keys.{Environment.NewLine}{Environment.NewLine}For special keys, use:{Environment.NewLine}<UP>, <DOWN>, <LEFT>, <RIGHT>, <ENTER>, <ESC> <F5>, or <SPACE>.";
                case "LO_BREAK":
                    return (string)null;
                case "LO_ELSE":
                    return (string)null;
                case "LO_ENDIF":
                    return (string)null;
                case "LO_ENDWHILE":
                    return (string)null;
                case "LO_IFHPL":
                    return "Please input the value for X that you wish to check if HP is less than.";
                case "LO_IFHPE":
                    return "Please input the value for X that you wish to check if HP is equal to.";
                case "LO_IFHPG":
                    return "Please input the value for X that you wish to check if HP is greater than.";
                case "LO_IFHPN":
                    return "Please input the value for X that you wish to check if HP is NOT equal to.";
                case "LO_IFMAPL":
                    return "Please input the value for X that you wish to check if MAP is less than.";
                case "LO_IFMAPE":
                    return "Please input the value for X that you wish to check if MAP is equal to.";
                case "LO_IFMAPG":
                    return "Please input the value for X that you wish to check if MAP is greater than.";
                case "LO_IFMAPN":
                    return "Please input the value for X that you wish to check if MAP is NOT equal to.";
                case "LO_IFMPL":
                    return "Please input the value for X that you wish to check if MP is less than.";
                case "LO_IFMPE":
                    return "Please input the value for X that you wish to check if MP is equal to.";
                case "LO_IFMPG":
                    return "Please input the value for X that you wish to check if MP is greater than.";
                case "LO_IFMPN":
                    return "Please input the value for X that you wish to check if MP is NOT equal to.";
                case "LO_IFXL":
                    return "Please input the value for X that you wish to check if X coordinate is less than.";
                case "LO_IFXE":
                    return "Please input the value for X that you wish to check if X coordinate is equal to.";
                case "LO_IFXG":
                    return "Please input the value for X that you wish to check if X coordinate is greater than.";
                case "LO_IFXN":
                    return "Please input the value for X that you wish to check if X coordinate is NOT equal to.";
                case "LO_IFYL":
                    return "Please input the value for X that you wish to check if Y coordinate is less than.";
                case "LO_IFYE":
                    return "Please input the value for X that you wish to check if Y coordinate is equal to.";
                case "LO_IFYG":
                    return "Please input the value for X that you wish to check if Y coordinate is greater than.";
                case "LO_IFYN":
                    return "Please input the value for X that you wish to check if Y coordinate is NOT equal to.";
                case "LO_WHILEHPL":
                    return "Please input the value for X that you wish to check while HP is less than.";
                case "LO_WHILEHPE":
                    return "Please input the value for X that you wish to check while HP is equal to.";
                case "LO_WHILEHPG":
                    return "Please input the value for X that you wish to check while HP is greater than.";
                case "LO_WHILEHPN":
                    return "Please input the value for X that you wish to check while HP is NOT equal to.";
                case "LO_WHILEMAPL":
                    return "Please input the value for X that you wish to check while MAP is less than.";
                case "LO_WHILEMAPE":
                    return "Please input the value for X that you wish to check while MAP is equal to.";
                case "LO_WHILEMAPG":
                    return "Please input the value for X that you wish to check while MAP is greater than.";
                case "LO_WHILEMAPN":
                    return "Please input the value for X that you wish to check while MAP is NOT equal to.";
                case "LO_WHILEMPL":
                    return "Please input the value for X that you wish to check while MP is less than.";
                case "LO_WHILEMPE":
                    return "Please input the value for X that you wish to check while MP is equal to.";
                case "LO_WHILEMPG":
                    return "Please input the value for X that you wish to check while MP is greater than.";
                case "LO_WHILEMPN":
                    return "Please input the value for X that you wish to check while MP is NOT equal to.";
                case "LO_WHILEXL":
                    return "Please input the value for X that you wish to check while X coordinate is less than.";
                case "LO_WHILEXE":
                    return "Please input the value for X that you wish to check while X coordinate is equal to.";
                case "LO_WHILEXG":
                    return "Please input the value for X that you wish to check while X coordinate is greater than.";
                case "LO_WHILEXN":
                    return "Please input the value for X that you wish to check while X coordinate is NOT equal to.";
                case "LO_WHILEYL":
                    return "Please input the value for X that you wish to check while Y coordinate is less than.";
                case "LO_WHILEYE":
                    return "Please input the value for X that you wish to check while Y coordinate is equal to.";
                case "LO_WHILEYG":
                    return "Please input the value for X that you wish to check while Y coordinate is greater than.";
                case "LO_WHILEYN":
                    return "Please input the value for X that you wish to check while Y coordinate is NOT equal to.";
                case "LP_BREAK":
                    return (string)null;
                case "LP_GOTO":
                    return "Please input the line number to go to.";
                case "LP_END":
                    return (string)null;
                case "LP_RESET":
                    return (string)null;
                case "LP_RESTART":
                    return (string)null;
                case "LP_START":
                    return $"Please input the number of times the loop should repeat itself.{Environment.NewLine}If you wish the loop to be infinite, use the value of zero.";
                case "MO_LEFTCLICK":
                    return (string)null;
                case "MO_MOVE":
                    return $"Please input the X and Y coordinates to move the mouse to.{Environment.NewLine}Please use the format below:{Environment.NewLine}{Environment.NewLine}X,Y";
                case "MO_RECALL":
                    return (string)null;
                case "MO_RIGHTCLICK":
                    return (string)null;
                case "MO_SAVE":
                    return (string)null;
                case "TI_WAIT":
                    return $"Please input the number of milliseconds to wait.{Environment.NewLine}NOTE: 1 second = 1000 milliseconds.";
                default:
                    return "UNKNOWN COMMAND REFERENCE: " + ArgCode;
            }
        }

        public string GetCommandName(string ArgCode)
        {
            switch (ArgCode.ToUpper())
            {
                case "GS_STATUS":
                    return (string)null;
                case "GS_CHAT":
                    return (string)null;
                case "GS_INVENTORY":
                    return (string)null;
                case "GS_MEDSKILL":
                    return (string)null;
                case "GS_MEDSPELL":
                    return (string)null;
                case "GS_TEMSKILL":
                    return (string)null;
                case "GS_TEMSPELL":
                    return (string)null;
                case "KB_SENDKEYS":
                    return "Send Keystrokes";
                case "LO_BREAK":
                    return (string)null;
                case "LO_ELSE":
                    return (string)null;
                case "LO_ENDIF":
                    return (string)null;
                case "LO_ENDWHILE":
                    return (string)null;
                case "LO_IFHPL":
                    return "If HP < X";
                case "LO_IFHPE":
                    return "If HP = X";
                case "LO_IFHPG":
                    return "If HP > X";
                case "LO_IFHPN":
                    return "If HP ≠ X";
                case "LO_IFMAPL":
                    return "If MAP < X";
                case "LO_IFMAPE":
                    return "If MAP = X";
                case "LO_IFMAPG":
                    return "If MAP > X";
                case "LO_IFMAPN":
                    return "If MAP ≠ X";
                case "LO_IFMPL":
                    return "If MP < X";
                case "LO_IFMPE":
                    return "If MP = X";
                case "LO_IFMPG":
                    return "If MP > X";
                case "LO_IFMPN":
                    return "If MP ≠ X";
                case "LO_IFXL":
                    return "If X Coord < X";
                case "LO_IFXE":
                    return "If X Coord = X";
                case "LO_IFXG":
                    return "If X Coord > X";
                case "LO_IFXN":
                    return "If X Coord ≠ X";
                case "LO_IFYL":
                    return "If Y Coord < X";
                case "LO_IFYE":
                    return "If Y Coord = X";
                case "LO_IFYG":
                    return "If Y Coord > X";
                case "LO_IFYN":
                    return "If Y Coord ≠ X";
                case "LO_WHILEHPL":
                    return "While HP < X";
                case "LO_WHILEHPE":
                    return "While HP = X";
                case "LO_WHILEHPG":
                    return "While HP > X";
                case "LO_WHILEHPN":
                    return "While HP ≠ X";
                case "LO_WHILEMAPL":
                    return "While MAP < X";
                case "LO_WHILEMAPE":
                    return "While MAP = X";
                case "LO_WHILEMAPG":
                    return "While MAP > X";
                case "LO_WHILEMAPN":
                    return "While MAP ≠ X";
                case "LO_WHILEMPL":
                    return "While MP < X";
                case "LO_WHILEMPE":
                    return "While MP = X";
                case "LO_WHILEMPG":
                    return "While MP > X";
                case "LO_WHILEMPN":
                    return "While MP ≠ X";
                case "LO_WHILEXL":
                    return "While X Coord < X";
                case "LO_WHILEXE":
                    return "While X Coord = X";
                case "LO_WHILEXG":
                    return "While X Coord > X";
                case "LO_WHILEXN":
                    return "While X Coord ≠ X";
                case "LO_WHILEYL":
                    return "While Y Coord < X";
                case "LO_WHILEYE":
                    return "While Y Coord = X";
                case "LO_WHILEYG":
                    return "While Y Coord > X";
                case "LO_WHILEYN":
                    return "While Y Coord ≠ X";
                case "LP_BREAK":
                    return (string)null;
                case "LP_GOTO":
                    return "Goto Line";
                case "LP_END":
                    return (string)null;
                case "LP_RESET":
                    return (string)null;
                case "LP_RESTART":
                    return (string)null;
                case "LP_START":
                    return "Loop Start";
                case "MO_LEFTCLICK":
                    return (string)null;
                case "MO_MOVE":
                    return "Move Cursor";
                case "MO_RECALL":
                    return (string)null;
                case "MO_RIGHTCLICK":
                    return (string)null;
                case "MO_SAVE":
                    return (string)null;
                case "TI_WAIT":
                    return "Wait X Milliseconds";
                default:
                    return "UNKNOWN COMMAND REFERENCE: " + ArgCode;
            }
        }
    }
}