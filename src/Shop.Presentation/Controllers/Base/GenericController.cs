namespace Shop.Presentation.Controllers.Base;

public abstract class GenericController<AddRequest, AddResult,
    UpdateRequest, UpdateResult,
    DeleteRequest, DeleteResult,
    GetByIdRequest, GetByIdResult,
    GetAllRequest, GetAllResult> : BaseController
{
    private readonly IMediator _mediator;

    public GenericController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Add entity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    internal async Task<AddResult> AddAsync(AddRequest request, CancellationToken cancellation)
    {
        try
        {
            var response =
                 await _mediator.Send(request!, cancellation);

            if (response is AddResult result)
                return result;

            throw new Exception(StatusMessage.ConvertError);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    internal async Task<UpdateResult> UpdateAsync(UpdateRequest request, CancellationToken cancellation)
    {
        try
        {
            var response =
            await _mediator.Send(request!, cancellation);

            if (response is UpdateResult result)
                return result;

            throw new Exception(StatusMessage.ConvertError);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    internal async Task<DeleteResult> DeleteAsync(DeleteRequest request, CancellationToken cancellation)
    {
        try
        {
            var response =
            await _mediator.Send(request!, cancellation);

            if (response is DeleteResult result)
                return result;

            throw new Exception(StatusMessage.ConvertError);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    internal async Task<GetByIdResult> GetByIdAsync(GetByIdRequest request, CancellationToken cancellation)
    {
        try
        {
            var response =
            await _mediator.Send(request!, cancellation);

            if (response is GetByIdResult result)
                return result;

            throw new Exception(StatusMessage.ConvertError);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    internal async Task<GetAllResult> GetAllAsync(GetAllRequest request, CancellationToken cancellation)
    {
        try
        {
            var response =
            await _mediator.Send(request!, cancellation);

            if (response is GetAllResult result)
                return result;

            throw new Exception(StatusMessage.ConvertError);
        }
        catch (Exception)
        {
            throw;
        }
    }
}