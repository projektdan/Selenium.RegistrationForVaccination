using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Selenium.RegistrationForVaccination.Infrastructure.IoC;
using Selenium.RegistrationForVaccination.Infrastructure.Options;
using System;
using System.Linq;
using System.Reflection;

namespace Selenium.RegistrationForVaccination.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModules(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var serviceModule = assembly
                .ExportedTypes
                .Where(t => typeof(IModule).IsAssignableFrom(t)
                                                && !t.IsInterface
                                                && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();

            serviceModule.ForEach(module => module.Load(services));
        }

        public static void AddCredentialsOptions(this IServiceCollection services)
        {
            AddOptions<CredentialsOptions>(services, "credentials");
        }

        public static void AddRegistrationOptions(this IServiceCollection services)
        {
            AddOptions<RegistrationOptions>(services, "registration");
        }

        private static void AddOptions<TOptions>(IServiceCollection services, string section)
            where TOptions: class, new()
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var options = configuration.GetOptions<TOptions>(section);

            services.AddSingleton(options);
        }
    }
}
