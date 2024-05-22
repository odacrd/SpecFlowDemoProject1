using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowDemoProject1.Pages;
using SpecFlowDemoProject1.Drivers;

namespace SpecFlowDemoProject1.Pages
{
    public class LoginPage: BasePage
    {
        //CRM login page
        private const string CRMLoginUrl = "https://odacrd.monday.com/auth/login_monday/email_password";
        

        public LoginPage(IWebDriver driver) :base(driver)
        {
        }

        //Find elements by..
        private IWebElement username => driver.FindElement(By.Id("user_email"));
        private IWebElement password => driver.FindElement(By.Id("user_password"));
        private IWebElement loginBtn => driver.FindElement(By.CssSelector("button[data-testid='button']"));

        public LoginPage EnterUserName()
        {
            username.Clear();
            username.SendKeys("od5514690@gmail.com");
            return this;
        }

        public LoginPage EnterPassword() 
        {
            password.Clear();
            password.SendKeys("3eBF-7)-a&!w8X6");
            return this;
        }

        public void ClickLogin() 
        {
            loginBtn.Click();
        }
        public LoginPage GoToLoginPage()
        {
            driver.Navigate().GoToUrl(CRMLoginUrl);
            driver.Manage().Window.Maximize();
            return this;
           
        }
    }
}
