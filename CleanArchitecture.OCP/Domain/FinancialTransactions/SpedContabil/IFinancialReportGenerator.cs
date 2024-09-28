using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;

namespace CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
public interface IFinancialReportGenerator
{
    FinancialReportData Execute(IEnumerable<FinancialTransaction> financialTransactions);
}
