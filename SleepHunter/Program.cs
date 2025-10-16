using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SleepHunter.Forms;
using SleepHunter.Interop.Windows;

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
            services.AddSingleton<IWindowEnumerator, WindowEnumerator>();

            // Forms
            services.AddSingleton<MainForm>();
        }
    }
}
