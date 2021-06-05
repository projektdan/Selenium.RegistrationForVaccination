using OpenQA.Selenium;
using Selenium.RegistrationForVaccination.Infrastructure.Constants;
using Selenium.RegistrationForVaccination.Infrastructure.Extensions;
using Selenium.RegistrationForVaccination.Infrastructure.Options;
using Selenium.RegistrationForVaccination.Infrastructure.Repositories;
using Selenium.RegistrationForVaccination.Infrastructure.Selenium.Drivers;
using System.Threading;

namespace Selenium.RegistrationForVaccination.Infrastructure.Selenium.BrowserFlows
{
    public class RegistrationForVisitFlow : IBrowserFlow
    {
        private readonly IBookingLocationsRepository locationsRepository;
        private readonly IBookingDatesRepository datesRepository;
        private readonly CredentialsOptions credentials;
        private readonly RegistrationOptions registration;
        private IWebDriver driver = null;

        public RegistrationForVisitFlow(IBrowserDriver browser, IBookingLocationsRepository locationsRepository, IBookingDatesRepository datesRepository,
                                        CredentialsOptions credentials, RegistrationOptions registration)
        {
            this.locationsRepository = locationsRepository;
            this.datesRepository = datesRepository;
            this.credentials = credentials;
            this.registration = registration;
            driver = browser.Load();
        }
        public void FollowTheSteps()
        {
            var username = credentials.Username;
            var password = credentials.Password;
            var url = PageConstants.registrationUrl;

            driver.Navigate().GoToUrl(url);

            driver.FindElementByXPathTextAndClick("Zaloguj się przez login.gov.pl");
            driver.FindElementByXPathTextAndClick("Profil Zaufany");

            driver.FindElementByIdAndSendKeys("loginForm:login", username);
            driver.FindElementByIdAndSendKeys("loginForm:hasło", password);
            driver.FindElementByIdAndClick("loginForm:loginButton");

            //Next button
            driver.FindElementByXPathContainsTextAndClick("Dalej");

            if (!IsElementExistsOnPage(By.Id("city")))
            {
                //Other vaccine location button
                driver.FindElementByXPathContainsTextAndClick("Znajdź inny Punkt Szczepień lub termin");
            }
            
            var cityTextBox = driver.FindElement(By.Id("city"));

            cityTextBox.SendKeys(registration.Location);
            //TODO : Check if value is paste
            Thread.Sleep(500);
            cityTextBox.SendKeys(Keys.Enter);

            var vaccineType = driver.FindElement(By.Id("vaccineType"));

            foreach (var vaccine in registration.Vaccines)
            {
                vaccineType.SendKeys(vaccine.Name);
                vaccineType.SendKeys(Keys.Enter);
            }

            while (true)
            {
                var searchButton = driver.FindElement(By.XPath($"//*[contains(text(), 'Szukaj')]"));
                searchButton.SendKeys(Keys.Enter);

                var listOfAvaliableAppointments = driver.FindElements(By.CssSelector(".sc-dkAroR.gVwIOj"));
                int numberOfRowOfAvaliableAppointment = 1;
                
                foreach (var avaliableAppointment in listOfAvaliableAppointments)
                {
                    var dateMatching = avaliableAppointment.Text
                                        .IsDateInRangeOf(datesRepository.Get());
                    var locationMatching = avaliableAppointment.Text
                                        .IsLocationInRangeOf(locationsRepository.Get());

                    if (dateMatching && locationMatching)
                    {
                        var matchResult = driver.FindElement(By.CssSelector($".sc-dkAroR.gVwIOj:nth-of-type({numberOfRowOfAvaliableAppointment})"));
                        var chooseButton = matchResult.FindElement(By.CssSelector($"button.sc-kstrdz.doevxB.sc-gHftXq.kCGTjS"));
                        chooseButton.Click();

                        if (IsElementExistsOnPage(By.XPath("//*[contains(text(), 'Tak')]")))
                        {
                            var yesButton = driver.FindElement(By.XPath("//*[contains(text(), 'Tak')]"));
                            yesButton.Click();
                        }
                    }

                    numberOfRowOfAvaliableAppointment++;
                }

                Thread.Sleep(PageConstants.pageRefreshInterval);
            }
        }

        private bool IsElementExistsOnPage(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
