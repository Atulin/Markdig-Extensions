using System;
using System.Collections.Generic;
using System.Linq;
using Markdig;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using MarkdigExtensions.Center;
using MarkdigExtensions.Hashtags;
using MarkdigExtensions.Mentions;
using MarkdigExtensions.Spoiler;

var pipeline = new MarkdownPipelineBuilder()
	.UseHashtags(new HashtagOptions("https://mysite.com/tags/"))
	.UseMentions(new MentionOptions("https://mysite.com/user/"))
	.UseSpoilers()
	.UseCenter()
	.Build();

var testStrings = new List<string>
{
	"This is a #hashtag inside of some text",
	"This is a @Mention inside of some text",
	"This is a ||spoiler|| inside of some text",
	"This is a ->center<- inside of some text",
	"[This is an unsafe link](https://notascam.ru)"
};

var color = Console.ForegroundColor;
foreach (var markdown in testStrings)
{
	var html = Parse(markdown, pipeline);
	
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine(markdown);
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine(html);
	Console.WriteLine();
}
Console.ForegroundColor = color;
return;


string Parse(string md, MarkdownPipeline pipe)
{
	var doc = Markdown.Parse(md, pipe);

	foreach (var link in doc.Descendants().OfType<LinkInline>())
	{
		if (link.Url is not {} url) continue;

		var domain = new Uri(url).Host;
		
		link.GetAttributes().AddProperty("data-domain", domain);
	}

	return doc.ToHtml();
}