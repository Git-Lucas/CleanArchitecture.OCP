namespace CleanArchitecture.OCP.Domain.DTOs;
public record GetFinancialReportWebResponse(FinancialReportData FinancialReportData)
{
    public int NumberTransactions => FinancialReportData.FinancialTransactions.Count();
}
