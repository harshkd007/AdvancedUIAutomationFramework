using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject5.Constants;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject5.Pages.Amezon
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
            driver.Navigate().GoToUrl(EnvironmentConstants.AmazonHomeUrl);
            driver.Manage().Window.Maximize();
        }

        public void HoverAccountList()
        {
            ClickContinueShopping(); // Ensure any previous actions are cleared before hovering
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var accountList = wait.Until(ExpectedConditions.ElementIsVisible(_accountList));
            new Actions(driver).MoveToElement(accountList).Perform();
        }

        public void ClickOrdersLink()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ordersLink = wait.Until(ExpectedConditions.ElementToBeClickable(_ordersLink));
            ordersLink.Click();
        }

        public void ClickContinueShopping()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var continueShoppingButton = wait.Until(ExpectedConditions.ElementToBeClickable(_continueShopping));
            continueShoppingButton.Click();
        }
    }
}
