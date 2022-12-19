using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UIFramework.PageObjects;
using UIFramework.PageObjects.ReportsAndSettingsMenu;
using UIFramework.PageObjects.SalesAndMarketingMenu.Contacts.Contacts;

namespace UIFramework
{
    [Binding]
    public class BaseBinding : BaseTestClass
    {
        public BaseBinding() : base()
        {
        }

        [BeforeScenario]
        public void BeforeScenario() 
        {
            driver.Navigate().GoToUrl(constants?.Url);
        }

        [AfterScenario] 
        public void AfterScenario()
        {
            driver.Quit();
        }

        [Given("User login to the page")]
        public void UserLoginToThePage()
        {
            var loginPage = new LoginPage(driver);

            loginPage.Login(constants?.UserName, constants?.Password);
        }

        [Given("Navigates to Contacts in SalesAndMarketing")]
        public void GivenNavigatesToContactsInSalesAndMarketing()
        {
            var mainPage = new MainPage(driver);

            mainPage.SalesAndMarketingMenu().OpenContacts().CreateContact();
        }

        [Then(@"Creates contact with below data:")]
        public void ThenCreatesContactWithBelowData(Table table)
        {
            dynamic data = table.CreateDynamicInstance(false);

            var page = new CreateContact(driver);

            page.EnterFirstName((string)data.firstName)
                .EnterLastName((string)data.lastName)
                .SelectRole(Enum.Parse(typeof(Roles), data.role));

            var categories = ((string)data.categories).Split(",").Select(x => x.Trim());

            page.SelectCategories(categories.ToList());
        }

    }
}
