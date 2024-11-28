namespace Shop.Application.Features.UserFeatures.CommandHandlers;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Result<string>>
{
    private readonly IRepository<User, Guid> _repository;

    private readonly ITokenHandler _tokenHandler;

    public LoginCommandHandler(IRepository<User, Guid> repository,
        ITokenHandler tokenHandler)
    {
        _repository = repository;

        _tokenHandler = tokenHandler;
    }

    /// <summary>
    /// Handle to response result
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<string>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository
                .QueryNoTracking
                .Include(current => current.Role)
                .Where(current => current.Phone.Equals(request.Phone))
                .Where(current => current.Password.Equals(request.Password))
                .Select(current => new UserDetailsDto
                {
                    FirstName = current.FirstName,
                    LastName = current.LastName,
                    Phone = current.Phone,
                    RoleId = current.RoleId,
                    RoleName = current.Role.Name
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                return Result<string>.NotFound(StatusMessage.NotFound);

            var token = _tokenHandler.GenerateToken(user);

            return Result<string>.Success(StatusMessage.Success, token);
        }
        catch (Exception)
        {
            return Result<string>.ServerError(StatusMessage.ServerError);
        }
    }
}