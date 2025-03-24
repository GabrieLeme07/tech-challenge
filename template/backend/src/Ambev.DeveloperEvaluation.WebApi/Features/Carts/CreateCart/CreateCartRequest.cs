namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public record CreateCartRequest(List<CreateProductCartRequest> Products);