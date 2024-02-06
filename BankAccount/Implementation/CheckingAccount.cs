namespace BankAccount.Implementation;

public class CheckingAccount
{
    public CheckingAccount(double value)
    {
        Balance = value;
    }

    public double Balance { get; private set; }

    public void UpdateBalance()
    {
        //nothing for the time being...
    }
}