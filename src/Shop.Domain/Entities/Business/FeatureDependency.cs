namespace Shop.Domain.Entities.Business;

public class FeatureDependency : BaseEntity<Guid>
{
    public FeatureDependency(Guid featureId,
        Guid productId)
    {
        FeatureValueId = featureId;

        ProductId = productId;
    }

    public FeatureDependency() { }

    /// <summary>
    /// Feature id
    /// </summary>
    public Guid FeatureValueId { get; set; } = default!;

    /// <summary>
    /// Product id
    /// </summary>
    public Guid ProductId { get; set; } = default!;

    /// <summary>
    /// Current feature value
    /// </summary>
    public virtual FeatureValue FeatureValue { get; set; } = default!;

    /// <summary>
    /// Current product
    /// </summary>
    public virtual Product Product { get; set; } = default!;
}