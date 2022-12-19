using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UIFramework
{
    public class BaseTestClass
    {
        protected IWebDriver driver;
        protected Constants? constants;

        public BaseTestClass()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            var configuration = File.ReadAllText("appsettings.json");

            constants = JsonConvert.DeserializeObject<Constants>(configuration);
        }
    }
}
