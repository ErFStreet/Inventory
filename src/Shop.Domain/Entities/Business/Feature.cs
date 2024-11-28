namespace Shop.Domain.Entities.Business;

public class Feature : BaseEntity<Guid>
{
    public Feature(string name)
    {
        Name = name;
    }

    public Feature() { }

    /// <summary>
    /// Feature name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// List of feature values
    /// </summary>
    public virtual ICollection<FeatureValue> FeatureValues { get; set; } = default!;
}
