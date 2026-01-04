using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Renderers.Normalize;

namespace MarkdigExtensions.Hashtags;

public class HashtagExtension(HashtagOptions options) : IMarkdownExtension
{

    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        if (!pipeline.InlineParsers.Contains<HashtagInlineParser>())
        {
            pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new HashtagInlineParser(options));
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