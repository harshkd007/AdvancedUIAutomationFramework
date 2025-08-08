using SpecFlowProject5.Pages.UltimateQA;
using System;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;

namespace SpecFlowProject5.StepDefinitions
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
            telerikHomePage.GoTo();
        }

        [When(@"I click on ""([^""]*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            telerikHomePage.ClickOnViewAllButton();
        }

        [Then(@"I should navigate to ""([^""]*)"" page")]
        public void ThenIShouldNavigateToPage(string p0)
        {
            telerikHomePage.VerifyTitleAndNavigationOptions();  
        }

    }
}
