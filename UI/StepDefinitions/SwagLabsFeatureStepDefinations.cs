using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public sealed class SwagLabsFeatureStepDefinations
    {
        private List<(string Username, string Password)> _users;
        private SwagLabSteps swagLabSteps;

        public SwagLabsFeatureStepDefinations(SwagLabSteps swagLabSteps)
        {
            this.swagLabSteps = swagLabSteps;   
        }

        [BeforeScenario]
        public void LoadUsers()
        {
            var csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "Users.csv");
            var rows = CsvReaderHelper.ReadCsv(csvPath);
            // Skip header and map to tuple
            _users = rows.Skip(1)
                .Select(r => (Username: r[0], Password: r[1]))
                .ToList();
        }

        [Given(@"I launch the login page")]
        public void GivenILaunchTheLoginPage()
        {
            swagLabSteps.GoTo();
        }

        [When(@"I enter username and password for all users")]
        public void WhenIEnterUsernameAndPasswordForAllUsers()
        {
            foreach (var user in _users)
            {
                swagLabSteps.Login(user.Username, user.Password);
            }
        }

        [Then(@"I should be logged in according to the user type")]
        public void ThenIShouldBeLoggedInAccordingToTheUserType()
        {
            swagLabSteps.VerifyTheElementOnThePage();
        }

    }
}
