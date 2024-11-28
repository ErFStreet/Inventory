namespace Shop.Application.Features.UserFeatures.CommandHandlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, Result<Guid>>
{
    private readonly IRepository<Product, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public AddProductCommandHandler(IRepository<Product, Guid> repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handle to response result
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<Guid>> Handle(AddProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var product = new ProductBuilder()
                 .WithTitle(request.Title)
                 .WithDescription(request.Description)
                 .WithPrice(request.Price)
                 .WithDiscount(request.Discount)
                 .WithTax(request.Tax)
                 .WithAuthor(request.UserId)
                 .Build();

            if (product is null)
                return Result<Guid>.ServerError(StatusMessage.ServerError);

            await _repository.AddAsync(product, cancellationToken);

            var result =
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result == 0)
                return Result<Guid>.ServerError(StatusMessage.ServerError);

            return Result<Guid>.Success(StatusMessage.Added, product.Id);

        }
        catch (Exception)
        {
            return Result<Guid>.ServerError(StatusMessage.ServerError);
        }
    }
}