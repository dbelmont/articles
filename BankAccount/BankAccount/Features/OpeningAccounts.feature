Feature: Opening an account
	As a new customer
	I want to open a bank account
	So that I can keep my money safe

Rule: There are two types of Bank Accounts: Checking and Savings; When opening an account, the client may choose to make an initial deposit
	
Scenario: Open a Checking account
	Given a customer opens a new Checking account with an initial deposit of $10.0
	When checking the balance
	Then the account's balance should be $10.0
	
Scenario: Open a Savings account
	Given a customer opens a new Savings account with an initial deposit of $50.0
	When checking the balance
	Then the account's balance should be $50.0