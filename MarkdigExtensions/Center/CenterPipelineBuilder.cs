using Markdig;

namespace MarkdigExtensions.Center;

public static class CenterPipelineBuilder
{
    public static MarkdownPipelineBuilder UseCenter(this MarkdownPipelineBuilder pipeline)
    {
        pipeline.Extensions.AddIfNotAlready(new CenterExtension());

        return pipeline;
    }
}