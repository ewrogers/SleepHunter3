using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Conditions;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm
    {
        public void SetMaxLength(int maxLength)
        {
            stringInputTextBox.MaxLength = maxLength;
            stringValueTextBox.MaxLength = maxLength;
        }
        
        public void SetPatternConstraint(Regex pattern)
        {
            regexPattern = pattern;
        }
        
        public void SetDefaultParameters(IReadOnlyList<MacroParameterValue> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return;
            }

            if (IsNumericInput() && parameters.Count >= 1)
            {
                numericInputNumeric.Value = parameters[0].AsDecimal();
            }
            else if (IsStringInput() && parameters.Count >= 1)
            {
                stringInputTextBox.Text = parameters[0].AsString();
            }
            else if (IsWaitDelay() && parameters.Count >= 1)
            {
                waitNumeric.Value = parameters[0].AsDecimal();
            }
            else if (IsNumericComparison() && parameters.Count >= 2)
            {
                SelectCompareOperator(parameters[0].AsCompareOperator());
                numericValueNumeric.Value = parameters[1].AsDecimal();
            }
            else if (IsStringComparison() && parameters.Count >= 2)
            {
                SelectStringCompareOperator(parameters[0].AsStringCompareOperator());
                stringValueTextBox.Text = parameters[1].AsString();
            }
            else if (IsCoordinatePoint() && parameters.Count >= 2)
            {
                xValueNumeric.Value = parameters[0].AsLong();
                yValueNumeric.Value = parameters[1].AsLong();
            }
            else if (IsKeystrokes() && parameters.Count >= 1)
            {
                keystrokesTextbox.Text = string.Join("", parameters[0].AsKeystrokes());
            }
        }

        private void UpdateCommandUI()
        {
            validationLabel.Visible = !string.IsNullOrWhiteSpace(validationError);

            if (command == null)
            {
                return;
            }

            commandNameLabel.Text = command.DisplayName;
            if (!string.IsNullOrWhiteSpace(command.HelpText))
            {
                helpTextLabel.Text =
                    $"{command.Description}{Environment.NewLine}{Environment.NewLine}{command.HelpText}";
            }
            else
            {
                helpTextLabel.Text = command.Description;
            }
        }

        private void UpdateCommandLayout()
        {
            if (command == null)
            {
                return;
            }

            var isNumericInput = IsNumericInput();
            var isStringInput = IsStringInput();
            var isWaitDelay = IsWaitDelay();
            var isNumericComparison = IsNumericComparison();
            var isStringComparison = IsStringComparison();
            var isPoint = IsCoordinatePoint();
            var isKeystrokes = IsKeystrokes();

            if (isNumericInput)
            {
                numericInputNumeric.Maximum = uint.MaxValue;

                numericInputGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isStringInput)
            {
                stringInputGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isWaitDelay)
            {
                waitNumeric.Maximum = uint.MaxValue;

                waitGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isNumericComparison)
            {
                var isPercent = IsPercentValue();
                numericComparisonGroupBox.Text = isPercent ? "Percent Comparison" : "Value Comparison";
                percentLabel.Visible = isPercent;

                numericValueNumeric.DecimalPlaces = command.Parameters[1] == MacroParameterType.Float ? 2 : 0;
                numericValueNumeric.Maximum = isPercent ? 100 : uint.MaxValue;

                numericComparisonGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isStringComparison)
            {
                stringComparisonGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 410);
            }
            else if (isPoint)
            {
                pointGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isKeystrokes)
            {
                keystrokesGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 420);
            }
            else
            {
                Size = new Size(initialSize.Width, 300);
            }

            numericInputGroupBox.Visible = isNumericInput;
            stringInputGroupBox.Visible = isStringInput;
            waitGroupBox.Visible = isWaitDelay;
            numericComparisonGroupBox.Visible = isNumericComparison;
            stringComparisonGroupBox.Visible = isStringComparison;
            pointGroupBox.Visible = isPoint;
            keystrokesGroupBox.Visible = isKeystrokes;
        }

        private void SelectCompareOperator(CompareOperator op)
        {
            var index = numericOperatorComboBox.Items.IndexOf(op.ToSymbol());
            numericOperatorComboBox.SelectedIndex = Math.Max(0, index);
        }

        private void SelectStringCompareOperator(StringCompareOperator op)
        {
            var index = -1;
            var words = op.ToWords().ToLowerInvariant();
            
            for (var i = 0; i < stringCompareOperatorComboBox.Items.Count; i++)
            {
                var text = stringCompareOperatorComboBox.Items[i].ToString();
                if (text.ToLowerInvariant().Contains(words))
                {
                    index = i;
                    break;
                }
            }
            
            stringCompareOperatorComboBox.SelectedIndex = Math.Max(0, index);
        }
    }
}