using Markdig.Renderers.Normalize;

namespace MarkdigExtensions.Hashtags;

public class NormalizeHashtagLinksRenderer : NormalizeObjectRenderer<Hashtag>
{
    protected override void Write(NormalizeRenderer renderer, Hashtag obj)
    {
        renderer.Write(obj.Tag);
    }
}