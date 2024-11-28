namespace Shop.Domain.Entities.Business;

public class FeatureValue : BaseEntity<Guid>
{
    public FeatureValue(string name)
    {
        Name = name;
    }

    public FeatureValue() { }

    /// <summary>
    /// Feature value name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Feature id
    /// </summary>
    public Guid FeatureId { get; set; } = default!;

    /// <summary>
    /// Current feature 
    /// </summary>
    public virtual Feature Feature { get; set; } = default!;

    /// <summary>
    /// Current feature dependencies
    /// </summary>
    public virtual ICollection<FeatureDependency> FeatureDependencies { get; set; } = default!;
}