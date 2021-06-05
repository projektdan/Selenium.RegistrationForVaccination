using Microsoft.Extensions.DependencyInjection;
using Selenium.RegistrationForVaccination.Infrastructure.Repositories;

namespace Selenium.RegistrationForVaccination.Infrastructure.IoC.Modules
{
    public class RepositoriesModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<IBookingDatesRepository, InMemoryBookingDatesRepository>();
            services.AddTransient<IBookingLocationsRepository, InMemoryBookingLocationsRepository>();
        }
    }
}
