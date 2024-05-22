using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoProject1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoProject1.Pages
{
    public class BasePage
    {
       protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement WaitForElementFoundByCssSelector(string selector)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(By.CssSelector(selector)));
        }

        public IWebElement WaitForElementFoundById(string selector)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(By.Id(selector)));
        }

        public IWebElement WaitForElementFoundByXPath(string selector)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(By.XPath(selector)));
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

       
    }
}
