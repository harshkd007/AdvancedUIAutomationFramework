using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using System.IO;

namespace UI.Helpers
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string scenarioName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDir);
            var filePath = Path.Combine(screenshotsDir, $"{scenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(filePath);
            return filePath;
        }
    }
}