namespace Shop.Infrastructure.Configurations;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    /// <summary>
    /// config role
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.HasKey(current => current.Id);
    }
}