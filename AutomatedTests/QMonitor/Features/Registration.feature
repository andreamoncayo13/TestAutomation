Feature: Registration

A short summary of the feature

@Registration
Scenario: I am able to register a new user
	Given I go to the registration page
	When I enter random user data
	Then I am able to register as a new user

