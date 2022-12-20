using OpenQA.Selenium;

namespace UIFramework.PageObjects.SalesAndMarketingMenu.Contacts
{
    public class ContactView : BasePageObject
    {
        private IWebDriver _driver;

        private IWebElement fullName => _driver.FindElementWithWait(By.CssSelector("div#_form_header h3"));
        private IWebElement categories => _driver.FindElementWithWait(By.XPath("//*[contains(text(),'Category')]/parent::li"));
        private IWebElement role => _driver.FindElementWithWait(By.XPath("//p[contains(text(),'Business')]/following-sibling::div"));

        public ContactView(IWebDriver driver) : base(driver) => _driver = driver;

        public string GetFirstName() => fullName.Text.Split(" ").First().Trim();
        
        public string GetLastName() => fullName.Text.Split(" ").ElementAt(1).Trim();

        public List<string> GetCategories() => categories.Text.Replace("Category", "").Split(",").Select(c => c.Trim()).ToList();

        public string GetRole() => role.Text;
    }
}
