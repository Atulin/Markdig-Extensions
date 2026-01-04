using System.Collections.Generic;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers.Html;

namespace MarkdigExtensions.Center;

public class CenterInlineParser : InlineParser
{
    public CenterInlineParser()
    {
        OpeningCharacters = ['-'];
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
            
        // Match arrow
        if (current != '-' || slice.PeekChar() != '>') return false;

        while (current != '<' && slice.PeekChar() != '-')
        {
            end = slice.Start;
            current = slice.NextChar();
        }
            
        var center = new Center
        {
            Span =
            {
                Start = processor.GetSourcePosition(slice.Start, out var line, out var column)
            },
            Line = line,
            Column = column,
            Content = new StringSlice(slice.Text, start, end)
        };
        center.Span.End = center.Span.Start + (end - start);

        center.GetAttributes().Properties ??= [];
            
        center.GetAttributes().Properties?.Add(new KeyValuePair<string, string?>("style", "text-align: center"));
            
        processor.Inline = center;
            
        return true;

    }
}