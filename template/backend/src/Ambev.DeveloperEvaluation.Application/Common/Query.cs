namespace Ambev.DeveloperEvaluation.Application.Common;

public class Query
{
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
    public int Take { get; set; } = 10;

    /// <summary>
    /// Calculated current page
    /// </summary>
    public int Page
        => Take > 0
            ? (int)Math.Ceiling((decimal)(Skip / Take)) + 1
            : 1;

    /// <summary>
    /// Order By fields delimited with ","
    /// Ex: Name DESC , Status
    /// </summary>
    public string OrderBy { get; set; } = string.Empty;

}
