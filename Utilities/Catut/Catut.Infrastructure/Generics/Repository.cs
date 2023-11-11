using System.Linq.Expressions;
using Catut.Domain.Abstractions;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Errors.Database;
using Catut.Infrastructure.Exception;
using Catut.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catut.Infrastructure.Generics;

public class Repository<TEntity, TDbContext> : IRepository<TEntity>
    where TEntity : Entity
    where TDbContext : DbContext
{
    protected  DbSet<TEntity> DbSet { get; }
    protected Func<Task> SaveChangesAsyncDelegate { get; }
    protected IMediator Mediator { get; }
    protected TDbContext DbContext { get; }
    protected ILogger<Repository<TEntity, TDbContext>> Logger { get; }
    private IDatabaseErrorMapper _databaseErrorMapper;


    public Repository(
        TDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<TEntity, TDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper)
    {
        DbContext = dbContext;
        Mediator = mediator;
        Logger = logger;
        _databaseErrorMapper = databaseErrorMapper;
        DbSet = dbContext.Set<TEntity>();

        SaveChangesAsyncDelegate = async () => { await dbContext.SaveChangesAsync(); };
    }

    public virtual async Task<TEntity?> GetOneAsync(params object[] guids)
    {
        if (guids.Length == 0)
            throw new ArgumentException("No key provided");

        var entity = await DbSet.FindAsync(guids);

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params string[] includeProperties)
    {
        IQueryable<TEntity> query = DbSet;

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
        IQueryable<TEntity> query = DbSet;

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
        var entities = await DbSet.ToListAsync();

        return entities;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        DbSet.Remove(entity);

        return entity;
    }

    public virtual Task<TEntity> AddAsync(TEntity entity)
    {
        DbSet.Add(entity);

        return Task.FromResult(entity);
    }

    public virtual async Task<TEntity> UpdateAsync(object update, params object[] keys)
    {
        var entity = await GetOneRequiredAsync(keys);

        DbSet.Attach(entity).CurrentValues.SetValues(update);

        return entity;
    }
    
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Attach(entity).State = EntityState.Modified;

        return entity;
    }

    public virtual async Task SaveChangesAsync()
    {
        try
        {
            await Mediator.DispatchDomainEventsAsync(DbContext);

            await SaveChangesAsyncDelegate();
        }
        catch (DbUpdateException ex) when (ex.IsDuplicateEntryViolation())
        {
            throw new DuplicateEntryException("A duplicate entry was detected.");
        }
        catch (DatabaseException ex)
        {
            Logger.LogError(ex.Message);
            throw;
        }
        finally
        {
            ClearDomainEvents();
        }
    }

    private void ClearDomainEvents()
    {
        var domainEntities = DbContext.ChangeTracker
            .Entries<Entity>()
            .Where(entry => entry.Entity.DomainEvents != null && entry.Entity.DomainEvents.Any())
            .ToArray();

        foreach (var entry in domainEntities)
            entry.Entity.ClearDomainEvents();
    }
}