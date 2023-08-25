using Conventions.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ConventionDomain.Application.Services;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
}


public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    private readonly TContext _context;

    protected UnitOfWork(TContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}