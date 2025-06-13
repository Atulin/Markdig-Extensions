using System;
using System.IO;
using Markdig.Renderers.Normalize.Inlines;
using Markdig.Renderers.Roundtrip;

namespace MarkdigExtensions.SafeLinkRenderer;

public class SafeLinkRenderer : RoundtripRenderer
{
	public SafeLinkRenderer(TextWriter writer) : base(writer)
	{
		if (!ObjectRenderers.Replace<LinkInlineRenderer>(new SafeLinkInlineRenderer()))
		{
			throw new InvalidOperationException("Replacement failed!");
		}
	}
}