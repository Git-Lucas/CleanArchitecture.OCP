using CleanArchitecture.OCP.Application.UseCases;
using CleanArchitecture.OCP.Domain.FinancialTransactions.Repositories;
using CleanArchitecture.OCP.Domain.FinancialTransactions.SpedContabil;
using CleanArchitecture.OCP.Domain.Utils;
using CleanArchitecture.OCP.Infrastructure.Data.Repositories;
using CleanArchitecture.OCP.Infrastructure.SpedContabil;

//DependencyInjection
IFinancialTransactionRepository repository = new FinancialTransactionRepositoryMemory();
IFinancialReportGenerator generatorSpedContabil = new FinancialReportGeneratorLaw202401();

GetFinancialReportWeb webUseCase = new(repository, generatorSpedContabil);
GetFinancialReportRequest genericRequest = new(
    StartPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 1),
    EndPeriod: new DateOnly(
        year: 2024,
        month: 7,
        day: 31));
GetFinancialReportWebResponse webResponse = await webUseCase.ExecuteAsync(genericRequest);

GetFinancialReportPdf pdfUseCase = new(repository, generatorSpedContabil);
GetFinancialReportPdfRequest pdfRequest = new(
    ReportTitle: $"{nameof(CleanArchitecture)} Financial Report Month {genericRequest.StartPeriod.Month}",
    StartPeriod: genericRequest.StartPeriod,
    EndPeriod: genericRequest.EndPeriod);
GetFinancialReportPdfResponse pdfResponse = await pdfUseCase.ExecuteAsync(pdfRequest);

Console.WriteLine(Serializer.Serialize(webResponse));
Console.WriteLine("-------------------------------------");
Console.WriteLine(Serializer.Serialize(pdfResponse));
