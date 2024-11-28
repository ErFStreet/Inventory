namespace Shop.Domain.Common.Builders;

public class FeatureDependencyBuilder
{
    private FeatureDependency _featureDependency = new();

    /// <summary>
    /// Add product id
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public FeatureDependencyBuilder WithProduct(Guid productId)
    {
        _featureDependency.ProductId = productId;

        return this;
    }

    /// <summary>
    /// Add feature value id
    /// </summary>
    /// <param name="featureValueId"></param>
    /// <returns></returns>
    public FeatureDependencyBuilder WithFeatureValue(Guid featureValueId)
    {
        _featureDependency.FeatureValueId = featureValueId;

        return this;
    }

    /// <summary>
    /// Buid and return feature
    /// </summary>
    /// <returns></returns>
    public FeatureDependency Build()
    {
        return _featureDependency;
    }
}