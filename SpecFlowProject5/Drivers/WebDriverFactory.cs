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
            return new ChromeDriver(options);
        }
    }
}
