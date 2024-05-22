using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoProject1.Pages
{
    public class ContactsPage: BasePage
    {

        public ContactsPage(IWebDriver driver) :base(driver)
        {
        }

        //Find elements by..
        private IWebElement h1header => driver.FindElement(By.XPath("//h1[text()='Contacts']"));

        public ContactsPage WaitForContactsPageHeader()
        {
            WaitForElementFoundByXPath("//h1[text()='Contacts']");
            return this;
            
        }

        public IWebElement GetLastRowFullName()
        {
            Thread.Sleep(1000);
            IWebElement lastRow = driver.FindElement(By.CssSelector("div[class~='last-pulse']"));
            IWebElement namecol = lastRow.FindElement(By.CssSelector("div[class~='col-identifier-name']"));
            IWebElement fullname = namecol.FindElement(By.CssSelector("div[class='name-cell-text'] span"));

            return fullname;
        }

        public ContactsPage SetLastStatus(string contacttype)
        {
            Thread.Sleep(5000);
            IWebElement firstRow = driver.FindElement(By.CssSelector("div[class~='last-pulse']"));
            IWebElement statuscol = firstRow.FindElement(By.CssSelector("div[class='grid-cell-component-wrapper grid-cell-wrapper-component col-identifier-status']"));

            statuscol.Click();
            IWebElement statuspicker = WaitForElementFoundByCssSelector("div[class='status-picker-content']");
            ScrollToElement(statuspicker);
            IWebElement typeOption = statuspicker.FindElement(By.XPath("//*[starts-with(@id,'6672491588_status_')]/div/div/div/span[contains(text(),'"+contacttype+"')]"));
           
            typeOption.Click();
            Thread.Sleep(1000);
            return this;
        }
    }
}
