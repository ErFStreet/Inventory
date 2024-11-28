namespace Shop.Domain.Entities.Authentiaction;

public class Token : BaseEntity<Guid>
{
    /// <summary>
    /// Access token -
    /// </summary>
    public string AccessToken { get; set; } = default!;

    /// <summary>
    /// Refresh token   
    /// </summary>
    public string RefreshTokne { get; set; } = default!;

    /// <summary>
    /// Access expire time
    /// </summary>
    public DateTimeOffset AccessExpireTimeUtc { get; set; } = default!;

    /// <summary>
    /// Refresh expire time
    /// </summary>
    public DateTimeOffset RefreshExpireTimeUtc { get; set; } = default!;

    /// <summary>
    /// User id
    /// </summary>
    public Guid UserId { get; set; } = default!;

    /// <summary>
    /// Current user
    /// </summary>
    public virtual User User { get; set; } = default!;
}