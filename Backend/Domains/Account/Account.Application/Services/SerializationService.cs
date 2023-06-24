using System.Text.Json;

namespace Account.Service.Services;

public interface IJsonSerializer
{
    string Serialize(object obj);
    T Deserialize<T>(string json);
}

public class SystemJsonSerializer : IJsonSerializer
{
    public string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException();
    }
}