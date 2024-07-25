using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DomainServices;
public interface IFinancialReportGenerator
{
    FinancialReport Execute(IEnumerable<FinancialTransaction> financialTransactions);
}
