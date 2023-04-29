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
    public class RegistrationPage : BasePage
    {
        public By firstNameFinder = By.Id("firstName");
        public By lastNameFinder = By.Id("lastName");
        public By emailFinder = By.Id("email");
        public By userNameFinder = By.Id("userName");
        public By userPasswordFinder = By.Id("password");
        public By submitBtnFinder = By.CssSelector("button[type='submit']");

        public RegistrationPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            base.waitForPageToLoad(userNameFinder);
        }

        public void Register(string firstName, string lastName, string email, string username, string password)
        {
            _webDriver.FindElement(firstNameFinder).SendKeys(firstName);
            _webDriver.FindElement(lastNameFinder).SendKeys(lastName);
            _webDriver.FindElement(emailFinder).SendKeys(email);
            _webDriver.FindElement(userNameFinder).SendKeys(username);
            _webDriver.FindElement(userPasswordFinder).SendKeys(password);
            base.waitForEnabledElement(submitBtnFinder);
            IWebElement element = _webDriver.FindElement(submitBtnFinder);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_webDriver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
