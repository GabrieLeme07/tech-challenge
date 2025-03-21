using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class MappingRequestToCommand : Profile
{
    public MappingRequestToCommand()
    {
        // User
        CreateMap<CreateUserRequest, CreateUserCommand>();

        // Product
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductRatingRequest, ProductRatingCommand>();

    }
}
