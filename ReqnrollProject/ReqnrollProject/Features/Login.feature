Feature: Login

API Test for www.automationexercise.com for Login

@Login
Scenario: Login with Valid Credentials
	Given I have login with email "hezron.v.tan@gmail.com"
	And used password "Password789!"
	When I verify the the login credentials
	Then the user exists

@Login
Scenario: Login with Invalid Credentials
	Given I have login with email "hezron.v.tan@gmail.com"
	And used password "IncorectPassword"
	When I verify the the login credentials
	Then the user is not found

@Login
Scenario: Login without Email Parameter
	Given I have login with empty email
	And used password "Password789!"
	When I verify the the login credentials
	Then the bad request is returned