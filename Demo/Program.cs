using System;
using System.Collections.Generic;
using System.Linq;
using Markdig;
using MarkdigExtensions.Center;
using MarkdigExtensions.Hashtags;
using MarkdigExtensions.Mentions;
using MarkdigExtensions.Spoiler;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
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
                "This is a ->center<- inside of some text"
            };

            var result = testStrings.ToDictionary(s => s, s => Markdown.ToHtml(s, pipeline));

            var color = Console.ForegroundColor;
            foreach (var (markdown, html) in result)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(markdown);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(html);
                Console.WriteLine();
            }
            Console.ForegroundColor = color;
        }
    }
}