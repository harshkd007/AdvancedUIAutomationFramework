using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject5.Pages
{
    public class HomePage
    {
        public readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://example.com/login");
        }
    }
}
