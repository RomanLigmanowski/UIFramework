using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UIFramework.PageObjects.SalesAndMarketingMenu.Contacts;

namespace UIFramework.PageObjects.SalesAndMarketingMenu
{
    public class SalesAndMarketing : BasePageObject
    {
        private IWebDriver _driver;

        private IWebElement salesAndMarketingMenu => _driver.FindElementWithWait(By.XPath("//div[contains(text(),'Sales')]/parent::a"));
        private IWebElement contacts => _driver.FindElementWithWait(By.XPath("//a[contains(text(),'Contacts')]"));

        public SalesAndMarketing(IWebDriver driver) : base(driver) => _driver = driver;

        public ContactsMainPage OpenContacts()
        {
            ShowMenu();
            contacts.Click();

            return new ContactsMainPage(_driver);
        }

        private void ShowMenu()
        {
            new Actions(_driver)
                .MoveToElement(salesAndMarketingMenu)
                .Perform();
        }
    }
}
