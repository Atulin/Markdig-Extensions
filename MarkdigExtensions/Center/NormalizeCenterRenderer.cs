using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace MarkdigExtensions.Center
{
    public class NormalizeCenterRenderer : HtmlObjectRenderer<Center>
    {
        protected override void Write(HtmlRenderer renderer, Center obj)
        {
            renderer.EnsureLine();
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("<p").WriteAttributes(obj).Write(">");
            }
            renderer.WriteEscape(obj.Content);
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("</p>");
            }
            renderer.EnsureLine();
        }
    }
}