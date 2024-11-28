namespace Shop.Application.Common.DTOs.ProductDtos;

public class ProductDto : BaseDto<Guid>
{
    public ProductDto() { }

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
    public Guid? UserId { get; set; } = null!;
    
    /// <summary>
    /// Current user
    /// </summary>
    public virtual User? User { get; set; } = null;

    /// <summary>
    /// Full name
    /// </summary>
    public string FullName { get; set; } = default!;


    /// <summary>
    /// List of feature dependencies
    /// </summary>
    public virtual ICollection<FeatureDependency>?
        FeatureDependencies
    { get; set; } = null;
}