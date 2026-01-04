using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.Spoiler;

public class SpoilerInlineRenderer : EmphasisInlineRenderer
{
	protected override void Write(HtmlRenderer renderer, EmphasisInline obj)
	{
		if (obj is SpoilerInline)
		{
			renderer.Write("""<span class="spoiler">""");
			renderer.WriteChildren(obj);
			renderer.Write("</span>");
		}
		else
		{
			base.Write(renderer, obj);
		}
	}
}