using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DTOs;
public record FinancialReportData(IEnumerable<FinancialTransaction> FinancialTransactions, decimal Total)
{
}
