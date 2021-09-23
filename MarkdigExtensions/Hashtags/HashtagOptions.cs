namespace MarkdigExtensions.Hashtags
{
    /// <summary>
    /// Available options for hashtags
    /// </summary>
    public class HashtagOptions
    {
        /// <summary>
        /// Base url (e.g. `/tags/`)
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Target of the anchor tag (_blank|_self|_parent|_top|framename)
        /// Default is `_blank`
        /// </summary>
        public string? Target { get; set; }

        public HashtagOptions(string baseUrl, string? target = null)
        {
            BaseUrl = baseUrl;
            Target = target;
        }
    }
}