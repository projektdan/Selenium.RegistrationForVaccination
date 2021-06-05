using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Selenium.RegistrationForVaccination.Infrastructure.Extensions;
using System.IO;

namespace Selenium.RegistrationForVaccination.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Application>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = LoadConfiguration();

            services.AddSingleton(configuration);
            services.AddSingleton<Application>();
            services.RegisterModules();
            services.AddCredentialsOptions();
            services.AddRegistrationOptions();

            return services;
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
