using Microsoft.Extensions.DependencyInjection;

namespace Selenium.RegistrationForVaccination.Infrastructure.IoC.Modules
{
    public class RegistrationVisitModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<IRegisterForVisit, RegisterForVisit>();
        }
    }
}
