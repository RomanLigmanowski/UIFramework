using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UIFramework.PageObjects.ReportsAndSettingsMenu
{
    public class ReportsAndSettings
    {
        private IWebDriver _driver;

        private IWebElement reportsAndSettingsMenu => _driver.FindElement(By.Id("grouptab-5"));

        public ReportsAndSettings(IWebDriver driver) => _driver = driver;

        public Reports OpenReports()
        {
            ShowMenu();
            _driver.FindElement(By.PartialLinkText("")).Click();

            return new Reports(_driver);
        }

        public ActivityLog OpenActivityLog()
        {
            ShowMenu();
            _driver.FindElement(By.PartialLinkText("")).Click();

            return new ActivityLog(_driver);
        }

        private void ShowMenu()
        {
            new Actions(_driver)
                .MoveToElement(reportsAndSettingsMenu)
                .Perform();
        }
    }
}
