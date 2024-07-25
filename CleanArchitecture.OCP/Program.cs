using CleanArchitecture.OCP.Application.UseCases;
using CleanArchitecture.OCP.Domain.DomainServices;
using CleanArchitecture.OCP.Domain.DTOs;
using CleanArchitecture.OCP.Domain.Repositories;
using CleanArchitecture.OCP.Domain.Utils;
using CleanArchitecture.OCP.Infrastructure.Data.Repositories;

//DependencyInjection
IFinancialTransactionRepository repository = new FinancialTransactionRepositoryMemory();
IFinancialReportGenerator generatorDomainService = new FinancialReportGeneratorLaw202401();

GetFinancialReportRequest request = new(
    StartPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 1),
    EndPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 31));

GetFinancialReportWeb getFinancialReportWeb = new(repository, generatorDomainService);
GetFinancialReportWebResponse webResponse = await getFinancialReportWeb.ExecuteAsync(request);

Console.WriteLine(Serializer.Serialize(webResponse));
