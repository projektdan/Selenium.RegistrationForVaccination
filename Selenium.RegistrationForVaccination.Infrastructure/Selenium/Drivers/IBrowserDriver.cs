using OpenQA.Selenium;

namespace Selenium.RegistrationForVaccination.Infrastructure.Selenium.Drivers
{
    public interface IBrowserDriver
    {
        IWebDriver Load();
    }
}