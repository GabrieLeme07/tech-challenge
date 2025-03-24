using Ambev.DeveloperEvaluation.Application.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    /// <summary>
    /// Return QueryParameters from Query
    /// </summary>
    protected Query GetQueryParams(string search = default)
    {
        int.TryParse(Request.Query["_page"].ToString(), out var page);
        int.TryParse(Request.Query["_size"].ToString(), out var take);

        take = take == 0 ? 10 : take;
        page = page == 0 ? 1 : page;
        var orderBy = Request.Query["_order"].ToString();
        return Query.GetFromPage(page, take, search, orderBy);
    }

    protected Guid GetCurrentUserId() =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException());

    protected string GetCurrentUserEmail() =>
        User.FindFirst(ClaimTypes.Email)?.Value ?? throw new NullReferenceException();

    protected IActionResult Ok<T>(T data) =>
            base.Ok(new ApiResponseWithData<T> { Data = data, Success = true });

    protected IActionResult Created<T>(string routeName, object routeValues, T data) =>
        base.CreatedAtRoute(routeName, routeValues, new ApiResponseWithData<T> { Data = data, Success = true });

    protected IActionResult BadRequest(string message) =>
        base.BadRequest(new ApiResponse { Message = message, Success = false });

    protected IActionResult NotFound(string message = "Resource not found") =>
        base.NotFound(new ApiResponse { Message = message, Success = false });

    protected IActionResult OkPaginated<T>(PaginatedList<T> pagedList) =>
            Ok(new PaginatedResponse<T>
            {
                Data = pagedList,
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                TotalCount = pagedList.TotalCount,
                Success = true
            });
}
