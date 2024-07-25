using System.Text.Json.Serialization;

namespace CleanArchitecture.OCP.Domain.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TypeFinancialTransaction
{
    Credit,
    Debit
}
