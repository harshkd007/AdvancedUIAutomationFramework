using TechTalk.SpecFlow;
using OpenQA.Selenium;
using UI.Helpers;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IWebDriver _driver;

    public Hooks(ScenarioContext scenarioContext, IWebDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver; // Adjust if you use DI or another driver management
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit();
    }

    [AfterStep]
    public void AfterStep()
    {
        if (_scenarioContext.TestError != null)
        {
            var screenshotPath = ScreenshotHelper.CaptureScreenshot(_driver, _scenarioContext.ScenarioInfo.Title);
            // Attach to Extent report
            ExtentReportManager.GetTest().Fail("Step failed. Screenshot attached.")
                .AddScreenCaptureFromPath(screenshotPath);
        }
    }
}