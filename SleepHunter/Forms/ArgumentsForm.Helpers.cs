using System;
using System.Linq;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Conditions;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm
    {
        private CompareOperator GetSelectedCompareOperator()
        {
            switch (numericOperatorComboBox.SelectedItem.ToString().ToLowerInvariant())
            {
                case "==": return CompareOperator.Equal;
                case "!=": return CompareOperator.NotEqual;
                case ">": return CompareOperator.GreaterThan;
                case ">=": return CompareOperator.GreaterThanOrEqual;
                case "<": return CompareOperator.LessThan;
                case "<=": return CompareOperator.LessThanOrEqual;
                default:
                    throw new InvalidOperationException("Invalid numeric comparison operator");
            }
        }

        private StringCompareOperator GetSelectedStringCompareOperator()
        {
            switch (stringCompareOperatorComboBox.SelectedItem.ToString().ToLowerInvariant())
            {
                case "equals": return StringCompareOperator.Equal;
                case "does not equal": return StringCompareOperator.NotEqual;
                case "contains": return StringCompareOperator.Contains;
                case "does not contain": return StringCompareOperator.NotContains;
                case "starts with": return StringCompareOperator.StartsWith;
                case "does not start with": return StringCompareOperator.NotStartsWith;
                case "ends with": return StringCompareOperator.EndsWith;
                case "does not end with": return StringCompareOperator.NotEndsWith;
                case "is before": return StringCompareOperator.LessThan;
                case "is after": return StringCompareOperator.GreaterThan;
                default:
                    throw new InvalidOperationException("Invalid string comparison operator");
            }
        }

        private bool IsNumericInput() => command.Parameters.Count == 1 &&
                                        (command.Parameters[0] == MacroParameterType.Integer ||
                                         command.Parameters[0] == MacroParameterType.Float);

        private bool IsStringInput() =>
            command.Parameters.Count == 1 && command.Parameters[0] == MacroParameterType.String;

        private bool IsWaitDelay() => command.Key.StartsWith("WAIT_") &&
                                     command.Parameters.Any(p => p == MacroParameterType.Integer);

        private bool IsPercentValue() => command.Key.Contains("PERCENT") &&
                                         command.Parameters.Any(p => p == MacroParameterType.Float);

        private bool IsNumericComparison() => command.Parameters.Count == 2 &&
                                              command.Parameters[0] == MacroParameterType.CompareOperator &&
                                              (command.Parameters[1] == MacroParameterType.Integer ||
                                               command.Parameters[1] == MacroParameterType.Float);

        private bool IsStringComparison() => command.Parameters.Count == 2 &&
                                             command.Parameters[0] == MacroParameterType.StringCompareOperator &&
                                             command.Parameters[1] == MacroParameterType.String;

        private bool IsCoordinatePoint() => command.Parameters.Count == 2 &&
                                            command.Parameters.All(p => p == MacroParameterType.Integer);

        private bool IsKeystrokes() =>
            command.Parameters.Count == 1 && command.Parameters[0] == MacroParameterType.Keystrokes;
    }
}