Feature: CRM Demo

Demo a basic approach to testing a web app using BDD


@mytag
Scenario Outline: User can Add a new Lead and convert it to a Contact
	Given User is on the main page of the Monday CRM app
	When User enters new Lead <fullname>
	And User Qualifies the Lead
	And User clicks on Move To Contacts
	Then Lead is moved to Contacts
	And the new Contact is set to <status>
	Examples: 
	| fullname     | status   |
	| Jack Bruce   | Partner  |
	| Dave Gilmour | Customer |
	
	
