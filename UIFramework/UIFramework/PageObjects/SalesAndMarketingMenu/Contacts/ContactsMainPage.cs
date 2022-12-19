using OpenQA.Selenium;
using UIFramework.PageObjects.SalesAndMarketingMenu.Contacts.Contacts;

namespace UIFramework.PageObjects.SalesAndMarketingMenu.Contacts
{
    public class ContactsMainPage : BasePageObject
    {
        private IWebDriver _driver;

        private IWebElement createContact => _driver.FindElementWithWait(By.XPath("//span[text()='Create Contact']/parent::a"));
        private IWebElement pageTitle => _driver.FindElementWithWait(By.Id("main-title-module"));


        public ContactsMainPage(IWebDriver driver) : base(driver) => _driver = driver;

        public CreateContact CreateContact()
        {
            createContact.Click();

            return new CreateContact(_driver);
        }
    }
}
