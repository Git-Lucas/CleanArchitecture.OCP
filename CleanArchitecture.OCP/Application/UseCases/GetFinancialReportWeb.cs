using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil.DomainServices;

namespace CleanArchitecture.OCP.Application.UseCases;
public class GetFinancialReportWeb(
    IFinancialTransactionRepository financialTransactionRepository,
    IFinancialReportGenerator financialReportGenerator)
{
    private readonly IFinancialTransactionRepository _financialTransactionRepository = financialTransactionRepository;
    private readonly IFinancialReportGenerator _financialReportGenerator = financialReportGenerator;
    private readonly GenerateFinancialReport _generateFinancialReport = new();

    public async Task<GetFinancialReportWebResponse> ExecuteAsync(GetFinancialReportRequest request)
    {
        FinancialReportData financialReportData = await _generateFinancialReport.ExecuteAsync(_financialTransactionRepository,
                                                                                              _financialReportGenerator,
                                                                                              new(request.StartPeriod, request.EndPeriod));

        return new GetFinancialReportWebResponse(financialReportData);
    }
}

public record GetFinancialReportRequest(DateOnly StartPeriod, DateOnly EndPeriod)
{
}

public record GetFinancialReportWebResponse(FinancialReportData FinancialReportData)
{
    public int NumberTransactions => FinancialReportData.FinancialTransactions.Count();
}
