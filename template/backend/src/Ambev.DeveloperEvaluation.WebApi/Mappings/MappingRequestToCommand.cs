using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class MappingRequestToCommand : Profile
{
    public MappingRequestToCommand()
    {
        // Auth
        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();

        // User
        CreateMap<CreateUserRequest, CreateUserCommand>();

        // Product
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductRatingRequest, ProductRatingCommand>();

    }
}
