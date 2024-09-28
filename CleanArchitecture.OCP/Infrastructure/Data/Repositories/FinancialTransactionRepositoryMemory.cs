using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;
using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;

namespace CleanArchitecture.OCP.Infrastructure.Data.Repositories;
public class FinancialTransactionRepositoryMemory : IFinancialTransactionRepository
{
    private readonly FinancialTransaction[] _financialTransactions =
        [
            new FinancialTransaction("Salary", 5000m, TypeFinancialTransaction.Credit, new DateTime(2024, 7, 15, 8, 30, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Rent", 1500m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 16, 9, 0, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Groceries", 300m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 17, 10, 15, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Freelance Project", 1200m, TypeFinancialTransaction.Credit, new DateTime(2024, 7, 18, 11, 45, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Electricity Bill", 100m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 19, 12, 30, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Water Bill", 50m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 20, 13, 0, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Internet Bill", 70m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 21, 14, 15, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Gym Membership", 45m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 22, 15, 0, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Investment Return", 800m, TypeFinancialTransaction.Credit, new DateTime(2024, 7, 23, 16, 30, 0, DateTimeKind.Utc)),
            new FinancialTransaction("Movie Night", 30m, TypeFinancialTransaction.Debit, new DateTime(2024, 7, 24, 18, 0, 0, DateTimeKind.Utc))
        ];

    public async Task<IEnumerable<FinancialTransaction>> GetByPeriodAsync(DateOnly startPeriod, DateOnly endPeriod)
    {
        return _financialTransactions
            .Where(x => DateOnly.FromDateTime(x.ProcessedIn) >= startPeriod
                                 && DateOnly.FromDateTime(x.ProcessedIn) <= endPeriod);
    }
}
