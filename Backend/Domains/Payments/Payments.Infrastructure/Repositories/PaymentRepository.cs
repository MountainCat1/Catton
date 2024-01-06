using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Payments.Infrastructure.Contexts;

namespace Payments.Infrastructure.Repositories;

public class PaymentRepository : Repository<Payment, PaymentsDbContext>, IPaymentRepository
{
    public PaymentRepository(
        PaymentsDbContext dbContext, IMediator mediator, 
        ILogger<Repository<Payment, PaymentsDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}