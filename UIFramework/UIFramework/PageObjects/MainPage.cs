using OpenQA.Selenium;
using UIFramework.PageObjects.ReportsAndSettingsMenu;
using UIFramework.PageObjects.SalesAndMarketingMenu;

namespace UIFramework.PageObjects
{
    public class MainPage
    {
        protected IWebDriver _driver;

        private SalesAndMarketing? salesAndMarketing;
        private ReportsAndSettings? reportsAndSettings;        

        public MainPage(IWebDriver driver) => _driver = driver;

        public SalesAndMarketing SalesAndMarketingMenu() => new SalesAndMarketing(_driver);

        public ReportsAndSettings ReportsAndSettingsMenu() => new ReportsAndSettings(_driver);
    }
}
