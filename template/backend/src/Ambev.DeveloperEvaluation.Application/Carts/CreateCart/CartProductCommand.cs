namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a cart, 
/// including ProductId and Quantity. 
public record CartProductCommand
{
    /// <summary>
    /// Gets or sets the ProductId of the CardProduct to be created.
    /// </summary>
    public int ProductId { get; init; }

    /// <summary>
    /// Gets or sets the Quantity of the CardProduct to be created.
    /// </summary>
    public int Quantity { get; init; }
}
