namespace Shop.Infrastructure.Configurations;

public class FeatureValueConfiguration : IEntityTypeConfiguration<FeatureValue>
{
    /// <summary>
    /// config feature value
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<FeatureValue> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasOne(current => current.Feature)
            .WithMany(current => current.FeatureValues)
            .HasForeignKey(current => current.FeatureId);

        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}