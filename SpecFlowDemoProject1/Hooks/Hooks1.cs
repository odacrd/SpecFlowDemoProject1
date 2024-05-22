using OpenQA.Selenium;
using SpecFlowDemoProject1.Drivers;
using SpecFlowDemoProject1.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        
        [BeforeScenario]
        public void BeforeScenario(BrowserDriver browserDriver)
        {
            LoginPage loginPage = new LoginPage(browserDriver.Current);
            loginPage.GoToLoginPage()
                .EnterUserName()
                .EnterPassword()
                .ClickLogin();
        }

        [AfterScenario]
        public void AfterScenario(BrowserDriver browserDriver)
        {
            Thread.Sleep(5000);
            browserDriver.Dispose();
        }
    }
}