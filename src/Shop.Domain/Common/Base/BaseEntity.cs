namespace Shop.Domain.Common.Base;

public abstract class BaseEntity<TKey> : IEntity
    where TKey : notnull
{
    /// <summary>
    /// Id
    /// </summary>
    public TKey Id { get; set; } = default!;

    /// <summary>
    /// The time created entity
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// The time updated entity
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Is deleted
    /// </summary>
    public bool IsDeleted { get; set; }
}