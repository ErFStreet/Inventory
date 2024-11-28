namespace Shop.Application.Features.UserFeatures.Commands;

public class LoginCommandRequest : IRequest<Result<string>>
{
    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = default!;
}

public class LoginCommandValidation : AbstractValidator<LoginCommandRequest>
{
    /// <summary>
    /// Declare rules 
    /// </summary>
    public LoginCommandValidation()
    {
        RuleFor(current => current.Phone)
            .NotEmpty().WithMessage("Phone shouldn't be empty")
            .Length(11).WithMessage(string.Format("Phone must be {0} character", 11));

        RuleFor(current => current.Password)
            .NotEmpty().WithMessage("Password shouldn't be empty");
    }
}