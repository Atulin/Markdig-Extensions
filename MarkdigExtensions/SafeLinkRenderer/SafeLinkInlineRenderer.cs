using Markdig.Renderers.Roundtrip;
using Markdig.Renderers.Roundtrip.Inlines;
using Markdig.Syntax.Inlines;

namespace MarkdigExtensions.SafeLinkRenderer;

public class SafeLinkInlineRenderer : LinkInlineRenderer
{
	protected override void Write(RoundtripRenderer renderer, LinkInline link)
	{
		// link text
		renderer.Write('<');
        
		if (link.Url != null)
		{
			renderer.Write(link.TriviaBeforeUrl);
			renderer.Write(link.UnescapedUrl);
			renderer.Write(link.TriviaBeforeUrl);
			renderer.Write('|');
		}
		
		renderer.WriteChildren(link);
		renderer.Write('>');
	}
}