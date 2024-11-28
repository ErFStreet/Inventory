namespace Shop.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// config user
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(current => current.Id);

        builder.Property(current => current.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(current => current.LastName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(current => current.Email)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(current => current.Phone)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(current => current.Password)
            .IsRequired();

        builder.HasOne(current => current.Role)
            .WithMany(current => current.Users)
            .HasForeignKey(current => current.RoleId);

        builder.HasQueryFilter(current => !current.IsDeleted);
    }
}