using System.Text.Json.Serialization;

namespace Catut.Application.Dtos;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public ErrorContent? Content { get; set; }
}

public class ErrorContent
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}