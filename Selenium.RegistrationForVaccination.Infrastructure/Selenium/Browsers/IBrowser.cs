using OpenQA.Selenium;

namespace Selenium.RegistrationForVaccination.Infrastructure.Selenium.Browsers
{
    public interface IBrowser
    {
        IWebDriver Load();
    }
}