using System.Diagnostics;
using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Center
{
    [DebuggerDisplay("{" + nameof(Content) + "}")]
    public class Center : LeafInline
    {
        public Center()
        {
            IsClosed = true;
        }
        public StringSlice Content { get; init; }
    }
}