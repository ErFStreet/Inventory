namespace Shop.Application.Common.DTOs;

public abstract class BaseDto<TKey> where TKey : notnull
{
    public TKey Id { get; set; } = default!;
}