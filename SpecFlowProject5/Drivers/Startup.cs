//using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using SolidToken.SpecFlow.DependencyInjection;
using SpecFlowProject5.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Threading.Tasks;

//[assembly: ScenarioDependencies]
namespace SpecFlowProject5.Drivers
{
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
            {
                var services = new ServiceCollection();

                // Add WebDriver factory and actual WebDriver
                services.AddSingleton<WebDriverFactory>();
                services.AddScoped<IWebDriver>(provider =>
                {
                    var factory = provider.GetRequiredService<WebDriverFactory>();
                    return factory.CreateWebDriver();
                });

                 // services.AddScoped(HomePage);
                 // Automatically register all classes in SpecFlowProject5.Pages namespace as scoped
                 var pageTypes = Assembly.GetExecutingAssembly()
                                 .GetTypes()
                                 .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "SpecFlowProject5.Pages");

                foreach (var type in pageTypes)
                {
                    services.AddScoped(type);
                }


                return services;
            }
        
    }
}
