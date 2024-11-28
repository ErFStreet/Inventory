namespace Shop.Domain.Entities.Authentiaction;

public class Role : BaseEntity<Guid>
{
    public Role(string name)
    {
        Name = name;
    }

    public Role() { }

    /// <summary>
    /// Name or Title
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// List of users
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = default!;
}