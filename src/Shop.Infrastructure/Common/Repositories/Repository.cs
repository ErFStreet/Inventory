namespace Shop.Infrastructure.Common.Repositories;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, new()
    where TKey : notnull
{
    /// <summary>
    /// dbset
    /// </summary>
    private readonly DbSet<TEntity> _entity;

    /// <summary>
    /// queryable
    /// </summary>
    public IQueryable<TEntity> Query => _entity.AsQueryable();

    /// <summary>
    /// queryable with asnotracking
    /// </summary>
    public IQueryable<TEntity> QueryNoTracking => _entity.AsQueryable()
        .AsNoTracking();

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _entity = applicationDbContext.Set<TEntity>();
    }

    /// <summary>
    /// Add Entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task AddAsync(TEntity entity, CancellationToken cancellation)
        => await _entity.AddAsync(entity, cancellation);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(TEntity entity)
        => _entity.Update(entity);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="id"></param>
    public void Delete(TKey id)
        => _entity.Remove(new TEntity { Id = id });

    /// <summary>
    /// Soft delete for entity
    /// </summary>
    /// <param name="entity"></param>
    public void SoftDelete(TEntity entity)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;

        entity.IsDeleted = true;

        _entity.Update(entity);
    }
}