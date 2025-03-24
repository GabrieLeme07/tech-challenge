using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class MappingEntityToResult : Profile
{
    public MappingEntityToResult()
    {

        // Auth
        CreateMap<User, AuthenticateUserResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

        // Product
        CreateMap<Product, GetProductResult>();
        CreateMap<Rating, GetProductRatingResult>();

        // Cart
        CreateMap<Cart, CreateCartResult>();

        CreateMap<Sale, CreateSaleResult>();
    }
}
