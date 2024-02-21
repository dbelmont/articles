namespace BankAccount.Implementation;

public class SavingsAccount : Account
{
    public double InterestRate => 0.005;
    public SavingsAccount(double value) : base(value) {}
    public override void RunMaintenance()
    {
        var newBalance = CheckBalance() * InterestRate;
        Deposit(newBalance, "Applying interest");
    }
}