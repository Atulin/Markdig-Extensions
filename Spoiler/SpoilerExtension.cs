using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;

namespace MarkdigExtensions.Spoiler
{
    public class SpoilerExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<SpoilerInlineParser>())
            {
                pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new SpoilerInlineParser());
            }
        }
        
        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (!renderer.ObjectRenderers.Contains<NormalizeSpoilerRenderer>())
            {
                renderer.ObjectRenderers.InsertBefore<LinkInlineRenderer>(new NormalizeSpoilerRenderer());
            }
        }
    }
}