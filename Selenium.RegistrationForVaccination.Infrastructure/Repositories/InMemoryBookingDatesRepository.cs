using System;

namespace Selenium.RegistrationForVaccination.Infrastructure.Repositories
{
    public class InMemoryBookingDatesRepository : IBookingDatesRepository
    {
        public DateTime[] Get()
        {
            var dates = new DateTime[]
            {
                new DateTime(2021, 5, 19),
                new DateTime(2021, 5, 20),
                new DateTime(2021, 5, 21),
                new DateTime(2021, 5, 22),
                new DateTime(2021, 5, 23),
                new DateTime(2021, 5, 24),
                new DateTime(2021, 5, 25),
                new DateTime(2021, 5, 26)
            };

            return dates;
        }
    }
}

