namespace BankAccount.Implementation;

public class CheckingAccount : Account
{
    public double MaintenanceFee => 10;
    public CheckingAccount(double value) : base(value) {}
    public override void RunMaintenance()
    {
        Withdraw(MaintenanceFee, "Maintenance fee");
    }
}