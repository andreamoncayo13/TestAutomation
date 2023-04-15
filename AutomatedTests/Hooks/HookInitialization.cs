using AutomatedTests.Constants;
using AutomatedTestsCore.Constants;
using AutomatedTestsCore.Drivers;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace AutomatedTestsCore.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        private readonly ScenarioContext _scenarioContext;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public HookInitialization(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            //var requestedBrowser = ConfigurationManager.AppSettings["BrowserAgent"];
            var requestedBrowser = Properties.BROWSER_AGENT;
            DriverFactory driverFactory = new DriverFactory(_scenarioContext);
            var driver = driverFactory.CreateDriver(requestedBrowser);
            driver.Navigate().GoToUrl(Properties.BASE_URL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>(TestAutomationConstants.WEBDRIVER_NAME).Quit();
        }
    }
}