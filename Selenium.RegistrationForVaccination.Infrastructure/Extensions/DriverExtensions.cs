using OpenQA.Selenium;

namespace Selenium.RegistrationForVaccination.Infrastructure.Extensions
{
    public static class DriverExtensions
    {
        public static void FindElementByXPathTextAndClick(this IWebDriver driver, string textToFind)
            => driver.FindElement(By.XPath($"//*[text()='{textToFind}']/..")).Click();
        
        public static void FindElementByXPathTextAndSendKeys(this IWebDriver driver, string textToFind, string keysToSend)
            => driver.FindElement(By.XPath($"//*[contains(text(), '{textToFind}')]")).SendKeys(keysToSend);

        public static void FindElementByXPathContainsTextAndClick(this IWebDriver driver, string textToFind)
            => driver.FindElement(By.XPath($"//*[contains(text(), '{textToFind}')]")).Click();

        public static void FindElementByIdAndSendKeys(this IWebDriver driver, string textToFind, string keysToSend)
            => driver.FindElement(By.Id(textToFind)).SendKeys(keysToSend);

        public static void FindElementByIdAndClick(this IWebDriver driver, string textToFind)
            => driver.FindElement(By.Id(textToFind)).Click();
    }
}
