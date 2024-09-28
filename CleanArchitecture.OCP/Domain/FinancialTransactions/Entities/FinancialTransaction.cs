namespace CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;
public class FinancialTransaction
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public TypeFinancialTransaction Type { get; private set; }
    public DateTime ProcessedIn { get; private set; }

    public FinancialTransaction(string description, decimal value, TypeFinancialTransaction type, DateTime processedIn)
    {
        Description = description;
        Value = value;
        Type = type;
        ProcessedIn = processedIn;
    }

    public FinancialTransaction() { }
}
