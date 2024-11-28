namespace Shop.Application.Features.UserFeatures.CommandHandlers;

public class UpdateProductCommandHandler :
    IRequestHandler<UpdateProductCommandRequest, Result>
{
    private readonly IRepository<Product, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IRepository<Product, Guid> repository,
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
    public async Task<Result> Handle(UpdateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (!await _repository.Query.AnyAsync(current =>
                current.Id.Equals(
                request.Id), cancellationToken))
                return Result.NotFound(StatusMessage.NotFound);

            var product = new ProductBuilder()
                .WithId(request.Id)
                .WithTitle(request.Title)
                .WithDescription(request.Description)
                .WithPrice(request.Price)
                .WithDiscount(request.Discount)
                .WithTax(request.Tax)
                .WithAuthor(request.UserId)
                .Build();

            _repository.Update(product);

            var result =
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result == 0)
                return Result.ServerError(StatusMessage.ServerError);

            return Result.Success(StatusMessage.Updated);

        }
        catch (Exception)
        {
            return Result.ServerError(StatusMessage.ServerError);
        }
    }
}