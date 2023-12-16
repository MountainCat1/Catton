using Payments.Infrastructure.Contexts;
using Catut.Application.Abstractions;

namespace Payments.Application.Services;

public interface IPaymentUnitOfWork : IUnitOfWork<PaymentsDbContext>
{
}

public class PaymentUnitOfWork : UnitOfWork<PaymentsDbContext>, IPaymentUnitOfWork
{
    public PaymentUnitOfWork(PaymentsDbContext context) : base(context)
    {
    }
}

