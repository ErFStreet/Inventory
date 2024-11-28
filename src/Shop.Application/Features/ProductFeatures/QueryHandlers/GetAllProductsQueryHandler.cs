namespace Shop.Application.Features.ProductFeatures.QueryHandlers;

public class GetAllProductsQueryHandler : IRequestHandler<
    GetAllProductsQueryRequest, Result<FrozenSet<ProductDto>>>
{
    private readonly IRepository<Product, Guid> _repository;

    public GetAllProductsQueryHandler(IRepository<Product,
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
    public async Task<Result<FrozenSet<ProductDto>>> Handle(
        GetAllProductsQueryRequest
        request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _repository.Query.AnyAsync(cancellationToken))
                return Result<FrozenSet<ProductDto>>.NotFound(
                    StatusMessage.NotFound);

            var products =
               (await _repository.QueryNoTracking
                .Include(current => current.User)
                .Select(current => new ProductDto
                {
                    Id = current.Id,
                    Title = current.Title,
                    Description = current.Description,
                    Discount = current.Discount,
                    Tax = current.Tax,
                    Price = current.Price,
                    FullName = $"{current.User.FirstName} {current.User.LastName}"

                }).ToListAsync(cancellationToken)).ToFrozenSet();


            if (!products.Any()) return Result<FrozenSet<ProductDto>>.NotFound(
                StatusMessage.NotFound);

            return Result<FrozenSet<ProductDto>>.Success(StatusMessage.Found, 
                products!);
        }
        catch (Exception)
        {
            return Result<FrozenSet<ProductDto>>.ServerError(
                StatusMessage.ServerError);
        }
    }
}