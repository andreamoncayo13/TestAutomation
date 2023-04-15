using AutomatedTests.Drivers;
using AutomatedTestsCore.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomatedTestsCore.Drivers
{
    internal class DriverFactory
    {
        private readonly ScenarioContext _scenarioContext;

        public DriverFactory(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public IWebDriver CreateDriver(string browserStr)
        {
            SupportedBrowsers browser = (SupportedBrowsers) Enum.Parse(typeof(SupportedBrowsers),browserStr);
            switch (browser)
            {
                case SupportedBrowsers.Edge: return new EdgeDriverFactory(_scenarioContext).CreateDriver();
                default: return new ChromeDriverFactory(_scenarioContext).CreateDriver();
            }
        }
    }
}
