namespace Shop.Domain.Common.Builders;

public class FeatureBuilder
{
    private Feature _feature = new();

    /// <summary>
    /// Add name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public FeatureBuilder WithName(string name)
    {
        _feature.Name = name;

        return this;
    }

    /// <summary>
    /// Buid and return feature
    /// </summary>
    /// <returns></returns>
    public Feature Build()
    {
        return _feature;
    }
}