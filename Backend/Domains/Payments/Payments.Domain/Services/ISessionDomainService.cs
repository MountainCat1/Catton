using Payments.Domain.ValueObjects;

namespace Payments.Domain.Services;

public interface ISessionDomainService
{
    Task<CheckoutSessionDetails> ExpireSessionAsync(string sessionId);
    Task<CheckoutSessionDetails> CreateSessionAsync(decimal amount, string currency);
}