using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public record GetProductCommand(int Id) : IRequest<GetProductResult>;