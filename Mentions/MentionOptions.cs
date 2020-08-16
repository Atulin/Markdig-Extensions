#nullable enable

namespace MarkdigExtensions.Mentions
{    
    /// <summary>
    /// Available options for mentions
    /// </summary>
    public class MentionOptions
    {
        /// <summary>
        /// Base url (e.g. `/user/`)
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Target of the anchor tag (_blank|_self|_parent|_top|framename)
        /// Default is `_blank`
        /// </summary>
        public string? Target { get; set; }

        public MentionOptions(string baseUrl, string? target = null)
        {
            BaseUrl = baseUrl;
            Target = target;
        }
    }
}