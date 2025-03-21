namespace Ambev.DeveloperEvaluation.Common.PrimitiveTypeExtensions;

public static class StringExtensions
{
    /// <summary>
    /// Indicates whether a specified string is null, empty, or consists only of white-space
    //  characters.
    /// </summary>
    public static bool IsNullOrWhiteSpace(this string source)
        => string.IsNullOrWhiteSpace(source);
}
