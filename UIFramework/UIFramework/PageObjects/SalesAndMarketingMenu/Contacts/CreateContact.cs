using OpenQA.Selenium;

namespace UIFramework.PageObjects.SalesAndMarketingMenu.Contacts.Contacts
{
    public class CreateContact : BasePageObject
    {
        private IWebDriver _driver;

        private IWebElement firstNameInput => _driver.FindElementWithWait(By.Name("first_name"));
        private IWebElement lastNameInput => _driver.FindElementWithWait(By.Name("last_name"));
        private IWebElement roleDropdown => _driver.FindElementWithWait(By.CssSelector("#DetailFormbusiness_role-input div"));
        private IWebElement roleDropdownPopup(string role) => _driver.FindElementWithWait(By.XPath($"//div[contains(text(),'{role}')]"));
        private IWebElement categoryMultiSelect => _driver.FindElementWithWait(By.Id("DetailFormcategories-input"));
        private IWebElement categoryOption(string option) =>
            _driver.FindElementWithWait(By.XPath($"//div[@id='DetailFormcategories-input-search-list']//div[contains(text(),'{option}')]"));
        private IWebElement saveButton => _driver.FindElement(By.Id("DetailForm_save2"));

        public CreateContact(IWebDriver driver) : base(driver) => _driver = driver;

        public CreateContact EnterFirstName(string firstName)
        {
            firstNameInput.SendKeys(firstName);

            return this;
        }

        public CreateContact EnterLastName(string lastName)
        {
            lastNameInput.SendKeys(lastName);

            return this;
        }

        public CreateContact SelectRole(Roles role) 
        {
            roleDropdown.ClickUsingActions(_driver);
            roleDropdownPopup(role.ToString()).Click();

            return this;
        }

        public CreateContact SelectCategories(List<string> categories)
        {                       
            foreach(var category in categories)
            {
                categoryMultiSelect.ClickUsingActions(_driver);
                categoryOption(category).ClickUsingActions(_driver);
            }            

            return this;
        }

        public ContactView SaveForm()
        {
            saveButton.Click();
            new ContactsList(_driver).ConfirmSave();

            return new ContactView(_driver);
        }
    }

    public enum Roles
    {
        CEO,
        MIS,
        CFO,
        Sales,
        Admin
    }
}
