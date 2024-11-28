namespace Shop.Infrastructure.SeedWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Save changes 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellation)
    {
        try
        {
            return await _dbContext.SaveChangesAsync(cancellation);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Dispose db
    /// </summary>
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}