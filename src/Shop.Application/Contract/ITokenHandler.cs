namespace Shop.Application.Contract;

public interface ITokenHandler
{
    string GenerateToken(UserDetailsDto userDetails);
}