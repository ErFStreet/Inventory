namespace Shop.Application.Features.Base;

public abstract class BaseRequest<TKey>
    where TKey : notnull
{
    /// <summary>
    /// Id
    /// </summary>
    public TKey Id { get; set; } = default!;
}