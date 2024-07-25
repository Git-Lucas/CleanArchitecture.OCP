using System.Text.Json;

namespace CleanArchitecture.OCP.Domain.Utils;
public static class Serializer
{
    private static JsonSerializerOptions Options => new()
    {
        WriteIndented = true
    };

    public static string Serialize<T>(T value)
    {
        return JsonSerializer.Serialize(value, Options);
    }
}
