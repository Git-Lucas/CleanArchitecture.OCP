using CleanArchitecture.OCP.Domain.Entities;

namespace CleanArchitecture.OCP.Domain.Repositories;
public interface IFinancialTransactionRepository
{
    Task<IEnumerable<FinancialTransaction>> GetByPeriodAsync(DateOnly init, DateOnly final);
}
