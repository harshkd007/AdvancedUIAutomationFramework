Feature: Telerik

A short summary of the feature


Scenario: Verify Home Page Functionality
	Given I lauch Telerik website
	When I click on "View All Products" button
	Then I should navigate to "All Products" page

Scenario: Verify Attach Screenshots Functionality for failed test case
	Given I lauch Telerik website
	When I click on "View All Products" button
	Then I should see 'Invalid title' title
	
