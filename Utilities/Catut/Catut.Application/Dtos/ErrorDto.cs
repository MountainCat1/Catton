using System.Text.Json.Serialization;

namespace Catut.Application.Dtos;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Error { get; set; }
    public string? Message { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string> Errors { get; set; }
}