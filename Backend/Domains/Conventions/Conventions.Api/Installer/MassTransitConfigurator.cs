using ConventionDomain.Application.Consumers;
using MassTransit;

namespace Conventions.Api.Installer;

public class MassTransitConfigurator
{


    public void Configure(IBusRegistrationConfigurator configurator, ConfigurationManager configuration)
    {
        // configurator.AddConsumer<BusConsumer>();
    
        // Configure Azure Service Bus
        configurator.UsingAzureServiceBus((context, cfg) =>
        {
            cfg.Host(configuration.GetConnectionString("ServiceBus")); 
            // cfg.ReceiveEndpoint("some-queue", endpointConfigurator =>
            // {
            //     endpointConfigurator.ConfigureConsumer<MyBusConsumer>(context);
            // });
            cfg.SubscriptionEndpoint(
                "conventions_payment_payment-updated",
                "payment_payment-updated",
                e =>
                {
                    e.ConfigureConsumer<PaymentUpdateConsumer>(context);
                });
            cfg.ConfigureEndpoints(context);
        });

    }
}