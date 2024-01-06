using MassTransit;

namespace Conventions.Api.Installer;

public static class MassTransitInstaller
{
    public static IServiceCollection InstallMassTransit(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddOptions<MassTransitHostOptions>()
            .Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(2.5);
            });
        services.AddMassTransit(configurator =>
        {
            new MassTransitConfigurator().Configure(configurator, configuration);
        });

        return services;
    }
}