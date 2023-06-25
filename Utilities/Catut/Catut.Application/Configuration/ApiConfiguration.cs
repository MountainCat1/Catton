namespace Catut.Application.Configuration;

public class ApiConfiguration
{
    public Dictionary<string, string> ApiUrls { get; set; }
    
    public Uri GetAddressFor(string apiName) => new(ApiUrls[apiName]);
}