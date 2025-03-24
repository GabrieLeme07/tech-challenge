namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A INT that uniquely identifies the created user in the system.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product to be created.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of the product to be created.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product to be created.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the category of the product to be created.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the image of the product to be created.
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// Gets or sets the rating of the product to be created.
    /// </summary>
    public CreateProductRatingResult Rating { get; set; }
}
