Feature: CreateAccount

API Test for www.automationexercise.com for CreateAccount

@CreateAccount
Scenario: Register User
	Given that user wants to create an account
	When CreateAccount is invoked with all parameter populated
	Then user is created

@CreateAccount @FailingTest
Scenario: Delete User
	Given that user wants to delete an account
	When DeleteAccount is invoked with required parameters
	Then account is deleted
