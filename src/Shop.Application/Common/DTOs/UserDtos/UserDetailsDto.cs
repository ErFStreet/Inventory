namespace Shop.Application.Common.DTOs.UserDtos;

public class UserDetailsDto : BaseDto<Guid>
{
    public UserDetailsDto(string firstName,
        string lastName,
        string phone,
        string roleName,
        Guid roleId)
    {
        FirstName = firstName;

        LastName = lastName;

        Phone = phone;

        RoleName = roleName;

        RoleId = roleId;
    }

    public UserDetailsDto() { }

    /// <summary>
    /// First name
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Last name
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Phone number
    /// </summary>
    public string Phone { get; set; } = default!;

    /// <summary>
    /// Role name
    /// </summary>
    public string RoleName { get; set; } = default!;

    /// <summary>
    /// Role id
    /// </summary>
    public Guid RoleId { get; set; }
}