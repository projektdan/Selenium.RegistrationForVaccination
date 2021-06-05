using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.RegistrationForVaccination.Infrastructure.Selenium.Browsers
{
    public class ChromeBrowser : IBrowser
    {
        public IWebDriver Load()
        {
            var DeviceDriver = ChromeDriverService.CreateDefaultService();
            DeviceDriver.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArguments("--disable-infobars", "--disable-popup-blocking");
            
            return new ChromeDriver(DeviceDriver, options);
        }
    }
}
