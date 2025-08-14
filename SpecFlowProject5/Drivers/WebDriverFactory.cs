using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.IO;

namespace UI.Drivers
{
    public class WebDriverFactory
    {
        public IWebDriver CreateWebDriver()
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();

            var browser = config["Browser"];

            switch (browser)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-dev-shm-usage");
                    chromeOptions.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
                    return new ChromeDriver(chromeOptions);

                case "Edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--disable-extensions");
                    edgeOptions.AddArgument("--disable-gpu");
                    edgeOptions.AddArgument("--no-sandbox");
                    edgeOptions.AddArgument("--disable-dev-shm-usage");
                    edgeOptions.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new Exception($"Unsupported browser: {browser}");
            }
        }
    }
}


