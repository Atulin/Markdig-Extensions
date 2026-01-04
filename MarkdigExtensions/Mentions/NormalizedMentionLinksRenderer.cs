using Markdig.Renderers.Normalize;

namespace MarkdigExtensions.Mentions;

public class NormalizedMentionLinksRenderer : NormalizeObjectRenderer<Mention>
{
    protected override void Write(NormalizeRenderer renderer, Mention obj)
    {
        renderer.Write(obj.Name);
    }
}