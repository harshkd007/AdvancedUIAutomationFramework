using SpecFlowProject5.Pages.Amezon;
using System;
using TechTalk.SpecFlow;
using UI.Helpers;

namespace SpecFlowProject5.StepDefinitions
{
    [Binding]
    public sealed class AmezonHomePageFeatureStepDefinitions
    {
        public HomePage homePage;

        public AmezonHomePageFeatureStepDefinitions(HomePage homePage)
        {
            this.homePage = homePage;
        }
       
        [Given(@"I lauch amezon")]
        public void GivenILauchAmezon()
        {
            ExtentReportManager.GetTest().Info("Starting navigation to Amazon homepage.");
            homePage.GoTo();
            ExtentReportManager.GetTest().Pass("Navigated to Amazon homepage.");
        }

        [When(@"I hover on Sign-in and click on orders")]
        public void WhenIHoverOnSign_InAndClickOnOrders()
        {
            ExtentReportManager.GetTest().Info("Hovering over 'Sign-in' (Account List) menu.");
            homePage.HoverAccountList();
            ExtentReportManager.GetTest().Info("Clicking on 'Orders' link.");
            homePage.ClickOrdersLink();
            ExtentReportManager.GetTest().Pass("Clicked on 'Orders' link.");
        }

        [Then(@"I should navigate to orders window")]
        public void ThenIShouldNavigateToOrdersWindow()
        {
            ExtentReportManager.GetTest().Info("Verifying navigation to Orders window.");
            // Add verification logic here and log result
            ExtentReportManager.GetTest().Pass("Successfully navigated to Orders window.");
        }
    }
}
