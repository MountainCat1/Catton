namespace Conventions.Domain.Services;

public interface IPaymentDomainService
{
    Task<Guid> CreatePaymentAsync(decimal amount, string currency, CancellationToken ct = default);
}
