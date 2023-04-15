using AutomatedTestsCore.QMonitor.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomatedTests.QMonitor.Steps
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public RegistrationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I go to the registration page")]
        public void IGoToTheRegistrationPage()
        {
            LoginPage loginPage = new LoginPage(_scenarioContext);
            loginPage.ClickOnRegistrationLink();
        }

        [When(@"I enter random user data")]
        public void IEnterRandomUserData()
        {
            RegistrationPage registrationPage = new RegistrationPage(_scenarioContext);
            string firstName = GenerateRandomString();
            string lastName = GenerateRandomString();
            string email = GenerateRandomString() + "@invalid.com";
            string username = firstName;
            string password = "abc123";
            registrationPage.Register(firstName, lastName, email, username, password);
        }

        [Then(@"I am able to register as a new user")]
        public void IamAbleToRegisterAsNewUser()
        {
            LoginPage loginPage = new LoginPage(_scenarioContext);
            Assert.IsTrue(loginPage.VerifyIAmAtLoginPage());
        }

        

        private string GenerateRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path.Substring(0, 8);  // Return 8 character string
        }
    }
}
