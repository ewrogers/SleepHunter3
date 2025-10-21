using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Macro.Commands
{
    public static class MacroParameterParser
    {
        public static bool TryParse(string input, MacroParameterType type, out MacroParameterValue parsed)
        {
            parsed = new MacroParameterValue { Type = type };

            if (type == MacroParameterType.Integer)
            {
                if (!TryParseInteger(input, out var longValue))
                {
                    return false;
                }

                parsed.Value = longValue;
                return true;
            }

            if (type == MacroParameterType.Float)
            {
                if (!TryParseFloat(input, out var doubleValue))
                {
                    return false;
                }

                parsed.Value = doubleValue;
                return true;
            }

            if (type == MacroParameterType.String)
            {
                parsed.Value = input ?? string.Empty;
                return true;
            }

            if (type == MacroParameterType.Keystrokes)
            {
                if (!TryParseKeystrokes(input, out var keystrokes))
                {
                    return false;
                }

                parsed.Value = keystrokes;
                return true;
            }

            if (type == MacroParameterType.Point)
            {
                if (!TryParsePoint(input, out var point))
                {
                    return false;
                }

                parsed.Value = point;
                return true;
            }

            return false;
        }

        private static bool TryParseInteger(string input, out long value)
        {
            value = 0;
            return long.TryParse(input, out value);
        }
        
        private static bool TryParseFloat(string input, out double value)
        {
            value = 0;
            return double.TryParse(input, out value);
        }

        private static bool TryParseKeystrokes(string input, out Keys[] keystrokes)
        {
            keystrokes = null;
            
            // TODO: implement this
            
            return false;
        }

        private static bool TryParsePoint(string input, out Point point)
        {
            point = new Point();

            var components = input.Split(',');
            if (components.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(components[0], out var x) || !int.TryParse(components[1], out var y))
            {
                return false;
            }

            point = new Point(x, y);
            return true;
        }
    }
}