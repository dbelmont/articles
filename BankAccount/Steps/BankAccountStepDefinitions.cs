using BankAccount.Implementation;
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
        _scenarioContext["Balance"] = account.CheckBalance();
    }

    [Then(@"the account's balance should be \$(.*)")]
    public void ThenTheAccountsBalanceShouldBe(double value)
    {
        _scenarioContext["Balance"].Should().Be(value);
    }

    [Given(@"a customer opens a new Savings account with an initial deposit of \$(.*)")]
    public void GivenACustomerOpensANewSavingsAccountWithAnInitialDepositOf(double value)
    {
        var account = new SavingsAccount(value);
        _scenarioContext["Account"] = account;
    }

    [Given(@"a customer makes a deposit of \$(.*) into an account")]
    public void GivenACustomerMakesADepositOfIntoHisHersAccount(double value)
    {
        var account = (Account)_scenarioContext["Account"];
        account.Deposit(value);
    }
    [Given(@"a customer makes a deposit of \$(.*) into an account with the reference ""(.*)""")]
    public void GivenACustomerMakesADepositOfIntoHisHersAccountWithReference(double value, string reference)
    {
        var account = (Account)_scenarioContext["Account"];
        account.Deposit(value, reference);
    }

    [Given(@"a customer makes a withdraw of \$(.*) from an account")]
    public void GivenACustomerMakesAWithdrawOfFromHisHersAccount(double value)
    {
        var account = (Account)_scenarioContext["Account"];
        account.Withdraw(value);
    }

    [When(@"a transactions statement is requested")]
    public void WhenATransactionsStatementIsRequested()
    {
        var account = (Account)_scenarioContext["Account"];
        _scenarioContext["Transactions"] = account.GetStatement(DateTime.Now) ?? Array.Empty<(string, string, string?)>();
    }

    [Then(@"the following statement should be returned to the customer")]
    public void ThenTheFollowingStatementShouldBeReturnedToTheCustomer(Table table)
    {
        var transactions = (_scenarioContext["Transactions"] as IEnumerable<(string Date, string Value, string? Reference)>).ToList();
        transactions.Should().HaveCount(table.RowCount);
        
        foreach (var row in table.Rows)
        {
            var transaction = transactions.First();
            row["Date"].Should().Be(transaction.Date);
            row["Value"].Should().Be(transaction.Value);
            row["Reference"].Should().Be(transaction.Reference);
            transactions.Remove(transaction);
        }
    }
}