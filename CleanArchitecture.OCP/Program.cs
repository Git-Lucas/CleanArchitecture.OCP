using CleanArchitecture.OCP.Application.UseCases;
using CleanArchitecture.OCP.Domain.DomainServices;
using CleanArchitecture.OCP.Domain.DTOs;
using CleanArchitecture.OCP.Domain.Repositories;
using CleanArchitecture.OCP.Domain.Utils;
using CleanArchitecture.OCP.Infrastructure.Data.Repositories;

//DependencyInjection
IFinancialTransactionRepository repository = new FinancialTransactionRepositoryMemory();
IFinancialReportGenerator generatorDomainService = new FinancialReportGeneratorLaw202401();

GetFinancialReportRequest genericRequest = new(
    StartPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 1),
    EndPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 31));
GetFinancialReportPdfRequest pdfRequest = new(
    ReportTitle: $"{nameof(CleanArchitecture)} Financial Report Month {genericRequest.StartPeriod.Month}",
    StartPeriod: genericRequest.StartPeriod,
    EndPeriod: genericRequest.EndPeriod);

GetFinancialReportWeb getFinancialReportWeb = new(repository, generatorDomainService);
GetFinancialReportWebResponse webResponse = await getFinancialReportWeb.ExecuteAsync(genericRequest);

GetFinancialReportPdf getFinancialReportPdf = new(repository, generatorDomainService);
GetFinancialReportPdfResponse pdfResponse = await getFinancialReportPdf.ExecuteAsync(pdfRequest);

Console.WriteLine(Serializer.Serialize(webResponse));
Console.WriteLine("-------------------------------------");
Console.WriteLine(Serializer.Serialize(pdfResponse));
