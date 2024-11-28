namespace Shop.Domain.Entities.Business;

public class Product : BaseEntity<Guid>
{
    public Product(string title,
        string description,
        decimal price,
        int discount,
        int tax)
    {
        Title = title;

        Description = description;

        Price = price;

        Discount = discount;

        Tax = tax;
    }

    public Product() { }

    /// <summary>
    /// Title or Name
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Description or Information
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; } = default!;

    /// <summary>
    /// Discount to percent 
    /// </summary>
    public int Discount { get; set; } = default!;

    /// <summary>
    /// Tax 
    /// </summary>
    public int Tax { get; set; } = default!;

    /// <summary>
    /// User id
    /// </summary>
    public Guid UserId { get; set; } = default!;

    /// <summary>
    /// Current user
    /// </summary>
    public virtual User User { get; set; } = default!;

    /// <summary>
    /// List of feature dependencies
    /// </summary>
    public virtual ICollection<FeatureDependency> FeatureDependencies { get; set; } = default!;
}