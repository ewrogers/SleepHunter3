
using System.Text.RegularExpressions;

namespace SleepHunter.Macro.Commands
{
	public partial class MacroCommandRegistry
	{
		private static readonly Regex LabelPattern = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$", RegexOptions.Compiled);

		private void RegisterJumpCommands()
		{
			RegisterCommand(new MacroCommandDefinition
			{
				Category = MacroCommandCategory.Jump,
				Key = MacroCommandKey.DefineLabel,
				DisplayName = "Define Label",
				Description = "Defines a label that can be jumped to later.",
				HelpText = "Labels must start with a letter and can only contain letters, numbers, and underscores.",
				Parameters = { MacroParameterType.String },
				Pattern = LabelPattern,
				MaxLength = 50
			});

			RegisterCommand(new MacroCommandDefinition
			{
				Category = MacroCommandCategory.Jump,
				Key = MacroCommandKey.GotoLabel,
				DisplayName = "Goto Label",
				Description = "Jumps to a previously defined label in the macro.",
				HelpText = "Labels must start with a letter and can only contain letters, numbers, and underscores.",
				Parameters = { MacroParameterType.String },
				Pattern = LabelPattern,
				MaxLength = 50
			});

			RegisterCommand(new MacroCommandDefinition
			{
				Category = MacroCommandCategory.Jump,
				Key = MacroCommandKey.GotoLine,
				DisplayName = "Goto Line",
				Description = "Jumps to a specific line in the macro.",
				Parameters = { MacroParameterType.Integer },
			});
		}
	}
}
