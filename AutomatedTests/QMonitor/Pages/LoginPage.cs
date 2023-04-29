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
    public class LoginPage:BasePage
    {
        private string _userName;
        private string _password;

        public By userNameFinder = By.Id("username");
        public By userPasswordFinder = By.Id("password");
        public By loginButtonFinder = By.CssSelector("button[type='submit']");
        public By loginErrorMsgFinder = By.XPath("//*[contains(text(), 'User Not Found!')]");
        public By registerLinkFinder = By.Id("register-link");
        public By h3Finder = By.CssSelector("h3[class='pt-3 font-weight-bold']");


        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            base.waitForPageToLoad(userNameFinder);
        }

        public Boolean VerifyIAmAtLoginPage()
        {
            Boolean atLoginPage = true;
            try
            {
                base.waitForPageToLoad(h3Finder);
                atLoginPage = _webDriver.FindElement(h3Finder).Text == "Login";
            }
            catch (Exception ex)
            {
                atLoginPage = false;
            }
            return atLoginPage;
        }
 
        public void LogIn()
        {
            _userName = Properties.USERNAME;
            _password = Properties.PASSWORD;
            IWebElement userNameInput = _webDriver.FindElement(userNameFinder);
            IWebElement passwordInput = _webDriver.FindElement(userPasswordFinder);
            IWebElement loginBtn = _webDriver.FindElement(loginButtonFinder);
            userNameInput.SendKeys(_userName);
            passwordInput.SendKeys(_password);
            loginBtn.Click();
        }

        public void LogInWithError()
        {
            _userName = Properties.USERNAME;
            _password = "invalid";
            IWebElement userNameInput = _webDriver.FindElement(userNameFinder);
            IWebElement passwordInput = _webDriver.FindElement(userPasswordFinder);
            IWebElement loginBtn = _webDriver.FindElement(loginButtonFinder);
            userNameInput.SendKeys(_userName);
            passwordInput.SendKeys(_password);
            loginBtn.Click();
        }

        public string GetLoginError()
        {
            base.waitForPageToLoad(loginErrorMsgFinder);
            return _webDriver.FindElement(loginErrorMsgFinder).Text;
        }

        public void ClickOnRegistrationLink()
        {
            _webDriver.FindElement(registerLinkFinder).Click();
        }
    }
}
