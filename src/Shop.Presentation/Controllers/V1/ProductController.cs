namespace Shop.Presentation.Controllers.V1;

public class ProductController : GenericController<AddProductCommandRequest, Result<Guid>,
    UpdateProductCommandRequest, Result,
    DeleteProductCommandRequest, Result,
    GetProductByIdQueryRequest, Result<ProductDto>,
    GetAllProductsQueryRequest, Result<FrozenSet<ProductDto>>>
{
    public ProductController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Add product
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Result<Guid>>> Add(AddProductCommandRequest request,
        CancellationToken cancellation) => await base.AddAsync(request, cancellation);

    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<Result>> Update(UpdateProductCommandRequest request,
        CancellationToken cancellation) => (await base.UpdateAsync(request, cancellation)).ApiResult();

    /// <summary>
    /// Delete product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{id:required}")]
    public async Task<ActionResult<Result>> Delete(Guid id,
        CancellationToken cancellation) => (await base.DeleteAsync(new DeleteProductCommandRequest
        {
            Id = id,
        }, cancellation)).ApiResult();

    /// <summary>
    /// Get product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("Products/{id:required}")]
    public async Task<ActionResult<Result<ProductDto>>> GetById(Guid id,
        CancellationToken cancellation) => (await base.GetByIdAsync(new GetProductByIdQueryRequest
        {
            Id = id
        },
        cancellation)).ApiResult();

    /// <summary>
    /// Get products
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Result<FrozenSet<ProductDto>>>> GetAll(CancellationToken
        cancellation)
        => (await base.GetAllAsync(new GetAllProductsQueryRequest(), cancellation)).ApiResult();
}