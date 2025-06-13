using Markdig;
using Markdig.Parsers.Inlines;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;

namespace MarkdigExtensions.Center
{
    public class CenterExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            if (!pipeline.InlineParsers.Contains<CenterInlineParser>())
            {
                pipeline.InlineParsers.InsertBefore<LinkInlineParser>(new CenterInlineParser());
            }
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            if (!renderer.ObjectRenderers.Contains<NormalizeCenterRenderer>())
            {
                renderer.ObjectRenderers.InsertBefore<LinkInlineRenderer>(new NormalizeCenterRenderer());
            }
        }
    }
}