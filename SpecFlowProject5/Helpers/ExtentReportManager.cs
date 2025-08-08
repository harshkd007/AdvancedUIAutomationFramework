using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace UI.Helpers
{
    public static class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _sparkReporter;
        private static ExtentTest _test;

        public static void InitReport()
        {
            // Ensure the Reports folder exists
            var reportsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            if (!Directory.Exists(reportsDir))
            {
                Directory.CreateDirectory(reportsDir);
            }

            var reportPath = Path.Combine(reportsDir, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
            _sparkReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(_sparkReporter);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static ExtentTest GetTest()
        {
            return _test;
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}