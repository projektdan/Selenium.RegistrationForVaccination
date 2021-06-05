using Microsoft.Extensions.Configuration;

namespace Selenium.RegistrationForVaccination.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configurationOptions, string section)
            where TOptions: new()
        {
            var configuration = new TOptions();
            configurationOptions.Bind(section, configuration);

            return configuration;
        }
    }
}
