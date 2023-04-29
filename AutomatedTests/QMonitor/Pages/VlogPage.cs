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
    public class VlogPage : BasePage
    {
        public By VlogPageFinderElement = By.Id("vlog");

        public VlogPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            base.waitForPageToLoad(VlogPageFinderElement);
        }

        /*       public bool IsVlogPageFound()
               {
                   IWebElement vlogfinder = _webDriver.FindElement(VlogPageFinderElement);
                   if(vlogfinder != null) {
                       return true;
                   } 
                   else 
                    { 
                       return false; 
                   }

               }*/
    }
}