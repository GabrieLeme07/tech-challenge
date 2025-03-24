using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCart;

public record GetListCartCommand(Query Query) : IRequest<ListCartResult>;