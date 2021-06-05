using Microsoft.Extensions.DependencyInjection;
using Selenium.RegistrationForVaccination.Infrastructure.Selenium.BrowserFlows;
using Selenium.RegistrationForVaccination.Infrastructure.Selenium.Browsers;
using Selenium.RegistrationForVaccination.Infrastructure.Selenium.Drivers;

namespace Selenium.RegistrationForVaccination.Infrastructure.IoC.Modules
{
    public class BrowserModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<IBrowserDriver, BrowserDriver>();
            services.AddTransient<IBrowserFlow, RegistrationForVisitFlow>();
            services.AddTransient<IBrowser, ChromeBrowser>();
        }
    }
}
