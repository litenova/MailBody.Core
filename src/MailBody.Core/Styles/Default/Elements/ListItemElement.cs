using MailBody.Core.Abstractions;
using MailBody.Core.Internal;

namespace MailBody.Core.Styles.Default.Elements;

public class ListItemElement : IMailElement
{
    public ListItemElement(string content, string? style = null, string? @class = null)
    {
        Style = style;
        Class = @class;
        Content = content;
    }

    public string? Style { get; }

    public string? Class { get; }

    public string Content { get; }

    public string ToHtml()
    {
        return new HtmlTagBuilder("li")
               .WithStyle(Style)
               .WithClass(Class)
               .WithContent(Content)
               .Build();
    }

    public static implicit operator ListItemElement(string content)
    {
        return new ListItemElement(content);
    }
}