using System.Text.Json.Serialization;

namespace Account.Service.Dtos;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public ErrorContent? ErrorContent { get; set; }
}

public class ErrorContent
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}