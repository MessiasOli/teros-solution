using System.Text.Json;

namespace TEROS.Domain.Utils;

public static class RequestSerializeExtensions
{
    public static string SerializeJsonObject(this object value)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        return JsonSerializer.Serialize(value, options);
    }
}
