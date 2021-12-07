using Microsoft.Extensions.DependencyInjection;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependecyInjectionWF
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var ServiceProvider = services.BuildServiceProvider())
            {
                var form1 = ServiceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }

        }


        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IUser, User>()
                .AddScoped<Form1>();
        }

    }
}
