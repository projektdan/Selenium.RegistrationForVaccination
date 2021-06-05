using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.RegistrationForVaccination.Infrastructure.Extensions;
using Selenium.RegistrationForVaccination.Infrastructure.Repositories;

namespace Selenium.RegistrationForVaccination.Infrastructure.Tests.Extensions
{
    [TestClass]
    public class FlowsExtensionsTests
    {
        [TestMethod]
        public void IsDateInRange_OfDateDeclaredArray_ShouldReturnTrue()
        {
            InMemoryBookingDatesRepository datesRepository = new InMemoryBookingDatesRepository();
            var mockDataFromPage = "Termin wizyty 25 maja 2021 10:30";
            var matchingVisitDates = datesRepository.Get();

            Assert.IsTrue(mockDataFromPage.IsDateInRangeOf(matchingVisitDates));
        }

        [TestMethod]
        public void IsLocationInRange_OfLocationDeclaredArray_ShouldReturnTrue()
        {
            InMemoryBookingLocationsRepository locationsRepository = new InMemoryBookingLocationsRepository();
            var mockDataFromPage = "Lokalizacja wizyty: SZPITAL TYMCZASOWY MTP " +
                "w punkcie Heliodora Swiecickiego brama nr 4";
            var matchingVisitLocations = locationsRepository.Get();

            Assert.IsTrue(mockDataFromPage.IsLocationInRangeOf(matchingVisitLocations));
        }
    }
}
