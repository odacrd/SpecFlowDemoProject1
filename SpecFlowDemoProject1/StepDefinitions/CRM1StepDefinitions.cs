using System;
using TechTalk.SpecFlow.Assist;
using SpecFlowDemoProject1.Pages;
using SpecFlowDemoProject1.Drivers;

namespace SpecFlowDemoProject1.StepDefinitions
{
    [Binding]
    public sealed class CRM1StepDefinitions
    {
        private Main main;
        private ContactsPage contactsPage;
        private LeadsPage leadsPage;
        private readonly BrowserDriver browserDriver;
        private readonly ScenarioContext scenarioContext;

        public CRM1StepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            this.browserDriver = browserDriver;
            this.scenarioContext = scenarioContext;  
        }

        [Given(@"User is on the main page of the Monday CRM app")]
        public void GivenUserIsOnTheMainPage()
        {
            main = new Main(this.browserDriver.Current);
            main.WaitForLeftPanel();
        }


        [When(@"User clicks on Contacts")]
        public void GoToContacts()
        {
            main.ClickContactsBtn();
            contactsPage = new ContactsPage(this.browserDriver.Current);
        }

        [When(@"User clicks on Leads")]
        public void GoToLeads()
        {
            main.ClickLeadsBtn();
            leadsPage = new LeadsPage(this.browserDriver.Current);
        }



        [When(@"User enters new Lead (.*)")]
        public void WhenUserEntersNewLead(string fullname)
        {
            GoToLeads();
            leadsPage
                .ClickOnNewLeadBtn()
                .EnterNewLeadName(fullname);
            this.scenarioContext["fullname"] = fullname;
        }
        

        [When(@"User clicks on Move To Contacts")]
        public void WhenUserClicksOnMoveToContacts()
        {
            leadsPage
                .ClickOnFirstMovetoContacts()
                .CloseNotificationPopUp();
            GoToContacts();
        }

        [When(@"User Qualifies the Lead")]
        public void WhenUserQualifiesTheLead()
        {
            leadsPage.SetFirstStatusQualified();
        }


        [Then(@"Lead is moved to Contacts")]
        public void ThenLeadIsMovedToContacts()
        {
            contactsPage
                .WaitForContactsPageHeader()
                .GetLastRowFullName().Text.Should().Contain(this.scenarioContext["fullname"].ToString());
            
        }

        [Then(@"the new Contact is set to (.*)")]
        public void ThenTheNewContactIsSetToCustomer(string contacttype)
        {
            contactsPage.SetLastStatus(contacttype);
        }



    }

}
