namespace Shop.Application.Features.ProductFeatures.QueryHandlers;

public class GetProductByIdQueryHandler : IRequestHandler<
    GetProductByIdQueryRequest, Result<ProductDto>>
{
    private readonly IRepository<Product, Guid> _repository;

    public GetProductByIdQueryHandler(IRepository<Product,
        Guid> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handle to response result
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<ProductDto>> Handle(
        GetProductByIdQueryRequest
        request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _repository.Query.AnyAsync(current => current.Id
            .Equals(request.Id), cancellationToken))
                return Result<ProductDto>.NotFound(
                    StatusMessage.NotFound);

            var product =
                await _repository.QueryNoTracking
                .Include(current=>current.User)
                .Where(current => current.Id.Equals(request.Id))
                .Select(current => new ProductDto
                {
                    Id = current.Id,
                    Title= current.Title,
                    Description = current.Description,
                    Discount = current.Discount,
                    Tax = current.Tax,
                    Price = current.Price,
                    FullName = $"{current.User.FirstName} {current.User.LastName}"
                    
                }).FirstOrDefaultAsync(cancellationToken);

            if (product is null) return Result<ProductDto>.NotFound(
                StatusMessage.NotFound);

            return Result<ProductDto>.Success(StatusMessage.Found, product!);
        }
        catch (Exception)
        {
            return Result<ProductDto>.ServerError(StatusMessage.ServerError);
        }
    }
}