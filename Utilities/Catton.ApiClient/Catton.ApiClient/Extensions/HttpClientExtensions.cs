using System.Net.Http;
using System.Net.Http.Headers;

namespace Catton.ApiClient.Extensions;

public static class HttpClientExtensions 
{
    public static HttpClient AddJwt(this HttpClient httpClient, string jwt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        return httpClient;
    }
}