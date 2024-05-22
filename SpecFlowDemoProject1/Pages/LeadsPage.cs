using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoProject1.Pages
{
    public class LeadsPage: BasePage
    {

        public LeadsPage(IWebDriver driver) :base(driver)
        {
        }

        //Find elements by..
        private IWebElement h1header => driver.FindElement(By.XPath("//h1[text()='Leads']"));
  


        public LeadsPage GetLeadsPage()
        {
            h1header.Text.Should().Be("Leads");
            return this;
        }
        public LeadsPage EnterNewLeadName(string fullname) 
        {
            Thread.Sleep(1000);
            IWebElement firstRow = driver.FindElement(By.CssSelector("div[class~='first-pulse']"));
            IWebElement namecol = firstRow.FindElement(By.CssSelector("div[class~='col-identifier-name']"));
            IWebElement editName = namecol.FindElement(By.CssSelector("div[class='name-cell-text is-editing'] input"));
            editName.SendKeys(fullname+"\t");
            return this;
        }

        public LeadsPage ClickOnNewLeadBtn()
        {
            Thread.Sleep(5000);
            IWebElement newLead = driver.FindElement(By.CssSelector("#board-header-view-bar > div > div.add-board-entity-button-wrapper > div > div:nth-child(1) > button"));
            newLead.Click();
            return this;
        }

        public LeadsPage ClickOnFirstMovetoContacts()
        {
            Thread.Sleep(5000);
            IWebElement firstRow = driver.FindElement(By.CssSelector("div[class~='first-pulse']"));
            IWebElement buttoncol = firstRow.FindElement(By.CssSelector("div[class~='col-identifier-button']"));
            IWebElement moveToContactsBtn = buttoncol.FindElement(By.TagName("button"));
            moveToContactsBtn.Click();
            Thread.Sleep(5000);
            return this;
        }

        public LeadsPage SetFirstStatusQualified()
        {
            Thread.Sleep(5000);
            IWebElement firstRow = driver.FindElement(By.CssSelector("div[class~='first-pulse']"));
            IWebElement statuscol = firstRow.FindElement(By.CssSelector("div[class~='col-identifier-lead_status']"));

            statuscol.Click();
            IWebElement statuspicker = WaitForElementFoundByCssSelector("div[class='status-picker-content']");
            ScrollToElement(statuspicker);
            IWebElement qualifiedOption = statuspicker.FindElement(By.Id("6672491572_lead_status_103"));
            qualifiedOption.Click();
            Thread.Sleep(1000);
            return this;
        }

        public void CloseNotificationPopUp()
        {
            WaitForElementFoundByCssSelector("#automation-live-status-notification-container > div > svg").Click();
        }

    }
}
