using OpenQA.Selenium;

namespace UIFramework.PageObjects
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private IWebElement userNameInput => _driver.FindElement(By.Id("login_user"));
        private IWebElement passwordInput => _driver.FindElement(By.Id("login_pass"));
        private IWebElement loginButton => _driver.FindElement(By.Id("login_button"));

        public LoginPage(IWebDriver driver) => _driver = driver;

        public MainPage Login(string? username, string? password)
        {
            userNameInput.SendKeys(username);
            passwordInput.SendKeys(password);
            loginButton.Click();

            return new MainPage(_driver);
        }
    }
}
