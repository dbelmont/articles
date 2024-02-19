Feature: Logging account transactions
    As a bank account owner
    I want all my account transactions to logged
    So that I can request a statement and review them at anytime

Background:
    Given a customer opens a new Savings account with an initial deposit of $50.0
    And a customer makes a withdraw of $20.0 from an account

Rule: Every deposit and withdrawal should be logged in a list of transactions; The account's balance should be the sum of the deposited or withdrawn values of all transactions

# The DATE value is not really meaningful for the purpose of our example, so we'll skip it for the sake of brevity and clarity
Scenario: Requesting a transaction statement
    Given a customer makes a deposit of $40.0 into an account with the reference "FFR5529"
    When a transactions statement is requested
        And checking the balance
    Then the following statement should be returned to the customer
      | Date   | Value   | Reference       |
      | «DATE» | $50.00  | Initial deposit |
      | «DATE» | -$20.00 | -               |
      | «DATE» | $40.00  | FFR5529         |
    And the account's balance should be $70.0