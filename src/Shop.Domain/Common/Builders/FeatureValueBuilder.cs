namespace Shop.Domain.Common.Builders;

public class FeatureValueBuilder
{
    private FeatureValue _featureValue = new();

    /// <summary>
    /// Add name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public FeatureValueBuilder WithName(string name)
    {
        _featureValue.Name = name;

        return this;
    }

    /// <summary>
    /// Add feature id
    /// </summary>
    /// <param name="featureId"></param>
    /// <returns></returns>
    public FeatureValueBuilder WithFeature(Guid featureId)
    {
        _featureValue.FeatureId = featureId;

        return this;
    }

    /// <summary>
    /// Buid and return feature value
    /// </summary>
    /// <returns></returns>
    public FeatureValue Build()
    {
        return _featureValue;
    }
}