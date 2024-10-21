using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil.DomainServices;
using static CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil.DomainServices.GenerateFinancialReport;

namespace CleanArchitecture.OCP.Application.UseCases;
public class GetFinancialReportPdf(
    IFinancialTransactionRepository financialTransactionRepository,
    IFinancialReportGenerator financialReportGenerator)
{
    private readonly IFinancialTransactionRepository _financialTransactionRepository = financialTransactionRepository;
    private readonly IFinancialReportGenerator _financialReportGenerator = financialReportGenerator;
    private readonly GenerateFinancialReport _generateFinancialReport = new();

    public async Task<GetFinancialReportPdfResponse> ExecuteAsync(GetFinancialReportPdfRequest request)
    {
        FinancialReportData financialReportData = await _generateFinancialReport.ExecuteAsync(_financialTransactionRepository,
                                                                                              _financialReportGenerator,
                                                                                              new(request.StartPeriod, request.EndPeriod));

        return new GetFinancialReportPdfResponse(request.ReportTitle, financialReportData);
    }
}

public record GetFinancialReportPdfRequest(string ReportTitle, DateOnly StartPeriod, DateOnly EndPeriod)
    : GenerateFinancialReportRequest(StartPeriod, EndPeriod)
{
}

public record GetFinancialReportPdfResponse(string Title, FinancialReportData FinancialReportData)
{
    public int CurrentPage => new Random().Next(1, TotalPages);
    public int TotalPages =>
        FinancialReportData.FinancialTransactions.Count() % _numberRecordsPerPage != 0 ?
        FinancialReportData.FinancialTransactions.Count() / _numberRecordsPerPage + 1 :
        FinancialReportData.FinancialTransactions.Count() / _numberRecordsPerPage;

    private readonly int _numberRecordsPerPage = 4;
}
