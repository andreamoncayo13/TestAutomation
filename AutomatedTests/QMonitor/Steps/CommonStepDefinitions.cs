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
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I login to My Travel Web Site")]
        public void GivenILoginToMyTravelSite()
        {
            LoginPage loginPage = new LoginPage(_scenarioContext);
            loginPage.LogIn();
        }

        [Given(@"I try to login with an invalid password")]
        public void LoginWithInvalidPassword()
        {
            LoginPage loginPage = new LoginPage(_scenarioContext);
            loginPage.LogInWithError();
        }

        [Then(@"The vlog page opens")]
        public void ThenVlogPageOpens()
        {
            VlogPage vlogPage = new VlogPage(_scenarioContext);
            Assert.AreEqual("Comment", vlogPage.getPageTitle());
        }

        [Then(@"The dashboard page opens")]
        public void ThenTheDashboardPageOpens()
        {
            DashboardPage dashboardPage = new DashboardPage(_scenarioContext);
            Assert.AreEqual("Dashboard", dashboardPage.getPageTitle());
        }

        [Given(@"I Click on the Login Link")]
        public void IClickOnTheLoginLink()
        {
            DashboardPage dashboardPage = new DashboardPage(_scenarioContext);
            Assert.AreEqual("Dashboard", dashboardPage.getPageTitle());
            dashboardPage.ClickLoginPageLink();
        }

        [Then(@"I get a login error")]
        public void IGetALoginErrorMessage()
        {
            LoginPage loginPage = new LoginPage(_scenarioContext);
            Assert.AreEqual("User Not Found!", loginPage.GetLoginError());
        }
    }
}
