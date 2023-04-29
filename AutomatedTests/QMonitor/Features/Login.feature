Feature: Login

A short summary of the feature

@Login
Scenario: I am able to Open the Homepage and Login
	Given I Click on the Login Link
	Given I login to My Travel Web Site
	Then The vlog page opens

Scenario: I get a login error when I enter an invalid password
	Given I Click on the Login Link
	Given I try to login with an invalid password
	Then I get a login error
