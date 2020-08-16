using Markdig;

namespace MarkdigExtensions.Mentions
{
    public static class MentionPipelineBuilder
    {
        public static MarkdownPipelineBuilder UseMentions(this MarkdownPipelineBuilder pipeline, MentionOptions options)
        {
            var extensions = pipeline.Extensions;

            if (!extensions.Contains<MentionExtension>())
            {
                extensions.Add(new MentionExtension(options));
            }

            return pipeline;
        }
    }
}