using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace MarkdigExtensions.Spoiler
{
    public class NormalizeSpoilerRenderer : HtmlObjectRenderer<Spoiler>
    {
        protected override void Write(HtmlRenderer renderer, Spoiler obj)
        {
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("<span").WriteAttributes(obj).Write(">");
            }
            renderer.WriteEscape(obj.Content);
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("</span>");
            }
        }
    }
}