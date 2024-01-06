using System.Net.Http.Headers;
using System.Text;
using OpenApi.Conventions;

namespace Catton.ApiClient;

public interface IApiClient
{
    internal void AddBearer(string jwt);
}

public class ApiClient : IApiClient
{
    protected string Jwt { get; private set; }
    
    public void AddBearer(string jwt)
    {
        Jwt = jwt;
    }
    protected Task ProcessResponseAsync(HttpClient client, HttpResponseMessage response, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    protected Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder, CancellationToken cancellationToken)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
        return Task.CompletedTask;
    }

    protected Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, string urlBuilder, CancellationToken cancellationToken)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
        return Task.CompletedTask;
    }
}

public static class ApiClientExtensions
{
    public static TApiClient AddJwt<TApiClient>(this TApiClient apiClient, string jwt)
        where TApiClient : IApiClient
    {
        apiClient.AddBearer(jwt);
        
        return apiClient;
    }
}