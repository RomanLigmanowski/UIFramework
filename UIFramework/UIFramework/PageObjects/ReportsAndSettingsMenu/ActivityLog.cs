using OpenQA.Selenium;

namespace UIFramework.PageObjects.ReportsAndSettingsMenu
{
    public class ActivityLog
    {
        private IWebDriver _driver;

        public ActivityLog(IWebDriver driver) => _driver = driver;
    }
}
