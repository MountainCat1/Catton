using Conventions.Infrastructure.Contexts;

namespace ConventionDomain.Application.Services;

public interface IConvenitonUnitOfWork : IUnitOfWork<ConventionDomainDbContext>
{
}

public class ConventionDomainUnitOfWork : UnitOfWork<ConventionDomainDbContext>, IConvenitonUnitOfWork
{
    public ConventionDomainUnitOfWork(ConventionDomainDbContext context) : base(context)
    {
    }
}

