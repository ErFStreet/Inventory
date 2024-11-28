namespace Shop.Presentation.Controllers.V1;

public class AuthentiactionController : BaseController
{
    private readonly IMediator _mediator;

    public AuthentiactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Sign In
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Result<string>>> LoginAsync([FromBody]LoginCommandRequest
        request, CancellationToken cancellation)
    {
		try
		{
            var result =
                await _mediator.Send(request, cancellation);

            if (result is Result<string> response)
                return response.ApiResult();

            return Result<string>.ServerError("Server Error");
		}
		catch (Exception)
		{
            return Result<string>.ServerError("Server Error");
        }
    }
}