namespace Shop.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    /// <summary>
    /// config role
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}