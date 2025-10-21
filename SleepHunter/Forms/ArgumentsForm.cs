using SleepHunter.Macro.Commands;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class ArgumentsForm : Form
    {
        private readonly Size initialSize;
        private MacroCommandDefinition commandDefinition;
        private string validationError;
        
        public bool DialogResult { get; private set; }

        public MacroCommandDefinition Command
        {
            get => commandDefinition;
            set
            {
                commandDefinition = value;
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

            if (commandDefinition == null)
            {
                return;
            }

            commandNameLabel.Text = commandDefinition.DisplayName;
            if (!string.IsNullOrWhiteSpace(commandDefinition.HelpText))
            {
                helpTextLabel.Text = $"{commandDefinition.Description}{Environment.NewLine}{Environment.NewLine}{commandDefinition.HelpText}";
            }
            else
            {
                helpTextLabel.Text = commandDefinition.Description;
            }
        }

        private void UpdateCommandLayout()
        {
            if (commandDefinition == null)
            {
                return;
            }

            var parameters = commandDefinition.Parameters;
            var isNumericComparison = parameters.Count == 2 &&
                parameters[0] == MacroParameterType.CompareOperator &&
                (parameters[1] == MacroParameterType.Integer || parameters[1] == MacroParameterType.Float);

            var isStringComparison = parameters.Count == 2 &&
                parameters[0] == MacroParameterType.StringCompareOperator &&
                parameters[1] == MacroParameterType.String;

            var isPoint = parameters.Count == 1 && parameters[0] == MacroParameterType.Point;
            var isKeystrokes = parameters.Count == 1 && parameters[0] == MacroParameterType.Keystrokes;

            if (isNumericComparison)
            {
                var isPercent = commandDefinition.Key.Contains("PERCENT");
                numericComparisonGroupBox.Text = isPercent ? "Percent Comparison" : "Value Comparison";

                valueNumericBox.DecimalPlaces = isNumericComparison && parameters[1] == MacroParameterType.Float ? 2 : 0;
                valueNumericBox.Maximum = isPercent ? 100 : uint.MaxValue;

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

            numericComparisonGroupBox.Visible = isNumericComparison;
            stringComparisonGroupBox.Visible = isStringComparison;
            pointGroupBox.Visible = isPoint;
            keystrokesGroupBox.Visible = isKeystrokes;
        }

        private void SetValidationError(string message)
        {
            validationLabel.Text = message;
            validationLabel.Visible = !string.IsNullOrWhiteSpace(validationError);

            addButton.Enabled = string.IsNullOrWhiteSpace(validationError);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(validationError))
            {
                return;
            }

            DialogResult = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}