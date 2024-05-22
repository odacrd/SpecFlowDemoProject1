using OpenQA.Selenium;


namespace SpecFlowDemoProject1.Pages
{
    public class Main: BasePage
    {
        

        public Main(IWebDriver driver) :base(driver)
        {
        }

        //Find elements by..
        
        private IWebElement ContactsBtn => driver.FindElement(By.Id("leftpane-item-6672491588-board"));
        private IWebElement LeadsBtn => driver.FindElement(By.Id("leftpane-item-6672491572-board"));



        public void WaitForLeftPanel()
        {
            WaitForElementFoundByCssSelector("div[data-testid='leftpane']");
        }

        public void ClickContactsBtn()
        {
            ContactsBtn.Click();
        }

        public void ClickLeadsBtn()
        {
            LeadsBtn.Click();
        }
    }
}
