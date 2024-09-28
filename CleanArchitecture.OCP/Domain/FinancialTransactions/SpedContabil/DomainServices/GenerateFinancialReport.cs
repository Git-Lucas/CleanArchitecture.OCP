using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;
using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;

namespace CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil.DomainServices;
public class GenerateFinancialReport
{
    public async Task<FinancialReportData> ExecuteAsync(
        IFinancialTransactionRepository financialTransactionRepository, 
        IFinancialReportGenerator financialReportGenerator,
        GenerateFinancialReportRequest request)
    {
        IEnumerable<FinancialTransaction> financialTransactions = await financialTransactionRepository.GetByPeriodAsync(request.StartPeriod, request.EndPeriod);

        FinancialReportData financialReportData = financialReportGenerator.Execute(financialTransactions);

        return financialReportData;
    }

    public record GenerateFinancialReportRequest(DateOnly StartPeriod, DateOnly EndPeriod)
    {
    }
}
