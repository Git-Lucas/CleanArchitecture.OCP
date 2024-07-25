using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.DomainServices;
public class FinancialReportGeneratorLaw202401 : IFinancialReportGenerator
{
    public FinancialReport Execute(IEnumerable<FinancialTransaction> financialTransactions)
    {
        decimal total = CalculateTotal(financialTransactions);

        return new FinancialReport(financialTransactions, total);
    }

    private decimal CalculateTotal(IEnumerable<FinancialTransaction> financialTransactions)
    {
        decimal credits = financialTransactions
                    .Where(x => x.Type == TypeFinancialTransaction.Credit)
                    .Select(x => x.Value)
                    .Sum();
        decimal debits = financialTransactions
            .Where(x => x.Type == TypeFinancialTransaction.Debit)
            .Select(x => x.Value)
            .Sum();

        return credits - debits;
    }
}
