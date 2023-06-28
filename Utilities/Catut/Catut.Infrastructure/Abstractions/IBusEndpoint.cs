namespace Catut.Infrastructure.Abstractions;

public interface IBusEndpoint<TMessage>
{
    public Task SendAsync(TMessage message);
}