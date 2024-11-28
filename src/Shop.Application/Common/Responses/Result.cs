namespace Shop.Application.Common.Responses;

public class Result
{
    /// <summary>
    /// Status code
    /// </summary>
    public int StatusCode { get; protected set; }
    
    /// <summary>
    /// Is success
    /// </summary>
    public bool IsSuccess { get; protected set; }
    
    /// <summary>
    /// Messages
    /// </summary>
    public IEnumerable<string> Messages { get; protected set; } = [];

    /// <summary>
    /// Success
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result Success(string message)
        => new Result
        {
            IsSuccess = true,
            StatusCode = 200,
            Messages = [message]
        };

    /// <summary>
    /// Not found
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result NotFound(string message)
        => new Result
        {
            Messages = [message],
            StatusCode = 404
        };

    /// <summary>
    /// Bad request
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result BadRequest(string message)
        => new Result
        {
            Messages = [message],
            StatusCode = 400
        };

    /// <summary>
    /// Server error
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result ServerError(string message)
        => new Result
        {
            Messages = [message],
            StatusCode = 500
        };
}

public class Result<TData> : Result
{
    /// <summary>
    /// Data to return
    /// </summary>
    public TData Data { get; private set; } = default!;

    /// <summary>
    /// Success
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Result<TData> Success(string message, TData data)
        => new Result<TData>
        {
            IsSuccess = true,
            StatusCode = 200,
            Messages = [message],
            Data = data
        };

    /// <summary>
    /// Not found
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public new static Result<TData> NotFound(string message)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = 404
        };

    /// <summary>
    /// Bad request
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public new static Result<TData> BadRequest(string message)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = 400
        };

    /// <summary>
    /// Server error
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public new static Result<TData> ServerError(string message)
        => new Result<TData>
        {
            Messages = [message],
            StatusCode = 500
        };
}