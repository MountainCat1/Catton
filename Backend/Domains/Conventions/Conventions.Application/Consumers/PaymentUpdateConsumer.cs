using ConventionDomain.Application.Features.TicketFeature;
using ConventionDomain.Application.Services;
using MassTransit;
using OpenApi.Payments;

namespace ConventionDomain.Application.Consumers;

public class PaymentUpdatedMessage
{
    public Guid Id { get; set; }
    public PaymentDto Dto { get; set; }
}

public class PaymentUpdateConsumer : IConsumer<PaymentUpdatedMessage>
{
    private IConventionCommandMediator _commandMediator;

    public PaymentUpdateConsumer(IConventionCommandMediator commandMediator)
    {
        _commandMediator = commandMediator;
    }

    public async Task Consume(ConsumeContext<PaymentUpdatedMessage> context)
    {
        Console.WriteLine("Consumed message from PaymentUpdatedMessage");
        // TODO: Implement, do something, whatever pleaaaase
    }
}