using System;

namespace Selenium.RegistrationForVaccination.Infrastructure.Repositories
{
    public interface IBookingDatesRepository
    {
        DateTime[] Get();
    }
}
