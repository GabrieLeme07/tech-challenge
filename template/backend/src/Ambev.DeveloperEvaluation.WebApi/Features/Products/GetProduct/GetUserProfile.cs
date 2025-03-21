using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>()
            .ForMember(dest => dest.Query, opt => opt.MapFrom((src, dest, destMember, context) =>
                context.Items.ContainsKey("Query") ? context.Items["Query"] as Query : null));
    }
}
