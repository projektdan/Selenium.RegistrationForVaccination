using System.Collections.Generic;

namespace Selenium.RegistrationForVaccination.Infrastructure.Options
{
    public class RegistrationOptions
    {
        public string Location { get; set; }
        public IEnumerable<Vaccine> Vaccines { get; set; }
    }

    public class Vaccine
    {
        public string Name { get; set; }
    }
}
