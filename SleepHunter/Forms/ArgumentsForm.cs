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
                stringInputTextBox.Text = parameters[0].ToString();
            }
            else if (IsWaitDelay() && parameters.Count >= 1)
            {
                waitNumeric.Value = parameters[0].AsDecimal();
            }
            else if (IsNumericComparison() && parameters.Count >= 2)
            {
                numericValueNumeric.Value = parameters[1].AsDecimal();
            }
            else if (IsStringComparison() && parameters.Count >= 2)
            {
                stringValueTextBox.Text = parameters[1].ToString();
            }
            else if (IsCoordinatePoint() && parameters.Count >= 2)
            {
                xValueNumeric.Value = parameters[0].AsLong();
                yValueNumeric.Value = parameters[1].AsLong();
            }
            else if (IsKeystrokes() && parameters.Count >= 1)
            {

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

        private void form_Shown(object sender, EventArgs e)
        {
            if (IsNumericInput())
            {
                numericInputNumeric.Focus();
                numericInputNumeric.Select(0, 100);
            }
            else if (IsStringInput())
            {
                stringInputTextBox.Focus();
                stringInputTextBox.SelectAll();
            }
            else if (IsWaitDelay())
            {
                waitNumeric.Focus();
                waitNumeric.Select(0, 100);
            }
            else if (IsNumericComparison())
            {
                numericValueNumeric.Focus();
                numericValueNumeric.Select(0, 100);
            }
            else if (IsStringComparison())
            {
                stringValueTextBox.Focus();
                stringValueTextBox.SelectAll();
            }
            else if (IsCoordinatePoint())
            {
                xValueNumeric.Focus();
                xValueNumeric.Select(0, 100);
            }
            else if (IsKeystrokes())
            {
                keystrokesTextbox.Focus();
                keystrokesTextbox.SelectAll();
            }
        }

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