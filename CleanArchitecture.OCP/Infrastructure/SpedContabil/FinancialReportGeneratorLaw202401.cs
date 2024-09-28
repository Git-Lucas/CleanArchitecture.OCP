using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;

namespace CleanArchitecture.OCP.Infrastructure.SpedContabil;
public class FinancialReportGeneratorLaw202401 : IFinancialReportGenerator
{
    private readonly decimal _federalTaxPercentage = 0.03m;

    public FinancialReportData Execute(IEnumerable<FinancialTransaction> financialTransactions)
    {
        decimal total = CalculateTotal(financialTransactions);

        return new FinancialReportData(financialTransactions, total);
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

        decimal liquid = credits - debits;
        decimal federalTaxDiscounted = liquid * (1 - _federalTaxPercentage);

        return federalTaxDiscounted;
    }
}
