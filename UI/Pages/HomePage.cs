using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject5.Constants;
using System;
using TechTalk.SpecFlow;
using UI.Helpers;

namespace UI.Pages
{
    public class HomePage
    {
        public readonly IWebDriver driver;

        // Locators
        private readonly By _accountList = By.Id("nav-link-accountList");
        private readonly By _ordersLink = By.Id("nav_prefetch_yourorders");
        private readonly By _continueShopping = By.XPath("//*[text()='Continue shopping']");



        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoTo()
        {
            ExtentReportManager.GetTest().Info("Navigating to Amazon homepage.");
            driver.Navigate().GoToUrl(EnvironmentConstants.AmazonHomeUrl);
            driver.Manage().Window.Maximize();
            ExtentReportManager.GetTest().Pass("Amazon homepage loaded and window maximized.");
        }

        public void HoverAccountList()
        {
            ExtentReportManager.GetTest().Info("Clicking 'Continue shopping' before hovering Account List.");
            ClickContinueShopping(); // Ensure any previous actions are cleared before hovering
            ExtentReportManager.GetTest().Info("Waiting for Account List element to be visible.");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var accountList = wait.Until(ExpectedConditions.ElementIsVisible(_accountList));
            ExtentReportManager.GetTest().Info("Hovering over Account List.");
            new Actions(driver).MoveToElement(accountList).Perform();
            ExtentReportManager.GetTest().Pass("Hovered over Account List.");
        }

        public void ClickOrdersLink()
        {
            ExtentReportManager.GetTest().Info("Waiting for Orders link to be clickable.");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ordersLink = wait.Until(ExpectedConditions.ElementToBeClickable(_ordersLink));
            ExtentReportManager.GetTest().Info("Clicking on Orders link.");
            ordersLink.Click();
            ExtentReportManager.GetTest().Pass("Clicked on Orders link.");
        }

        public void ClickContinueShopping()
        {
            ExtentReportManager.GetTest().Info("Waiting for 'Continue shopping' button to be clickable.");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var continueShoppingButton = wait.Until(ExpectedConditions.ElementToBeClickable(_continueShopping));
            continueShoppingButton.Click();
        }
    }
}
