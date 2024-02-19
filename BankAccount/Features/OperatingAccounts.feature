Feature: Operating bank accounts
	As an bank account owner
	I want to make deposits and withdraws from my account
	So that I have some balance in my account
	
Background:
	Given a customer opens a new Savings account with an initial deposit of $50.0

Rule: Accounts can receive deposits or have money withdrawn from them
	
Scenario: Depositing some money into an account
	Given a customer makes a deposit of $30.0 into his/hers account
	When checking the balance
	Then the account's balance should be $80.0

Scenario: Withdrawing some money from an account
	Given a customer makes a withdraw of $30.0 from his/hers account
	When checking the balance
	Then the account's balance should be $20.0
	
Scenario: Depositing into and withdrawing from an account
	Given a customer makes a deposit of $30.0 into his/hers account
	And  a customer makes a withdraw of $30.0 from his/hers account
	When checking the balance
    Then the account's balance should be $50.0