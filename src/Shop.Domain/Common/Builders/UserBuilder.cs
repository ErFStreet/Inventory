namespace Shop.Domain.Common.Builders;

public class UserBuilder
{
    private User _user = new();

    /// <summary>
    /// Add first name
    /// </summary>
    /// <param name="firstName"></param>
    /// <returns></returns>
    public UserBuilder WithFirstName(string firstName)
    {
        _user.FirstName = firstName;

        return this;
    }

    /// <summary>
    /// Add last name
    /// </summary>
    /// <param name="lastName"></param>
    /// <returns></returns>
    public UserBuilder WithLastName(string lastName)
    {
        _user.LastName = lastName;

        return this;
    }

    /// <summary>
    /// Add email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public UserBuilder WithEmail(string email)
    {
        _user.Email = email;

        return this;
    }

    /// <summary>
    /// Add phone
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    public UserBuilder WithPhone(string phone)
    {
        _user.Phone = phone;

        return this;
    }

    /// <summary>
    /// Add password
    /// </summary>
    /// <param name="hashedPassword"></param>
    /// <returns></returns>
    public UserBuilder WithHashedPassword(string hashedPassword)
    {
        _user.Password = hashedPassword;

        return this;
    }

    /// <summary>
    /// Add role id
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public UserBuilder WithRole(Guid roleId)
    {
        _user.RoleId = roleId;

        return this;
    }

    /// <summary>
    /// Buid and return user
    /// </summary>
    /// <returns></returns>
    public User Build()
    {
        return _user;
    }
}
