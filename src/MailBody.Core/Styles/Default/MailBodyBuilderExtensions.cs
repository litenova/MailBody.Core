using System.Collections.Generic;
using MailBody.Core.Abstractions;
using MailBody.Core.Styles.Default.Elements;
using MailBody.Core.Styles.Default.Layouts;

namespace MailBody.Core.Styles.Default;

public static class MailBodyBuilderExtensions
{
    public static IMailBlockBuilder WithDefaultLayout(this IMailBodyBuilder mailBodyBuilder, string? footer = null)
    {
        return mailBodyBuilder.WithLayout(new DefaultLayout(footer));
    }
    
    public static IMailBlockBuilder WithBreakLine(this IMailBlockBuilder mailBodyBuilder)
    {
        return mailBodyBuilder.WithElement(new BreakLineElement());
    }

    public static IMailBlockBuilder WithButton(this IMailBlockBuilder mailBodyBuilder, string link, string content)
    {
        return mailBodyBuilder.WithElement(new ButtonElement(link, content));
    }

    public static IMailBlockBuilder WithButton(this IMailBlockBuilder mailBodyBuilder, ButtonElement buttonElement)
    {
        return mailBodyBuilder.WithElement(buttonElement);
    }

    public static IMailBlockBuilder WithImage(this IMailBlockBuilder mailBodyBuilder,
                                             string src,
                                             string alt,
                                             string? style = null)
    {
        return mailBodyBuilder.WithElement(new ImageElement(src, alt, style));
    }

    public static IMailBlockBuilder WithImage(this IMailBlockBuilder mailBodyBuilder, ImageElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }

    public static IMailBlockBuilder WithLink(this IMailBlockBuilder mailBodyBuilder,
                                            string content,
                                            string link,
                                            LinkTarget target = LinkTarget.Blank)
    {
        return mailBodyBuilder.WithElement(new LinkElement(content, link, target));
    }

    public static IMailBlockBuilder WithLink(this IMailBlockBuilder mailBodyBuilder, LinkElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }

    public static IMailBlockBuilder WithParagraph(this IMailBlockBuilder mailBodyBuilder,
                                                 string content,
                                                 string? style = null,
                                                 string? @class = null)
    {
        return mailBodyBuilder.WithElement(new ParagraphElement(content, style, @class));
    }

    public static IMailBlockBuilder WithParagraph(this IMailBlockBuilder mailBodyBuilder, ParagraphElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }

    public static IMailBlockBuilder WithRaw(this IMailBlockBuilder mailBodyBuilder, string content)
    {
        return mailBodyBuilder.WithElement(new RawElement(content));
    }

    public static IMailBlockBuilder WithRaw(this IMailBlockBuilder mailBodyBuilder, RawElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }

    public static IMailBlockBuilder WithText(this IMailBlockBuilder mailBodyBuilder,
                                            string content,
                                            TextElement.TextType type = TextElement.TextType.Span,
                                            string? style = null,
                                            string? @class = null)
    {
        return mailBodyBuilder.WithElement(new TextElement(content, type, style, @class));
    }

    public static IMailBlockBuilder WithText(this IMailBlockBuilder mailBodyBuilder, TextElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }

    public static IMailBlockBuilder WithList(this IMailBlockBuilder mailBodyBuilder,
                                            ListElement.ListType type,
                                            IEnumerable<ListItemElement> items)
    {
        return mailBodyBuilder.WithElement(new ListElement(type, items));
    }

    public static IMailBlockBuilder WithList(this IMailBlockBuilder mailBodyBuilder, ListElement element)
    {
        return mailBodyBuilder.WithElement(element);
    }
}