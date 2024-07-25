using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DomainServices;
public class FinancialReport(IEnumerable<FinancialTransaction> financialTransactions, int total)
{
    public IEnumerable<FinancialTransaction> FinancialTransactions { get; } = financialTransactions;
    public int Total { get; } = total;
}
