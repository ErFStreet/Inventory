namespace Shop.Application.Features.UserFeatures.Commands;

public class DeleteProductCommandRequest :
    BaseRequest<Guid>, IRequest<Result>
{ }

public class DeleteCommandRequestValidation :
    AbstractValidator<DeleteProductCommandRequest>
{
    /// <summary>
    /// Decalre rules
    /// </summary>
    public DeleteCommandRequestValidation()
    {
        RuleFor(current => current.Id)
            .NotNull().WithMessage("Id must not be null or 0");
    }
}