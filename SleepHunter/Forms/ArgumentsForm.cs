using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Conditions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm : Form
    {
        private readonly Size initialSize;

        private MacroCommandDefinition command;
        private string validationError;

        public IReadOnlyList<MacroParameterValue> Parameters { get; private set; }

        public MacroCommandDefinition Command
        {
            get => command;
            set
            {
                command = value;
                UpdateCommandUI();
                UpdateCommandLayout();
            }
        }

        public ArgumentsForm()
        {
            InitializeComponent();
            initialSize = Size;

            numericOperatorComboBox.SelectedIndex = 0;
            stringCompareOperatorComboBox.SelectedIndex = 0;

            UpdateCommandUI();
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
                helpTextLabel.Text = $"{command.Description}{Environment.NewLine}{Environment.NewLine}{command.HelpText}";
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
                numericInputNumeric.Focus();
                numericInputNumeric.Select(0, 100);

                numericInputGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isStringInput)
            {
                stringInputTextBox.Focus();
                stringInputTextBox.SelectAll();

                stringInputGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isWaitDelay)
            {
                waitNumeric.Maximum = uint.MaxValue;
                waitNumeric.Focus();
                waitNumeric.Select(0, 100);

                waitGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isNumericComparison)
            {
                var isPercent = IsPercentValue();
                numericComparisonGroupBox.Text = isPercent ? "Percent Comparison" : "Value Comparison";
                percentLabel.Visible = isPercent;

                numericValueNumeric.DecimalPlaces = isNumericComparison && command.Parameters[1] == MacroParameterType.Float ? 2 : 0;
                numericValueNumeric.Maximum = isPercent ? 100 : uint.MaxValue;
                numericValueNumeric.Focus();
                numericValueNumeric.Select(0, 100);

                numericComparisonGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isStringComparison)
            {
                stringValueTextBox.Focus();
                stringValueTextBox.SelectAll();

                stringComparisonGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 410);
            }
            else if (isPoint)
            {
                xValueNumeric.Focus();
                xValueNumeric.Select(0, 100);

                pointGroupBox.Location = argsAnchorPanel.Location;
                Size = new Size(initialSize.Width, 380);
            }
            else if (isKeystrokes)
            {
                keystrokesTextbox.Focus();
                keystrokesTextbox.SelectAll();

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

        private void ValidateParameters()
        {
            try
            {
                if (IsStringInput() && string.IsNullOrWhiteSpace(stringInputTextBox.Text))
                {
                    stringInputTextBox.Focus();
                    validationError = "Input string cannot be empty!";
                    return;
                }
                if (IsStringComparison() && string.IsNullOrWhiteSpace(stringValueTextBox.Text))
                {
                    stringValueTextBox.Focus();
                    validationError = "Input string cannot be empty!";
                    return;
                }
                validationError = string.Empty;
            }
            finally
            {
                var hasError = !string.IsNullOrWhiteSpace(validationError);
                validationLabel.Text = validationError;
                validationLabel.Visible = hasError;
                addButton.Enabled = !hasError;
            }
        }

        private IEnumerable<MacroParameterValue> EmitParameters()
        {
            if (IsNumericInput())
            {
                yield return command.Parameters[0] == MacroParameterType.Float
                    ? MacroParameterValue.Double((double)numericInputNumeric.Value)
                    : MacroParameterValue.Long((long)numericInputNumeric.Value);
            }
            else if (IsStringInput())
            {
                yield return MacroParameterValue.String(stringInputTextBox.Text);
            }
            else if (IsNumericComparison())
            {
                yield return MacroParameterValue.CompareOperator(GetSelectedCompareOperator());
                yield return command.Parameters[1] == MacroParameterType.Float
                    ? MacroParameterValue.Double((double)numericValueNumeric.Value)
                    : MacroParameterValue.Long((long)numericValueNumeric.Value);
            }
            else if (IsStringComparison())
            {
                yield return MacroParameterValue.StringCompareOperator(GetSelectedStringCompareOperator());
                yield return MacroParameterValue.String(stringValueTextBox.Text);
            }
            else if (IsCoordinatePoint())
            {
                yield return MacroParameterValue.Long((long)xValueNumeric.Value);
                yield return MacroParameterValue.Long((long)yValueNumeric.Value);
            }
            else if (IsKeystrokes())
            {
                yield return MacroParameterValue.Keys(new List<Keys>());
            }
            else if (IsWaitDelay())
            {
                yield return MacroParameterValue.Long((long)waitNumeric.Value);
            }
        }

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

        public bool IsNumericInput() => command.Parameters.Count == 1 &&
                (command.Parameters[0] == MacroParameterType.Integer || command.Parameters[0] == MacroParameterType.Float);

        public bool IsStringInput() => command.Parameters.Count == 1 && command.Parameters[0] == MacroParameterType.String;

        public bool IsWaitDelay() => command.Key.StartsWith("WAIT_") && command.Parameters.Any(p => p == MacroParameterType.Integer);

        private bool IsPercentValue() => command.Key.Contains("PERCENT") && command.Parameters.Any(p => p == MacroParameterType.Float);

        private bool IsNumericComparison() => command.Parameters.Count == 2 &&
                command.Parameters[0] == MacroParameterType.CompareOperator &&
                (command.Parameters[1] == MacroParameterType.Integer || command.Parameters[1] == MacroParameterType.Float);

        private bool IsStringComparison() => command.Parameters.Count == 2 &&
                command.Parameters[0] == MacroParameterType.StringCompareOperator &&
                command.Parameters[1] == MacroParameterType.String;

        private bool IsCoordinatePoint() => command.Parameters.Count == 2 && command.Parameters.All(p => p == MacroParameterType.Integer);
        private bool IsKeystrokes() => command.Parameters.Count == 1 && command.Parameters[0] == MacroParameterType.Keystrokes;

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValidateParameters();
        }

        private void addButton_Click(object sender, EventArgs e) => OnAccept();

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
              
        private void OnAccept()
        {
            ValidateParameters();
            if (!string.IsNullOrWhiteSpace(validationError))
            {
                return;
            }

            Parameters = EmitParameters().ToList();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}