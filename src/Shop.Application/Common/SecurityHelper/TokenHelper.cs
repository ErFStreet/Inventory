namespace Shop.Application.Common.SecurityHelper;

public class TokenHandler : ITokenHandler
{
    private readonly JwtSettings _settings;

    public TokenHandler(IOptions<JwtSettings> options)
    {
        _settings = options.Value;
    }

    /// <summary>
    /// Generate token
    /// </summary>
    /// <param name="userDetails"></param>
    /// <returns></returns>
    public string GenerateToken(UserDetailsDto userDetails)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_settings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier ,userDetails.Id.ToString()),
            new Claim(ClaimTypes.MobilePhone,userDetails.Phone),
            new Claim(ClaimTypes.Role , userDetails!.RoleName!),
            new Claim(ClaimTypes.Name ,$"{userDetails.FirstName} {userDetails.LastName}"),
            new Claim(nameof(userDetails.RoleId),userDetails.RoleId.ToString()!)
        }),

            Expires = DateTime.UtcNow.AddHours(_settings.ExpireTime),

            SigningCredentials =
            new SigningCredentials
            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}