
Feature: LoginTest

Scenario: Create contract
	Given User login to the page
	And Navigates to Contacts in SalesAndMarketing
	Then Creates contact with below data:
		| firstName | lastName | role | categories           |
		| John      | Doe      | CEO  | Customers, Suppliers |