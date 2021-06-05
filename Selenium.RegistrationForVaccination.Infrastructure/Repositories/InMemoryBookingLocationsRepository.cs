namespace Selenium.RegistrationForVaccination.Infrastructure.Repositories
{
    public class InMemoryBookingLocationsRepository : IBookingLocationsRepository
    {
        public string[] Get()
        {
            string[] locations = new string[]
            {
                "SZPITAL TYMCZASOWY MTP",
                "Półwiejska 42"
            };

            return locations;
        }
    }
}
