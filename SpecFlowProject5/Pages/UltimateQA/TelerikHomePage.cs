using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject5.Pages.UltimateQA
{
    public class TelerikHomePage
    {
        public readonly IWebDriver driver;

        private readonly By _telerikAllProductButton = By.XPath("//*[@class=\"TK-Products-Menu-Item-Button\"]");
        private readonly By _viewAllProductButton = By.XPath("//*[text()='View all products']");

        public TelerikHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.telerik.com/");
            driver.Manage().Window.Maximize();
        }

        public void ClickOnViewAllButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var accountList = wait.Until(ExpectedConditions.ElementIsVisible(_telerikAllProductButton));

            // Hover over the element
            var actions = new Actions(driver);
            actions.MoveToElement(accountList).Perform();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(_viewAllProductButton));
            driver.FindElement(_viewAllProductButton).Click();

        }

        public void VerifyTitleAndNavigationOptions()
        {
            // Verify title contains "View all products"
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.Contains("View all products", StringComparison.OrdinalIgnoreCase));

            // List of expected navigation option texts
            var navOptions = new[]
            {
                "Bundles",
                "Web",
                "Mobile",
                "Desktop",
                "Reporting & QA",
                "UI/UX Tools",
                "Document Processing",
                "Free tools"
            };

            foreach (var option in navOptions)
            {
                var xpath = $"//div[@data-tlrk-plugin='navspy']//a[text()='{option}']";
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                if (element == null)
                {
                    throw new Exception($"Navigation option '{option}' not found.");
                }
            }
        }


    }
}
