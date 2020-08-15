using Markdig;

namespace MarkdigExtensions.Hashtags
{
    public static class HashtagPipelineBuilder
    {
        public static MarkdownPipelineBuilder UseHashtags(this MarkdownPipelineBuilder pipeline, HashtagOptions options)
        {
            var extensions = pipeline.Extensions;

            if (!extensions.Contains<HashtagExtension>())
            {
                extensions.Add(new HashtagExtension(options));
            }

            return pipeline;
        }
    }
}