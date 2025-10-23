using System.Collections.Generic;
using SleepHunter.Macro.Conditions;
using SleepHunter.Macro.Keyboard;

namespace SleepHunter.Macro.Commands
{
    public static class MacroParameterParser
    {
        public static bool TryParse(string input, MacroParameterType type, out MacroParameterValue parsed)
        {
            parsed = new MacroParameterValue { Type = type };

            if (type == MacroParameterType.Boolean)
            {
                if (bool.TryParse(input, out var boolValue))
                {
                    return false;
                }

                parsed.Value = boolValue;
                return true;
            }

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

            if (type == MacroParameterType.CompareOperator)
            {
                if (!TryParseCompareOperator(input, out var op))
                {
                    return false;
                }

                parsed.Value = op;
                return true;
            }

            if (type == MacroParameterType.LogicalOperator)
            {
                if (!TryParseLogicalOperator(input, out var op))
                {
                    return false;
                }

                parsed.Value = op;
                return true;
            }

            return false;
        }

        private static bool TryParseInteger(string input, out long value)
            => long.TryParse(input, out value);


        private static bool TryParseFloat(string input, out double value)
            => double.TryParse(input, out value);

        private static bool TryParseKeystrokes(string input, out IReadOnlyList<Keystroke> keystrokes)
            => KeystrokeParser.TryParseLine(input, out keystrokes);

        public static bool TryParseCompareOperator(string input, out CompareOperator op)
        {
            op = CompareOperator.Equal;

            if (string.Equals(input, "==", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "is", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.Equal;
                return true;
            }
            if (string.Equals(input, "!=", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "is not", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.NotEqual;
                return true;
            }
            if (string.Equals(input, ">=", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.GreaterThanOrEqual;
                return true;
            }
            if (string.Equals(input, ">", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.GreaterThan;
                return true;
            }
            if (string.Equals(input, "<=", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.LessThanOrEqual;
                return true;
            }
            if (string.Equals(input, "<", System.StringComparison.OrdinalIgnoreCase))
            {
                op = CompareOperator.LessThan;
                return true;
            }

            return false;
        }

        public static bool TryParseLogicalOperator(string input, out LogicalOperator op)
        {
            op = LogicalOperator.And;

            if (string.Equals(input, "and", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "&", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "&&", System.StringComparison.OrdinalIgnoreCase))
            {
                op = LogicalOperator.And;
                return true;
            }
            if (string.Equals(input, "or", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "|", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "||", System.StringComparison.OrdinalIgnoreCase))
            {
                op = LogicalOperator.Or;
                return true;
            }
            if (string.Equals(input, "not", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "!", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "~", System.StringComparison.OrdinalIgnoreCase))
            {
                op = LogicalOperator.Not;
                return true;
            }


            return false;
        }

        public static bool TryParseStringCompareOperator(string input, out StringCompareOperator op)
        {
            op = StringCompareOperator.Equal;

            if (string.Equals(input, "==", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "is", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.Equal;
                return true;
            }
            if (string.Equals(input, "!=", System.StringComparison.OrdinalIgnoreCase) ||
               string.Equals(input, "is not", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.NotEqual;
                return true;
            }
            if (string.Equals(input, "<", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "is before", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.LessThan;
                return true;
            }
            if (string.Equals(input, ">", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "is after", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.GreaterThan;
                return true;
            }
            if (string.Equals(input, "%", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "contains", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.Contains;
                return true;
            }
            if (string.Equals(input, "!%", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "does not contain", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.NotContains;
                return true;
            }
            if (string.Equals(input, "^", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "starts with", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.StartsWith;
                return true;
            }
            if (string.Equals(input, "!^", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "does not start with", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.NotStartsWith;
                return true;
            }
            if (string.Equals(input, "$", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "ends with", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.EndsWith;
                return true;
            }
            if (string.Equals(input, "!$", System.StringComparison.OrdinalIgnoreCase) ||
              string.Equals(input, "does not end with", System.StringComparison.OrdinalIgnoreCase))
            {
                op = StringCompareOperator.NotEndsWith;
                return true;
            }

            return false;
        }
    }
}