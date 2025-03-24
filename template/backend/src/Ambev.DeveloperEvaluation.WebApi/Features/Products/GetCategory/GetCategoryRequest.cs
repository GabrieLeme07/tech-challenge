using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetCategory;

public class GetCategoryRequest
{
    public Query Query { get; init; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string OrderBy { get; set; }
}
