Feature: Account Maintenance
	As the banker
	I want the maintenance process to be run
	So that the accounts have fees or interest applied to them
	
Rule: The maintenance event applies fees or interests to the accounts; Checking accounts have a fixed service fee; Savings accounts receive interest
	
Scenario: Running maintenance process over Savings account
	Given a customer opens a new Savings account with an initial deposit of $50.0
	When the maintenance process runs
	And checking the balance
	Then the account's balance should be $50.25
	
Scenario: Running maintenance process over Checking account
	Given a customer opens a new Checking account with an initial deposit of $50.0
	When the maintenance process runs
	And checking the balance
	Then the account's balance should be $40.0