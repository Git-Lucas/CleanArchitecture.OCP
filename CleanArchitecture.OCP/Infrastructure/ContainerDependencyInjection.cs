using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
using CleanArchitecture.OCP.Infrastructure.Data.Repositories;
using CleanArchitecture.OCP.Infrastructure.SpedContabil;

namespace CleanArchitecture.OCP.Infrastructure;
public static class ContainerDependencyInjection
{
    public static IFinancialTransactionRepository FinancialTransactionRepository => new FinancialTransactionRepositoryMemory();
    public static IFinancialReportGenerator FinancialReportGenerator => new FinancialReportGeneratorLaw202401();
}
