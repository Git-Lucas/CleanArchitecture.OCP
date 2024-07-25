namespace CleanArchitecture.OCP.Domain.DTOs;
public record GetFinancialReportRequest(DateOnly StartPeriod, DateOnly EndPeriod)
{
}
