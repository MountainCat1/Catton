using Accounts.Domain.DomainEvents;
using Catut.Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Accounts.Service.DomainEventHandlers;

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