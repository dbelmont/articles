namespace BankAccount.Implementation;

public abstract class Account
{
    protected Account() {}

    protected Account(double  value)
    {
        Balance = value;
    }

    public double Balance { get; private set; }
    
    public void UpdateBalance()
    {
        //nothing for the time being...
    }
}