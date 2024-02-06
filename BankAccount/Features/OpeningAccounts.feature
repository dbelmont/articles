Feature: Opening an account
	As a new customer
	I want to open a bank account
	So that I can keep my money safe

Rule: Accounts can receive deposits
	
Scenario: Open a Checking account
	Given a customer opens a new Checking account with an initial deposit of 10.0
	When checking the balance
	Then the balance the account's balance should be 10.0