
namespace SleepHunter.Macro.Commands
{
    public partial class MacroCommandRegistry
    {
        private void RegisterJumpCommands()
        {
			RegisterCommand(new MacroCommandDefinition
			{
				Category = MacroCommandCategory.Jump,
				Key = MacroCommandKey.DefineLabel,
				DisplayName = "Define Label",
				Description = "Defines a label that can be jumped to later.",
				Parameters = { MacroParameterType.String },
			});

			RegisterCommand(new MacroCommandDefinition
			{
				Category = MacroCommandCategory.Jump,
				Key = MacroCommandKey.GotoLabel,
				DisplayName = "Goto Label",
				Description = "Jumps to a previously defined label in the macro.",
				Parameters = { MacroParameterType.String },
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
