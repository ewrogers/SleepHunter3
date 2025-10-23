using System;
using System.Collections.Generic;
using System.Text;

namespace SleepHunter.Interop.Keyboard
{
    public static class KeystrokeParser
    {
        public static IReadOnlyList<Keystroke> ParseLine(string line)
        {
            return !TryParseLine(line, out var keys) ? throw new FormatException("Invalid keystroke format") : keys;
        }

        public static bool TryParseLine(string line, out IReadOnlyList<Keystroke> keys)
        {
            keys = null;

            var parsedKeys = new List<Keystroke>();
            var buffer = new StringBuilder();
            var isInBrackets = false;

            foreach (var c in line)
            {
                switch (c)
                {
                    case '<' when !isInBrackets:
                        isInBrackets = true;
                        buffer.Clear();
                        continue;
                    case '>' when isInBrackets:
                    {
                        isInBrackets = false;
                        if (!Keystroke.TryParse(buffer.ToString(), out var key))
                            return false;

                        parsedKeys.Add(key);
                        continue;
                    }
                }

                if (isInBrackets)
                {
                    buffer.Append(c);
                    continue;
                }

                if (!Keystroke.TryParse(c.ToString(), out var singleKey))
                    return false;

                parsedKeys.Add(singleKey);
            }

            if (isInBrackets)
                return false;

            keys = parsedKeys;
            return true;
        }
    }
}