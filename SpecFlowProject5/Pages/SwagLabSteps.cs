using OpenQA.Selenium;
using SpecFlowProject5.Constants;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using UI.Helpers;

namespace UI.Pages
{
    public class SwagLabSteps
    {
        public readonly IWebDriver driver;

        // Locators
        private readonly By _username = By.Id("user-name");
        private readonly By _password = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _productText = By.XPath("//*[text()='Products']");

        public SwagLabSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoTo()
        {
            ExtentReportManager.GetTest().Info("Navigating to Amazon homepage.");
            driver.Navigate().GoToUrl(EnvironmentConstants.SwagLabUrl);
            driver.Manage().Window.Maximize();
            ExtentReportManager.GetTest().Pass("Swag Lab loaded and window maximized.");
        }

        public void Login(string username, string password)
        {
            driver.FindElement(_username).SendKeys(username);
            driver.FindElement(_password).SendKeys(password);
            driver.FindElement(_loginButton).Click();
            // Add actual login steps here
            ExtentReportManager.GetTest().Pass("Logged in successfully.");
        }

        public void VerifyTheElementOnThePage()
        {
            bool flag = driver.FindElement(_productText).Displayed;

            if (flag)
            {
                ExtentReportManager.GetTest().Pass("Login successful, 'Products' text is displayed.");
            }
            else
            {
                ExtentReportManager.GetTest().Fail("Login failed, 'Products' text is not displayed.");
            }
        }


    }
}
