using Microsoft.Extensions.DependencyInjection;

namespace Selenium.RegistrationForVaccination.Infrastructure.IoC
{
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
