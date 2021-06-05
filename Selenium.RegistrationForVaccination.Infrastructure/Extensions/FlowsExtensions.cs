using System;

namespace Selenium.RegistrationForVaccination.Infrastructure.Extensions
{
    public static class FlowsExtensions
    {
        public static bool IsDateInRangeOf(this string valueToSearchIn, DateTime[] datesToFind)
        {
            foreach (var date in datesToFind)
            {
                var dateDay = date.ToString("dd MMMM yyyy");
                if (valueToSearchIn.Contains(dateDay))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsLocationInRangeOf(this string valueToSearchIn, string[] locationsToFind)
        {
            foreach (var location in locationsToFind)
            {
                if (valueToSearchIn.Contains(location))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
