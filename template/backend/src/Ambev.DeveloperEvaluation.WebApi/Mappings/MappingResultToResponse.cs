using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class MappingResultToResponse : Profile
{
    public MappingResultToResponse()
    {
        // Auth
        CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();

        // Product
        CreateMap<CreateProductResult, CreateProductResponse>();
        CreateMap<CreateProductRatingResult, CreateProductRatingResponse>();
        CreateMap<GetProductResult, GetProductResponse>();
        CreateMap<GetProductRatingResult, GetProductRatingResponse>();


        // Sale
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();
    }
}
