namespace Shop.Infrastructure.Configurations;

public class FeatureDependencyConfiguration : IEntityTypeConfiguration<FeatureDependency>
{
    /// <summary>
    /// config feature
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<FeatureDependency> builder)
    {
        builder.HasKey(current => current.Id);

        builder.HasOne(current => current.FeatureValue)
            .WithMany(current => current.FeatureDependencies)
            .HasForeignKey(current => current.FeatureValueId);

        builder.HasOne(current => current.Product)
            .WithMany(current => current.FeatureDependencies)
            .HasForeignKey(current => current.ProductId);


        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}