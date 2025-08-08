using SpecFlowProject5.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject5.StepDefinitions
{
    [Binding]
    public sealed class AmezonHomePageFeatureStepDefinitions
    {
        public HomePage homePage;

        /*
         // SpecFlow uses the registered services to automatically inject dependencies into your step definition classes.
         */

        public AmezonHomePageFeatureStepDefinitions(HomePage homePage)
        {
            this.homePage = homePage;
        }
       
        [Given(@"I lauch amezon")]
        public void GivenILauchAmezon()
        {
            homePage.GoTo();
        }

        [When(@"I hover on Sign-in and click on orders")]
        public void WhenIHoverOnSign_InAndClickOnOrders()
        {
            homePage.HoverAccountList();
            homePage.ClickOrdersLink();
        }

        [Then(@"I should navigate to orders window")]
        public void ThenIShouldNavigateToOrdersWindow()
        {
            
        }


    }
}
