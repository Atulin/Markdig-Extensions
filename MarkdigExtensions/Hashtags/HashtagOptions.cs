namespace MarkdigExtensions.Hashtags;

/// <summary>
/// Available options for hashtags
/// </summary>
/// <param name="BaseUrl">Base url (e.g. `/tags/`)</param>
/// <param name="Target">Target of the anchor tag (_blank|_self|_parent|_top|framename)</param>
public record HashtagOptions(string BaseUrl, string? Target = null);