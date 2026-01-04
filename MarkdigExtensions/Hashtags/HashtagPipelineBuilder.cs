using Markdig;

namespace MarkdigExtensions.Hashtags;

public static class HashtagPipelineBuilder
{
    public static MarkdownPipelineBuilder UseHashtags(this MarkdownPipelineBuilder pipeline, HashtagOptions options)
    {
        pipeline.Extensions.AddIfNotAlready(new HashtagExtension(options));

        return pipeline;
    }
}