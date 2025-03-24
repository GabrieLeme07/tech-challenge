namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public List<CreateProductCartRequest> Products { get; set; } = new List<CreateProductCartRequest>();
}
