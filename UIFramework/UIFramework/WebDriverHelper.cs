using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UIFramework
{
    public static class WebDriverHelper
    {
        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int seconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(d => d.FindElement(by).Displayed & d.FindElement(by).Enabled);

            return driver.FindElement(by);
        }

        public static void JavaScriptClick(this IWebElement element, IWebDriver driver)
        {
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickUsingActions(this IWebElement element, IWebDriver driver) 
        {
            new Actions(driver)
                .MoveToElement(element)
                .Click()
                .Perform();
        }
    }
}
