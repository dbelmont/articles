namespace BankAccount.Implementation;

public enum TransactionType
{
    Deposit,
    Withdraw
}

public record struct Transaction
{
    public DateTime Date { get; }
    public double Value { get; }
    public string? Reference { get; }
    public TransactionType Type => Value > 0 ? TransactionType.Deposit : TransactionType.Withdraw;
    
    public Transaction(DateTime date, double value, string reference = "-")
    {
        Date = date;
        Value = value;
        Reference = reference ?? throw new ArgumentNullException(nameof(reference));
    }
}
