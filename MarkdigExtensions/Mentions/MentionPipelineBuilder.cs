using Markdig;

namespace MarkdigExtensions.Mentions;

public static class MentionPipelineBuilder
{
    public static MarkdownPipelineBuilder UseMentions(this MarkdownPipelineBuilder pipeline, MentionOptions options)
    {
        pipeline.Extensions.AddIfNotAlready(new MentionExtension(options));

        return pipeline;
    }
}