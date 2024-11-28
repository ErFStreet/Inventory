namespace Shop.Infrastructure.Common.Extensions;

public static class ModelBuilderExtension
{
    /// <summary>
    /// Register entities
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterEntities(this ModelBuilder builder)
    {
        var types = typeof(IEntity).Assembly
            .GetExportedTypes()
            .Where(current => current.IsPublic & !current.IsAbstract
            && typeof(IEntity).IsAssignableFrom(current))
            .ToList();

        types.ForEach(current => builder.Entity(current));
    }

    /// <summary>
    /// Register configurations for entities
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterConfigurations(this ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}