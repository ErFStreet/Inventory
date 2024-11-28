namespace Shop.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// config product
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(current => current.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(current => current.Price)
            .IsRequired();

        builder.Property(current => current.Tax)
            .IsRequired();

        builder.Property(current => current.Discount)
            .IsRequired();

        builder.HasOne(current => current.User)
            .WithMany(current => current.Products)
            .HasForeignKey(current => current.UserId);

        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}