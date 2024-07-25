using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DomainServices;
public class FinancialReport(IEnumerable<FinancialTransaction> financialTransactions, decimal total)
{
    public IEnumerable<FinancialTransaction> FinancialTransactions { get; } = financialTransactions;
    public decimal Total { get; } = total;
}
