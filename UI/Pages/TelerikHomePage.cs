using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI.Pages
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
            ExtentReportManager.GetTest().Info("Opening Telerik homepage.");
            driver.Navigate().GoToUrl("https://www.telerik.com/");
            driver.Manage().Window.Maximize();
            ExtentReportManager.GetTest().Info("Telerik homepage opened and window maximized.");
        }

        public void ClickOnViewAllButton()
        {
            ExtentReportManager.GetTest().Info("Waiting for 'View All Products' button to be visible.");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var accountList = wait.Until(ExpectedConditions.ElementIsVisible(_telerikAllProductButton));
            ExtentReportManager.GetTest().Info("'View All Products' button is visible.");

            var actions = new Actions(driver);
            actions.MoveToElement(accountList).Perform();
            ExtentReportManager.GetTest().Info("Hovered over 'View All Products' button.");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(_viewAllProductButton));
            driver.FindElement(_viewAllProductButton).Click();
            ExtentReportManager.GetTest().Pass("'View All Products' button clicked.");
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

        public void VerifyTitle(string title)
        {
            Assert.IsTrue(driver.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }       
    }
}
