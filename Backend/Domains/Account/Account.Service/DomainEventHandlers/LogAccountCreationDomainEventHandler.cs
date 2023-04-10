using Account.Domain.Abstractions;
using Account.Domain.DomainEvents;
using Microsoft.Extensions.Logging;

namespace Account.Service.DomainEventHandlers;

public class LogAccountCreationDomainEventHandler : IDomainEventHandler<CreateAccountDomainEvent>
{
    private ILogger _logger;

    public LogAccountCreationDomainEventHandler(ILogger<LogAccountCreationDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(CreateAccountDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Account created: {notification.Entity.Email}");
    }
}