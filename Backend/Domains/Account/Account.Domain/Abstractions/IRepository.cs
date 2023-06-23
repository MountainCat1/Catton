﻿using System.Linq.Expressions;

namespace Account.Domain.Abstractions;


public interface IRepository
{
    
}
public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    public Task<TEntity> UpdateAsync(object update, params object[] keys);
    public Task<TEntity> GetOneRequiredAsync(params object[] keys);
    Task<TEntity> GetOneRequiredAsync(Expression<Func<TEntity, bool>>? filter = null,
        params string[] includeProperties);
    public Task<TEntity?> GetOneAsync(params object[] keys);
    public Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity> DeleteAsync(TEntity entity);
    public Task<TEntity> AddAsync(TEntity entity);
    
    Task SaveChangesAsync();
}