using System.Diagnostics;
using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Hashtags
{
    [DebuggerDisplay("{" + nameof(Tag) + "}")]
    public class Hashtag : LinkInline
    {
        public Hashtag()
        {
            IsClosed = true;
        }

        public StringSlice Tag { get; init; }
    }
}