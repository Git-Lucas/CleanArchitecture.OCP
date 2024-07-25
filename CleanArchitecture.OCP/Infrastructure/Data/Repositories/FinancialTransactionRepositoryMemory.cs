using CleanArchitecture.OCP.Domain.Entities;
using CleanArchitecture.OCP.Domain.Repositories;

namespace CleanArchitecture.OCP.Infrastructure.Data.Repositories;
public class FinancialTransactionRepositoryMemory : IFinancialTransactionRepository
{
    private readonly FinancialTransaction[] _financialTransactions =
        [
            new FinancialTransaction("Salary", 5000m, TypeFinancialTransaction.Credit, DateTime.Now.AddDays(-10)),
            new FinancialTransaction("Rent", 1500m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-9)),
            new FinancialTransaction("Groceries", 300m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-8)),
            new FinancialTransaction("Freelance Project", 1200m, TypeFinancialTransaction.Credit, DateTime.Now.AddDays(-7)),
            new FinancialTransaction("Electricity Bill", 100m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-6)),
            new FinancialTransaction("Water Bill", 50m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-5)),
            new FinancialTransaction("Internet Bill", 70m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-4)),
            new FinancialTransaction("Gym Membership", 45m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-3)),
            new FinancialTransaction("Investment Return", 800m, TypeFinancialTransaction.Credit, DateTime.Now.AddDays(-2)),
            new FinancialTransaction("Movie Night", 30m, TypeFinancialTransaction.Debit, DateTime.Now.AddDays(-1))
        ];

    public async Task<IEnumerable<FinancialTransaction>> GetByPeriodAsync(DateOnly init, DateOnly final)
    {
        return _financialTransactions
            .Where(x => DateOnly.FromDateTime(x.ProcessedIn) >= init 
                                 && DateOnly.FromDateTime(x.ProcessedIn) <= final);
    }
}
