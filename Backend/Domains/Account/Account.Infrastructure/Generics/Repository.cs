using System.Linq.Expressions;
using Account.Domain.Abstractions;
using Account.Infrastructure.Errors.Database;
using Account.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Generics;

public class Repository<TEntity, TDbContext> : IRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly Func<Task> _saveChangesAsyncDelegate;
    private IMediator _mediator;
    private TDbContext _dbContext;


    public Repository(TDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _dbSet = dbContext.Set<TEntity>();

        _saveChangesAsyncDelegate = async () => { await dbContext.SaveChangesAsync(); };
    }

    public virtual async Task<TEntity?> GetOneAsync(params object[] guids)
    {
        if (guids.Length == 0)
            throw new ArgumentException("No key provided");

        var entity = await _dbSet.FindAsync(guids);

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params string[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? filter = null,
        params string[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync();
    }
    
    public async Task<TEntity> GetOneRequiredAsync(Expression<Func<TEntity, bool>>? filter = null,
        params string[] includeProperties)
    {
        var entity = await GetOneAsync(filter, includeProperties);

        if (entity == null)
            throw new ItemNotFoundException();

        return entity;
    }

    public virtual async Task<TEntity> GetOneRequiredAsync(params object[] guids)
    {
        var entity = await GetOneAsync(guids);

        if (entity == null)
            throw new ItemNotFoundException();

        return entity;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();

        return entities;
    }

    public virtual async Task DeleteAsync(params object[] keys)
    {
        var entity = await GetOneRequiredAsync(keys);

        _dbSet.Remove(entity);
    }

    public virtual Task<TEntity> CreateAsync(TEntity entity)
    {
        _dbSet.Add(entity);

        return Task.FromResult(entity);
    }

    public virtual async Task<TEntity> UpdateAsync(object update, params object[] keys)
    {
        var entity = await GetOneRequiredAsync(keys);

        _dbSet.Attach(entity).CurrentValues.SetValues(update);
        _dbSet.Attach(entity).State = EntityState.Modified;

        return entity;
    }

    public virtual async Task<Exception?> SaveChangesAsync()
    {
        try
        {
            await _mediator.DispatchDomainEventsAsync(_dbContext);
            
            await _saveChangesAsyncDelegate();
        }
        catch (DbUpdateException ex) when (ex.IsDuplicateEntryViolation())
        {
            return new DuplicateEntryException("A duplicate entry was detected.");
        }

        return null;
    }
    
    
}