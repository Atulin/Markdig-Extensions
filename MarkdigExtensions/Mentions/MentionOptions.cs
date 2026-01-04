namespace MarkdigExtensions.Mentions;

/// <summary>
/// Available options for mentions
/// </summary>
/// <param name="BaseUrl">Base url (e.g. `/user/`)</param>
/// <param name="Target">Target of the anchor tag (_blank|_self|_parent|_top|framename)</param>
public record MentionOptions(string BaseUrl, string? Target = null);