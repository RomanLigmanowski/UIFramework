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
                    var loadSaveText = loading.First().Text;
                    pageLoaded = loadSaveText.Contains("Loading") | loadSaveText.Contains("Saving") ? false : true;
                }
            }
        }
    }
}
