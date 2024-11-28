namespace Shop.Infrastructure.Common.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, new()
    where TKey : notnull
{
    IQueryable<TEntity> Query { get; }
    IQueryable<TEntity> QueryNoTracking { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellation);
    void Delete(TKey id);
    void Update(TEntity entity);
    void SoftDelete(TEntity entity);
}