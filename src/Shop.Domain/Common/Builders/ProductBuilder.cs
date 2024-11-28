namespace Shop.Domain.Common.Builders;

public class ProductBuilder
{
    private Product _product = new();

    /// <summary>
    /// Add title
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public ProductBuilder WithTitle(string title)
    {
        _product.Title = title;

        return this;
    }

    /// <summary>
    /// Add description
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public ProductBuilder WithDescription(string description)
    {
        _product.Description = description;

        return this;
    }

    /// <summary>
    /// Add price
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    public ProductBuilder WithPrice(decimal price)
    {
        _product.Price = price;

        return this;
    }

    /// <summary>
    /// Add discount
    /// </summary>
    /// <param name="discount"></param>
    /// <returns></returns>
    public ProductBuilder WithDiscount(int discount)
    {
        _product.Discount = discount;

        return this;
    }

    /// <summary>
    /// Add tax
    /// </summary>
    /// <param name="tax"></param>
    /// <returns></returns>
    public ProductBuilder WithTax(int tax)
    {
        _product.Tax = tax;

        return this;
    }

    /// <summary>
    /// Add user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public ProductBuilder WithAuthor(Guid userId)
    {
        _product.UserId = userId;

        return this;
    }

    /// <summary>
    /// Add id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ProductBuilder WithId(Guid id)
    {
        _product.Id = id;

        return this;
    }

    /// <summary>
    /// Buid and return product
    /// </summary>
    /// <returns></returns>
    public Product Build()
    {
        return _product;
    }
}