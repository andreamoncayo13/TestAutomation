Feature: Login

A short summary of the feature

@Login
Scenario: I am able to Open login and view dashboard
	Given I login to My Travel Web Site
	Then The dashboard page opens

Scenario: I get a login error when I enter an invalid password
	Given I try to login with an invalid password
	Then I get a login error
