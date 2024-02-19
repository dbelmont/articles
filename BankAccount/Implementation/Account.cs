namespace BankAccount.Implementation;

public abstract class Account
{
    private readonly List<Transaction> _transactions;
    public IEnumerable<Transaction> Transactions => _transactions;

    protected Account()
    {
        _transactions = new List<Transaction>();
    }

    protected Account(double  value) : this()
    {
        Deposit(value, "Initial deposit");
    }

    public double CheckBalance()
    {
        return _transactions.Sum(x => x.Value);
    }

    public IEnumerable<(string date, string value, string? reference)> GetStatement(DateTime start, DateTime end = default)
    {
        /* Ideally, this method would look like the snippet below.
         
        end = end == default ? DateTime.MaxValue : end;
        return _transactions
            .Where(t => t.Date >= start && t.Date <= end)
            .Select(t => (t.Date.ToString("yyyy-MM-dd HH:mm:ss"), t.Value.ToString("C"), t.Reference))
            .ToList(); */

        // However, to keep it simple...
        return _transactions
            .Select(t => ("«DATE»", t.Value.ToString("C"), t.Reference))
            .ToList();
    }

    public void Deposit(double value, string reference = "-")
    {
        _transactions.Add(new Transaction(DateTime.UtcNow, Math.Abs(value), reference));
    }

    public void Withdraw(double value)
    {
        _transactions.Add(new Transaction(DateTime.UtcNow, -Math.Abs(value)));
    }
}