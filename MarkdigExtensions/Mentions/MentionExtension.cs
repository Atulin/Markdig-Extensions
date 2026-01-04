using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Renderers.Normalize;
using MarkdigExtensions.Hashtags;

namespace MarkdigExtensions.Mentions;

public class MentionExtension(MentionOptions options) : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        if (!pipeline.InlineParsers.Contains<MentionInlineParser>())
        {
            pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new MentionInlineParser(options));
        }
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
        if (renderer is NormalizeRenderer normalizeRenderer && !normalizeRenderer.ObjectRenderers.Contains<NormalizeHashtagLinksRenderer>())
        {
            normalizeRenderer.ObjectRenderers.InsertBefore<LinkInlineRenderer>(new NormalizeHashtagLinksRenderer());
        }
    }
}