namespace Shop.Application.Common.SecurityHelper;

public class JwtSettings
{
    /// <summary>
    /// Secret key
    /// </summary>
    public string SecretKey { get; set; } = default!;

    /// <summary>
    /// Expire time
    /// </summary>
    public int ExpireTime { get; set; }

    /// <summary>
    /// Issuer
    /// </summary>
    public string Issuer { get; set; } = default!;
}