using Catut.Domain.Abstractions;
using Payments.Domain.Entities;

namespace Payments.Domain.Repositories;

public interface IPaymentRepository : IRepository<Payment>
{
    
}