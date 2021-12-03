using System.Collections.Generic;
using System.Linq;
using MailBody.Core.Abstractions;
using MailBody.Core.Elements;
using MailBody.Core.Layouts;

namespace MailBody.Core;

public class MailBodyBuilder
{
    private List<IMailElement> _elements = new();
    private IMailLayout _mailLayout = new DefaultLayout();

    public MailBodyBuilder WithLayout(IMailLayout mailLayout)
    {
        _mailLayout = mailLayout;
        return this;
    }

    public MailBodyBuilder WithBreakLine()
    {
        _elements.Add(new BreakLineElement());
        return this;
    }

    public MailBodyBuilder WithButton(string link, string content)
    {
        return WithElement(new ButtonElement(link, content));
    }

    public MailBodyBuilder WithButton(ButtonElement buttonElement)
    {
        return WithElement(buttonElement);
    }

    public MailBodyBuilder WithImage(string src, string alt, string? style = null)
    {
        return WithElement(new ImageElement(src, alt, style));
    }

    public MailBodyBuilder WithImage(ImageElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithLink(string content, string link, LinkTarget target = LinkTarget.Blank)
    {
        return WithElement(new LinkElement(content, link, target));
    }

    public MailBodyBuilder WithLink(LinkElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithParagraph(string content, string? style = null, string? @class = null)
    {
        return WithElement(new ParagraphElement(content, style, @class));
    }

    public MailBodyBuilder WithParagraph(ParagraphElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithRaw(string content)
    {
        return WithElement(new RawElement(content));
    }

    public MailBodyBuilder WithRaw(RawElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithText(string content,
                                    TextElement.TextType type = TextElement.TextType.Span,
                                    string? style = null,
                                    string? @class = null)
    {
        return WithElement(new TextElement(content, type, style, @class));
    }

    public MailBodyBuilder WithText(TextElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithList(ListElement.ListType type, IEnumerable<ListItemElement> items)
    {
        return WithElement(new ListElement(type, items));
    }

    public MailBodyBuilder WithList(ListElement element)
    {
        return WithElement(element);
    }

    public MailBodyBuilder WithElement(IMailElement element)
    {
        _elements.Add(element);
        return this;
    }

    public string ToHtml()
    {
        var content = string.Join(string.Empty, _elements.Select(e => e.ToHtml()));

        return _mailLayout.ToHtml(content);
    }
}