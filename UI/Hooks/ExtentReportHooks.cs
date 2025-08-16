using AventStack.ExtentReports;
using TechTalk.SpecFlow;
using UI.Helpers;

namespace UI.Hooks
{
    [Binding]
    public class ExtentReportHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ExtentReportManager.CreateTest(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var test = ExtentReportManager.GetTest();
            if (scenarioContext.TestError != null)
            {
                test.Fail(scenarioContext.TestError.Message);
            }
            else
            {
                test.Pass("Step passed");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }
    }
}