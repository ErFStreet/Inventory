namespace Shop.Domain.Common.Builders;

public class RoleBuilder
{
    private Role _role = new();

    /// <summary>
    /// Add name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public RoleBuilder WithName(string name)
    {
        _role.Name = name;

        return this;
    }

    /// <summary>
    /// Buid and return role
    /// </summary>
    /// <returns></returns>
    public Role Build()
    {
        return _role;
    }
}