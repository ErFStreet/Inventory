namespace Shop.Application.Features.UserFeatures.Commands;

public class GetAllProductsQueryRequest :
     IRequest<Result<FrozenSet<ProductDto>>>
{ }