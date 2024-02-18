﻿using BankAccount.Implementation;
using FluentAssertions;

namespace BankAccount.Steps;

[Binding]
public class BankAccountStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    
    public BankAccountStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"a customer opens a new Checking account with an initial deposit of \$(.*)")]
    public void GivenACustomerOpensANewCheckingAccountWithAnInitialDepositOf(double value)
    {
        var account = new CheckingAccount(value);
        _scenarioContext["Account"] = account;
    }

    [When(@"checking the balance")]
    public void WhenCheckingTheBalance()
    {
        var account = (Account)_scenarioContext["Account"];
        account.UpdateBalance();
    }

    [Then(@"the balance the account's balance should be \$(.*)")]
    public void ThenTheBalanceTheAccountsBalanceShouldBe(double value)
    {
        var account = (Account)_scenarioContext["Account"];
        account.Balance.Should().Be(value);
    }

    [Given(@"a customer opens a new Savings account with an initial deposit of \$(.*)")]
    public void GivenACustomerOpensANewSavingsAccountWithAnInitialDepositOf(double value)
    {
        var account = new SavingsAccount(value);
        _scenarioContext["Account"] = account;
    }
}