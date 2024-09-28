using CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;

namespace CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;
public interface IFinancialTransactionRepository
{
    Task<IEnumerable<FinancialTransaction>> GetByPeriodAsync(DateOnly startPeriod, DateOnly endPeriod);
}
