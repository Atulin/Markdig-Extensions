using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Renderers.Normalize;

namespace MarkdigExtensions.Hashtags
{
    public class HashtagExtension : IMarkdownExtension
    {
        private readonly HashtagOptions _options;

        public HashtagExtension(HashtagOptions options)
        {
            _options = options;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<HashtagInlineParser>())
            {
                pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new HashtagInlineParser(_options));
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
}