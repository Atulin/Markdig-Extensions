using System.Diagnostics;
using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Spoiler
{
    [DebuggerDisplay("{" + nameof(Content) + "}")]
    public class Spoiler : LeafInline
    {
        public StringSlice Content { get; set; }
    }
}