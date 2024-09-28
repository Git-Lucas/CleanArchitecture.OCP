using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;

namespace CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
public record FinancialReportData(IEnumerable<FinancialTransaction> FinancialTransactions, decimal Total)
{
}
