#nullable enable

namespace MarkdigExtensions.Spoiler
{
    /// <summary>
    /// Available options for hashtags
    /// </summary>
    public class SpoilerOptions
    {

        /// <summary>
        /// Target of the anchor tag (_blank|_self|_parent|_top|framename)
        /// Default is `_blank`
        /// </summary>
        public string Content { get; set; }

        public SpoilerOptions(string content)
        {
            Content = content;
        }
    }
}