using MassTransit;
using Payments.Application.Messages;

namespace Payments.Api.Installers;

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
            cfg.ConfigureEndpoints(context);
                
            cfg.Message<PaymentUpdatedMessage>(x =>
            {
                x.SetEntityName("payment_payment-updated");
            });
        });
    }
}