namespace CleanArchitecture.OCP.Domain.DTOs;
public record GetFinancialReportPdfRequest(string ReportTitle, DateOnly StartPeriod, DateOnly EndPeriod) 
    : GetFinancialReportRequest(StartPeriod, EndPeriod)
{
}
