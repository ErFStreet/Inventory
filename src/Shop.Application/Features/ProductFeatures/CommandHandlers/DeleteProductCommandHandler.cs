namespace Shop.Application.Features.UserFeatures.CommandHandlers;

public class DeleteProductCommandHandler :
    IRequestHandler<DeleteProductCommandRequest, Result>
{
    private readonly IRepository<Product, Guid> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IRepository<Product, Guid>
        repository,
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
    public async Task<Result> Handle(DeleteProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (!await _repository.Query.AnyAsync(current =>
                    current.Id.Equals(
                request.Id), cancellationToken))
                return Result.NotFound(StatusMessage.NotFound);

            var product =
                await _repository.QueryNoTracking
                .Where(current => current.Id.Equals(request.Id))
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null)
                return Result.NotFound(StatusMessage.NotFound);

            _repository.SoftDelete(product);

            var result =
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result == 0)
                return Result.ServerError(StatusMessage.ServerError);

            return Result.Success(StatusMessage.Deleted);

        }
        catch (Exception)
        {
            return Result.ServerError(StatusMessage.ServerError);
        }
    }
}