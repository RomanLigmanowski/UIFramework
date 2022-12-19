using OpenQA.Selenium;

namespace UIFramework.PageObjects
{
    public class BasePageObject
    {
        private IWebDriver _driver;

        private IEnumerable<IWebElement> loading => _driver.FindElements(By.Id("ajaxStatusDiv"));

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;

            if (loading.Count() > 0) 
            {
                var pageLoaded = false;

                while (!pageLoaded)
                {
                    pageLoaded = loading.First().Text.Contains("Loading") ? false : true;
                }
            }
        }
    }
}
