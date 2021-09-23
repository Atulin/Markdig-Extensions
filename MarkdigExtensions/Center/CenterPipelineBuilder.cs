using Markdig;

namespace MarkdigExtensions.Center
{
    public static class CenterPipelineBuilder
    {
        public static MarkdownPipelineBuilder UseCenter(this MarkdownPipelineBuilder pipeline)
        {
            var extensions = pipeline.Extensions;

            if (!extensions.Contains<CenterExtension>())
            {
                extensions.Add(new CenterExtension());
            }

            return pipeline;
        }
    }
}