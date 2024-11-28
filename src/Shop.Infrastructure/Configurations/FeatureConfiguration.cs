namespace Shop.Infrastructure.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    /// <summary>
    /// config feature
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}