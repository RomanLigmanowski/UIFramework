using OpenQA.Selenium;

namespace UIFramework.PageObjects.SalesAndMarketingMenu.Contacts
{
    public class ContactsList : BasePageObject
    {
        private IWebDriver _driver;

        private IEnumerable<IWebElement> contactsList => _driver.FindElements(By.CssSelector("table.listView tbody tr"));
        private IWebElement contactsListSaveButton => _driver.FindElementWithWait(By.Name("SubPanel_save2"));

        public ContactsList(IWebDriver driver) : base(driver) => _driver = driver;

        public void ConfirmSave()
        {
            if (contactsList.Count() > 0)
            {
                contactsListSaveButton.Click();
            }
        }
    }
}
