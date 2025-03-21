namespace Ambev.DeveloperEvaluation.Common.Pagination;

public class Query
{
    /// <summary>
    /// Default registry per page
    /// </summary>
    public const int DefaultTakeValue = 10;

    /// <summary>
    /// Global search string
    /// </summary>
    public string Search { get; set; } = string.Empty;

    /// <summary>
    /// Returns true if Search parameter is not empty
    /// </summary>
    public bool HasSearch => !string.IsNullOrWhiteSpace(Search);

    /// <summary>
    /// If is true de query will be paginated and parameters Skip and Take will be considered
    /// </summary>
    public bool IsPaginated { get; set; } = true;

    /// <summary>
    /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
    /// Default = 0
    /// </summary>
    public int Skip { get; set; } = 0;

    /// <summary>
    /// Returns a specified number of contiguous elements from the start of a sequence.
    /// Default = 10
    /// </summary>
    public int Take { get; set; } = DefaultTakeValue;

    /// <summary>
    /// Calculated current page
    /// </summary>
    public int Page
        => Take > 0
            ? (int)Math.Ceiling((decimal)(Skip / Take)) + 1
            : 1;

    /// <summary>
    /// Order By fields delimitedf with pipe "|"
    /// Ex: Name DESC | Status
    /// </summary>
    public string OrderBy { get; set; } = string.Empty;

    /// <summary>
    /// Get Query params from page number
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">Quantity of registry per page</param>
    /// <param name="search">Free text search parameter</param>
    public static Query GetFromPage(int page, int take = DefaultTakeValue, string search = null)
    {
        return new Query
        {
            Skip = (page - 1) * take,
            Take = take,
            Search = search
        };
    }

    /// <summary>
    /// Get Query params from page number
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">Quantity of registry per page</param>
    /// <param name="search">Free text search parameter</param>
    /// <param name="orderBy">Order by fields</param>
    public static Query GetFromPage(int page, int take = DefaultTakeValue, string search = null, string orderBy = null)
    {
        var result = GetFromPage(page, take, search);
        result.OrderBy = orderBy;
        return result;
    }
}
