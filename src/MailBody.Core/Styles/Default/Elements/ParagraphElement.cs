using MailBody.Core.Abstractions;
using MailBody.Core.Internal;

namespace MailBody.Core.Styles.Default.Elements;

public class ParagraphElement : IMailElement
{
    public ParagraphElement(string content, string? style, string? @class)
    {
        Content = content;
        Style = style ??
                "font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;";
        Class = @class;
    }

    public string Content { get; }

    public string Style { get; }

    public string? Class { get; }

    public string ToHtml()
    {
        return new HtmlTagBuilder("p").WithClass(Class)
                                      .WithStyle(Style)
                                      .WithContent(Content)
                                      .Build();
    }
}