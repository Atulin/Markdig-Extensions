using System.Diagnostics;
using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Mentions
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Mention : LinkInline
    {
        public Mention()
        {
            IsClosed = true;
        }

        public StringSlice Name { get; set; }
    }
}