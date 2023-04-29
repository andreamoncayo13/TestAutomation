using AutomatedTests.Constants;
using AutomatedTestsCore.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Configuration;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;
using AutomatedTests.QMonitor.Pages;

namespace AutomatedTestsCore.QMonitor.Pages
{
    public class DashboardPage : BasePage
    {
        public By dashboardTitleFinder = By.Id("dashboard-title");
        public By loginLinkElement = By.XPath("//*[contains(text(), 'Login')]");

        public DashboardPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            base.waitForPageToLoad(dashboardTitleFinder);
        }
        public void ClickLoginPageLink()
        {
            _webDriver.FindElement(loginLinkElement).Click();
        }

    }
}
