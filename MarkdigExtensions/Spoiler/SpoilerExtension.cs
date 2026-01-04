using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;

namespace MarkdigExtensions.Spoiler;

public class SpoilerExtension : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        var parser = pipeline.InlineParsers.Find<EmphasisInlineParser>() ?? new EmphasisInlineParser();
        if (!pipeline.InlineParsers.Contains<EmphasisInlineParser>())
        {
            pipeline.InlineParsers.Add(parser);
        }
        parser.EmphasisDescriptors.Add(new EmphasisDescriptor('|', 2, 2, true));
        parser.TryCreateEmphasisInlineList.Add((c, count) =>
        {
            if (c == '|' && count == 2)
            {
                return new SpoilerInline { DelimiterChar = c, DelimiterCount = count };
            }
            return null;
        });
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
        if (renderer is not HtmlRenderer htmlRenderer) return;
        var emphasisRenderer = new SpoilerInlineRenderer();
        htmlRenderer.ObjectRenderers.Replace<EmphasisInlineRenderer>(emphasisRenderer);
    }
}