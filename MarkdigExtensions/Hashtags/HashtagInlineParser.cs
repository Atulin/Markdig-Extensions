using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers.Html;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Hashtags;

public class HashtagInlineParser : InlineParser
{
    private readonly HashtagOptions _options;
    private readonly string _baseUrl;

    public HashtagInlineParser(HashtagOptions options)
    {
        _options = options;
        _baseUrl = _options.BaseUrl;
        OpeningCharacters = ['#'];
    }

    public override bool Match(InlineProcessor processor, ref StringSlice slice)
    {
        // Allow preceding whitespace
        var pc = slice.PeekCharExtra(-1);
        if (!pc.IsWhiteSpaceOrZero())
        {
            return false;
        }

        var current = slice.CurrentChar;

        var start = slice.Start;
        var end = slice.Start;

        // Read allowed characters
        while (current.IsAlphaNumeric() || current is '-' or '_' or '#')
        {
            end = slice.Start;
            current = slice.NextChar();
        }
            
        var tag = new Hashtag
        {
            Span =
            {
                Start = processor.GetSourcePosition(slice.Start, out var line, out var column)
            },
            Line = line,
            Column = column,
            Tag = new StringSlice(slice.Text, start, end)
        };
        tag.Span.End = tag.Span.Start + (end - start);
            
        // Build the URL
        var builder = StringBuilderCache.Local();
        builder
            .Append(_baseUrl)
            .Append("%23")
            .Append(tag.Tag.ToString().TrimStart('#'));
        tag.Url = builder.ToString();
            
        // Build the label
        tag.AppendChild(new LiteralInline(tag.Tag));
            
        // Add target
        if (_options.Target != null)
        {
            tag.GetAttributes().AddProperty("target", _options.Target);        
        }

        processor.Inline = tag;

        return true;
    }
}