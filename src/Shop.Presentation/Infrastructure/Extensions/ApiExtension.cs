namespace Shop.Presentation.Infrastructure.Extensions;

public static class ApiExtension
{
    /// <summary>
    /// object to api result
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static ObjectResult ApiResult(this Result result)
        => new ObjectResult(result)
        {
            StatusCode = result.StatusCode,
        };
}