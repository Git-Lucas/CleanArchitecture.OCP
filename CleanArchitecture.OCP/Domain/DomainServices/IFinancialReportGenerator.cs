using CleanArchitecture.OCP.Domain.DTOs;
using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DomainServices;
public interface IFinancialReportGenerator
{
    FinancialReportData Execute(IEnumerable<FinancialTransaction> financialTransactions);
}
