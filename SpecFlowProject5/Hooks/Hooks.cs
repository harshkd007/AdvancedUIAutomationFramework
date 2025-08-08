using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace SpecFlowProject5.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _driver;

        public Hooks(IWebDriver driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}