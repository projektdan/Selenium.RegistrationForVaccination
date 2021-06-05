using OpenQA.Selenium;
using Selenium.RegistrationForVaccination.Infrastructure.Selenium.Browsers;
using System;

namespace Selenium.RegistrationForVaccination.Infrastructure.Selenium.Drivers
{
    public class BrowserDriver : IBrowserDriver
    {
        private readonly IBrowser browser;

        public BrowserDriver(IBrowser browser)
        {
            this.browser = browser;
        }
        public IWebDriver Load()
        {
            var driver = browser.Load();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;

        }
    }
}
