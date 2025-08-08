Feature: Amezon Home Page Feature

@mytag
Scenario: Verify Home Page Functionality
	Given I launch amezon 
	When I hover on Sign-in and click on orders
	Then I should navigate to orders window