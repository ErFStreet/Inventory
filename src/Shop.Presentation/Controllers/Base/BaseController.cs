namespace Shop.Presentation.Controllers.Base;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public abstract class BaseController : ControllerBase
{
}