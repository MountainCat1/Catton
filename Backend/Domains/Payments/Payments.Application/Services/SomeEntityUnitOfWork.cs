using Payments.Infrastructure.Contexts;
using Catut.Application.Abstractions;

namespace Payments.Application.Services;

// TODO: Replace placeholder
public interface ISomeEntityUnitOfWork : IUnitOfWork<PaymentsDbContext>
{
}

public class SomeEntityUnitOfWork : UnitOfWork<PaymentsDbContext>, ISomeEntityUnitOfWork
{
    public SomeEntityUnitOfWork(PaymentsDbContext context) : base(context)
    {
    }
}

