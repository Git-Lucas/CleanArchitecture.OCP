using CleanArchitecture.OCP.Domain.DomainServices;
using CleanArchitecture.OCP.Domain.DTOs;
using CleanArchitecture.OCP.Domain.Entities;
using CleanArchitecture.OCP.Domain.Repositories;

namespace CleanArchitecture.OCP.Application.UseCases;
public class GetFinancialReportPdf(
    IFinancialTransactionRepository financialTransactionRepository,
    IFinancialReportGenerator financialReportGenerator)
{
    private readonly IFinancialTransactionRepository _financialTransactionRepository = financialTransactionRepository;
    private readonly IFinancialReportGenerator _financialReportGenerator = financialReportGenerator;

    public async Task<GetFinancialReportPdfResponse> ExecuteAsync(GetFinancialReportPdfRequest request)
    {
        IEnumerable<FinancialTransaction> financialTransactions = await _financialTransactionRepository.GetByPeriodAsync(request.StartPeriod, request.EndPeriod);
        
        FinancialReportData financialReportData = _financialReportGenerator.Execute(financialTransactions);

        return new GetFinancialReportPdfResponse(request.ReportTitle, financialReportData);
    }
}
