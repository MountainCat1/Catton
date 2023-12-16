using Payments.Domain.ValueObjects;

namespace Payments.Domain.Services;

public interface ISessionDomainService
{
    Task<SessionDetails> ExpireSessionAsync(string sessionId);
    Task<SessionDetails> CreateSessionAsync(decimal amount, string currency);
}