using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UIFramework.PageObjects;
using UIFramework.PageObjects.SalesAndMarketingMenu.Contacts;
using UIFramework.PageObjects.SalesAndMarketingMenu.Contacts.Contacts;

namespace UIFramework
{
    [Binding]
    public class BaseBinding : BaseTestClass
    {
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

        [When(@"Creates contact with below data:")]
        public void ThenCreatesContactWithBelowData(Table table)
        {
            dynamic data = table.CreateDynamicInstance(false);
            var categories = ((string)data.categories).Split(",").Select(x => x.Trim()).ToList();

            new CreateContact(driver)
                .EnterFirstName((string)data.firstName)
                .EnterLastName((string)data.lastName)
                .SelectRole(Enum.Parse(typeof(Roles), data.role))
                .SelectCategories((List<string>)categories)
                .SaveForm();
        }

        [Then(@"Verify user data stored in scenario context:")]
        public void VerifyUserDataStoredInScenarioContext(Table table)
        {
            dynamic data = table.CreateDynamicInstance(false);
            var categories = ((string)data.categories).Split(",").Select(x => x.Trim()).ToList();
            var page = new ContactView(driver);

            Assert.AreEqual(data.firstName, page.GetFirstName());
            Assert.AreEqual(data.lastName, page.GetLastName());
            Assert.AreEqual(data.role, page.GetRole());
            Assert.AreEqual(categories, page.GetCategories());
        }

    }

    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public List<string> Categories { get; set; }
    }
}
