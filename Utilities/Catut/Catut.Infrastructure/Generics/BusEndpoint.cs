using Catut.Infrastructure.Abstractions;
using MassTransit;

namespace Catut.Infrastructure.Generics;

public class BusEndpoint<TMessage> : IBusEndpoint<TMessage> 
{
    private readonly IBus _bus;
    
    public string QueueName { get; set; }

    public BusEndpoint(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendAsync(TMessage message)
    {
        var sendEndpoint = await _bus.GetSendEndpoint(new Uri($"queue:{QueueName}"));

        if (message is null)
            throw new NullReferenceException("Message was null");
        
        await sendEndpoint.Send(message);
    }
}
