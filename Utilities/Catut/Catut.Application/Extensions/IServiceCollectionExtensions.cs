using System.Collections.Specialized;
using Catut.Application.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Catut.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services,
        ApiConfiguration apiConfiguration,
        string clientName,
        Action<HttpClient> configureClient = null)
    
        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        if (clientName is null)
            throw new NullReferenceException("Problem with retreiving a name for a http client");

        services.AddHttpClient<TClientInterface, TClientImplementation>(x =>
        {
            x.BaseAddress = apiConfiguration.GetAddressFor(clientName);

            configureClient?.Invoke(x);
        });

        return services;
    }

    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services,
        string clientName,
        Action<HttpClient> configureClient)
    
        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        var serviceProvider = services.BuildServiceProvider();

        var apiConfiguration = serviceProvider.GetService<IOptions<ApiConfiguration>>()?.Value;
        if (apiConfiguration is null)
            throw new NullReferenceException(
                $"The {nameof(apiConfiguration)} has not been configured in ${nameof(IServiceCollection)}");

        services.AddHttpClient<TClientInterface, TClientImplementation>(x =>
        {
            x.BaseAddress = apiConfiguration.GetAddressFor(clientName);

            configureClient?.Invoke(x);
        });

        return services;
    }
    
    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services)

        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        var clientName = GetApiName<TClientInterface>();
        
        return services.AddApiHttpClinet<TClientInterface, TClientImplementation>(clientName, null);
    }

    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services,
        string clientName)

        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        return services.AddApiHttpClinet<TClientInterface, TClientImplementation>(clientName, null);
    }

    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services,
        Action<HttpClient> configureClient)
        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        var clientName = GetApiName<TClientInterface>();

        return services.AddApiHttpClinet<TClientInterface, TClientImplementation>(clientName, configureClient);
    }
    
    public static IServiceCollection AddApiHttpClinet<TClientInterface, TClientImplementation>(
        this IServiceCollection services,
        ApiConfiguration apiConfiguration)
        where TClientImplementation : class, TClientInterface
        where TClientInterface : class
    {
        var clientName = GetApiName<TClientInterface>();

        return services.AddApiHttpClinet<TClientInterface, TClientImplementation>(apiConfiguration, clientName);
    }

    private static string GetApiName<T>()
    {
        var clientName = typeof(T).Name;
        
        if (clientName is null)
            throw new NullReferenceException("Problem with retreiving a name for a http client");
        
        if (clientName.First() == 'I')
            clientName = new string(clientName.Skip(1).ToArray());// Skip the 'I' of the interface 
        
        if (clientName is null)
            throw new NullReferenceException("Problem with retreiving a name for a http client");

        return clientName;
    }
}