namespace Shop.Application.Features.UserFeatures.Commands;

public class GetProductByIdQueryRequest :
    BaseRequest<Guid>, IRequest<Result<ProductDto>>
{ }

public class GetProductByIdQueryRequestValidation :
    AbstractValidator<GetProductByIdQueryRequest>
{
    /// <summary>
    /// Decalre rules
    /// </summary>
    public GetProductByIdQueryRequestValidation()
    {
        RuleFor(current => current.Id)
            .NotNull().WithMessage("Id must not be null or 0");
    }
}