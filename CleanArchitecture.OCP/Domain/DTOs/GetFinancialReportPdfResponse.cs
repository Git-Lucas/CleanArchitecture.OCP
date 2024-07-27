namespace CleanArchitecture.OCP.Domain.DTOs;
public record GetFinancialReportPdfResponse(string Title, FinancialReportData FinancialReportData)
{
    public int CurrentPage => new Random().Next(1, TotalPages);
    public int TotalPages =>
        FinancialReportData.FinancialTransactions.Count() % _numberRecordsPerPage != 0 ?
        FinancialReportData.FinancialTransactions.Count() / _numberRecordsPerPage + 1 :
        FinancialReportData.FinancialTransactions.Count() / _numberRecordsPerPage;

    private readonly int _numberRecordsPerPage = 4;
}
