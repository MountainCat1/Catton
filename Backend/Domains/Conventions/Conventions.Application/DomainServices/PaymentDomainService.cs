using Conventions.Domain.Services;
using OpenApi.Payments;

namespace ConventionDomain.Application.DomainServices;

public class PaymentDomainService : IPaymentDomainService
{
    private readonly IPaymentsApi _paymentsApi;

    public PaymentDomainService(IPaymentsApi paymentsApi)
    {
        _paymentsApi = paymentsApi;
    }

    public async Task<Guid> CreatePaymentAsync(decimal amount, string currency, CancellationToken ct = default)
    {
        var createDto = new PaymentCreateDto()
        {
            Amount = (double)amount,
            Currency = currency
        };
        
        var payment = await _paymentsApi.PaymentsPOSTAsync(createDto, ct);

        return payment.Id;
    }
}
