using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Forms;
using SleepHunter.Interop.Windows;
using SleepHunter.Macro.Commands;
using SleepHunter.Macro.Serialization;
using SleepHunter.Services;

namespace SleepHunter
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            try
            {
                var mainForm = provider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
            finally
            {
                provider.Dispose();
            }
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // Application services
            services.AddSingleton<IGameClientService, GameClientService>();
            services.AddSingleton<IMacroCommandFactory, MacroCommandFactory>();
            services.AddSingleton<IMacroCommandRegistry, MacroCommandRegistry>();
            services.AddSingleton<IMacroSerializer, JsonMacroSerializer>();
            services.AddSingleton<IWindowEnumerator, WindowEnumerator>();

            // Forms
            services.AddSingleton<MainForm>();
            services.AddTransient<AboutForm>();
            services.AddTransient<ArgumentsForm>();
            services.AddTransient<MacroForm>();
            services.AddTransient<OptionsForm>();
            services.AddTransient<ProcessesForm>();
            services.AddTransient<StatusForm>();
        }
    }
}
