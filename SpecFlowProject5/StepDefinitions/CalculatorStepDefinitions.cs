using SpecFlowProject5.Pages;

namespace SpecFlowProject5.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef


        public HomePage homePage;

        public CalculatorStepDefinitions(HomePage homePage)
        {
            this.homePage = homePage;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            homePage.GoTo();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
           
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
          
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
           
        }
    }
}