using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Command for deleting a product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for deleting a product. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="DeleteProductResult"/>.
/// </remarks>
public record DeleteProductCommand(int Id) : IRequest<DeleteProductResult>;