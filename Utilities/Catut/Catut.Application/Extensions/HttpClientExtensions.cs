using System.Net.Http.Headers;

namespace Catut.Application.Extensions;

public static class HttpClientExtensions 
{
    public static HttpClient AddJwt(this HttpClient httpClient, string jwt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        return httpClient;
    }
}