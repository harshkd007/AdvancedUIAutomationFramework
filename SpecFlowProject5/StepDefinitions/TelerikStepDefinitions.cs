using System;
using TechTalk.SpecFlow;
using UI.Helpers;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public sealed class TelerikStepDefinitions
    {
        public TelerikHomePage telerikHomePage;

        public TelerikStepDefinitions(TelerikHomePage telerikHomePage)
        {
            this.telerikHomePage = telerikHomePage;
        }

        [Given(@"I lauch Telerik website")]
        public void GivenILauchTelerikWebsite()
        {
            ExtentReportManager.GetTest().Info("Starting navigation to Telerik website.");
            telerikHomePage.GoTo();
            ExtentReportManager.GetTest().Pass("Navigated to Telerik website.");
        }

        [When(@"I click on ""([^""]*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            ExtentReportManager.GetTest().Info($"Attempting to click on '{p0}' button.");
            telerikHomePage.ClickOnViewAllButton();
            ExtentReportManager.GetTest().Pass($"Clicked on '{p0}' button.");
        }

        [Then(@"I should navigate to ""([^""]*)"" page")]
        public void ThenIShouldNavigateToPage(string p0)
        {
            ExtentReportManager.GetTest().Info($"Verifying navigation to '{p0}' page.");
            telerikHomePage.VerifyTitleAndNavigationOptions();
            ExtentReportManager.GetTest().Pass($"Successfully navigated to '{p0}' page and verified navigation options.");
        }

        [Then(@"I should see '([^']*)' title")]
        public void ThenIShouldSeeTitle(string title)
        {
            telerikHomePage.VerifyTitle(title);
        }


    }
}
