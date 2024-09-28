using System.Text.Json.Serialization;

namespace CleanArchitecture.OCP.Domain.FinancialTransactions.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TypeFinancialTransaction
{
    Credit,
    Debit
}
