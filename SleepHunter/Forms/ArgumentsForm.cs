using SleepHunter.Macro.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SleepHunter.Macro.Keyboard;

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

            numericOperatorComboBox.SelectedIndex = 3;  // >=
            stringCompareOperatorComboBox.SelectedIndex = 0; // equals

            UpdateCommandUI();
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

                if (IsKeystrokes())
                {
                    var text = keystrokesTextbox.Text.Trim();
                    if (text.Contains("\n") || text.Contains("\r") || text.Contains("\t"))
                    {
                        keystrokesTextbox.Focus();
                        validationError = "Input string cannot contain newlines or tab characters!";
                        return;
                    }

                    if (!KeystrokeParser.TryParseLine(text, out _))
                    {
                        keystrokesTextbox.Focus();
                        validationError = "One or more invalid keystrokes were found!";
                        return;
                    }
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
                var keys = KeystrokeParser.ParseLine(keystrokesTextbox.Text.Trim());
                yield return MacroParameterValue.Keys(new List<Keystroke>());
            }
            else if (IsWaitDelay())
            {
                yield return MacroParameterValue.Long((long)waitNumeric.Value);
            }
        }

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