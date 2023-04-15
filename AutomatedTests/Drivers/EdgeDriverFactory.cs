using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using AutomatedTestsCore.Constants;

namespace AutomatedTests.Drivers
{
    internal class EdgeDriverFactory
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public EdgeDriverFactory(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver CreateDriver()
        {
            var options = new EdgeOptions();
            //All ProfilePreferences are listed under:
            // https://src.chromium.org/viewvc/chrome/trunk/src/chrome/common/pref_names.cc?view=markup
            options.AddUserProfilePreference("download.prompt_for_download", true);
            //////////////// end of preferences

            //flags are listed under:
            //chrome://flags/
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("allow-insecure-localhost");
            ////////////// end of flags

            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            _scenarioContext.Set(driver, TestAutomationConstants.WEBDRIVER_NAME);
            return driver;
        }
    }
}
