using Payments.Domain.Services;
using Payments.Domain.ValueObjects;
using Stripe.Checkout;

namespace Payments.Application.Services.Domain;

public class SessionDomainService : ISessionDomainService
{
    private readonly IPaymentService _paymentService;

    public SessionDomainService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<SessionDetails> ExpireSessionAsync(string sessionId)
    {
        var session = await _paymentService.ExpireSessionAsync(sessionId);
        return ToSessionDetails(session);
    }

    public async Task<SessionDetails> CreateSessionAsync(decimal amount, string currency)
    {
        var session = await _paymentService.CreateSessionAsync(amount, currency);

        return ToSessionDetails(session);
    }

    private static SessionDetails ToSessionDetails(Session session)
    {
        return new SessionDetails()
        {
            Id = session.Id,
            Url = session.Url,
            ExpiresAt = session.ExpiresAt
        };
    }
}