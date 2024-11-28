namespace Shop.Application.Features.UserFeatures.Commands;

public class UpdateProductCommandRequest : BaseRequest<Guid>, IRequest<Result>
{
    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Discount
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Tax
    /// </summary>
    public int Tax { get; set; }

    /// <summary>
    /// User id
    /// </summary>
    public Guid UserId { get; set; }
}

public class UpdateCommandRequestValidation : AbstractValidator<UpdateProductCommandRequest>
{
    /// <summary>
    /// Declare rules
    /// </summary>
    public UpdateCommandRequestValidation()
    {
        RuleFor(current => current.Title)
            .NotEmpty().WithMessage("Phone shouldn't be empty")
            .Length(11).WithMessage(string.Format("Phone must be {0} character", 11));

        RuleFor(current => current.Description)
            .NotEmpty().WithMessage("Description shouldn't be empty");

        RuleFor(current => current.Price)
            .NotEmpty();

        RuleFor(current => current.Discount)
            .NotEmpty();

        RuleFor(current => current.Tax)
            .NotEmpty();

        RuleFor(current => current.Id)
            .NotNull().WithMessage("Id must not be null or 0");
    }
}