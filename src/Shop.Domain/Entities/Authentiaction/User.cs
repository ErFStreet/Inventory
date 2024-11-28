namespace Shop.Domain.Entities.Authentiaction;

public class User : BaseEntity<Guid>
{
    public User(string firstName,
        string lastName, string email,
        string phone, string password,
        Guid roleId)
    {
        FirstName = firstName;

        LastName = lastName;

        Email = email;

        Phone = phone;

        Password = password;

        RoleId = roleId;
    }

    public User() { }

    /// <summary>
    /// Name
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Last name
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Email 
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Mobile Phone
    /// </summary>
    public string Phone { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = default!;

    /// <summary>
    /// Foreign Key
    /// </summary>
    public Guid RoleId { get; set; } = default!;

    /// <summary>
    /// Current Role
    /// </summary>
    public virtual Role Role { get; set; } = default!;

    /// <summary>
    /// List of product
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = default!;
}