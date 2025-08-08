using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject5.Drivers
{
    public class WebDriverFactory
    {
        public IWebDriver CreateWebDriver()
        {
            var options = new ChromeOptions();

            // Disable extensions for faster startup
            options.AddArgument("--disable-extensions");

            // Disable GPU (optional, but can help on some systems)
            options.AddArgument("--disable-gpu");

            // No sandbox (useful in CI or restricted environments)
            options.AddArgument("--no-sandbox");

            // Disable shared memory usage (useful in Docker/CI)
            options.AddArgument("--disable-dev-shm-usage");

            // Disable images for faster page load (optional, but you won't see images)
            options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);

            return new ChromeDriver(options);
        }
    }
}
