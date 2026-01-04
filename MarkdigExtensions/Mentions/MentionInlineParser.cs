using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers.Html;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Mentions;

public class MentionInlineParser : InlineParser
{
    private readonly MentionOptions _options;
    private readonly string _baseUrl;

    public MentionInlineParser(MentionOptions options)
    {
        _options = options;
        _baseUrl = _options.BaseUrl;
        OpeningCharacters = ['@'];
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
        while (current.IsAlphaNumeric() || current is '-' or '_' or '@')
        {
            end = slice.Start;
            current = slice.NextChar();
        }
            
        var mention = new Mention
        {
            Span =
            {
                Start = processor.GetSourcePosition(slice.Start, out var line, out var column)
            },
            Line = line,
            Column = column,
            Name = new StringSlice(slice.Text, start, end)
        };
        mention.Span.End = mention.Span.Start + (end - start);
            
        // Build the URL
        var builder = StringBuilderCache.Local();
        builder.Append(_baseUrl).Append(mention.Name.ToString().TrimStart('@').ToLower());
        mention.Url = builder.ToString();
            
        // Build the label
        mention.AppendChild(new LiteralInline(mention.Name));
            
        // Add target
        if (_options.Target != null)
        {
            mention.GetAttributes().AddProperty("target", _options.Target);        
        }

        processor.Inline = mention;

        return true;
    }
}