
Feature: LoginTest

Scenario: Create contract
	Given User login to the page
	And Navigates to Contacts in SalesAndMarketing
	When Creates contact with below data:
		| firstName | lastName | role | categories           |
		| John      | Doe      | CEO  | Customers, Suppliers |
	Then Verify user data stored in scenario context:
		| firstName | lastName | role | categories           |
		| John      | Doe      | CEO  | Customers, Suppliers |
