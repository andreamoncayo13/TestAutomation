using AutomatedTestsCore.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomatedTests.QMonitor.Pages
{
    public class BasePage
    {
        public readonly ScenarioContext _scenarioContext;
        public IWebDriver _webDriver;

        public BasePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = scenarioContext.Get<IWebDriver>(TestAutomationConstants.WEBDRIVER_NAME);
        }

        public String getPageTitle()
        {
            return _webDriver.Title;
        }
        public void waitForPageToLoad(By elementFinder)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(elementFinder));
        }
        public void waitForEnabledElement(By elementFinder)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(elementFinder));
        }

    }
}
