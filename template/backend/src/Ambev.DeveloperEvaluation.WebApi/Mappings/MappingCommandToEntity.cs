using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class MappingCommandToEntity : Profile
{
    public MappingCommandToEntity()
    {
        // Cart
        CreateMap<CreateCartCommand, Cart>();
        CreateMap<CartProductCommand, CartProduct>();
    }
}
