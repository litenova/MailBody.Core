using System.ComponentModel;
using MailBody.Core.Abstractions;
using MailBody.Core.Internal;

namespace MailBody.Core.Styles.Default.Elements;

public class TextElement : IMailElement
{
    public TextElement(string content, TextType type = TextType.Span, string? style = null, string? @class = null)
    {
        Content = content;
        Type = type;
        Style = style;
        Class = @class;
    }

    public string Content { get; }

    public string? Style { get; }

    public string? Class { get; }

    public TextType Type { get; }

    public string ToHtml()
    {
        return new HtmlTagBuilder(Type.GetDescription()).WithClass(Class)
                                                        .WithStyle(Style)
                                                        .WithContent(Content)
                                                        .Build();
    }

    public enum TextType
    {
        [Description("span")] Span,

        [Description("strong")] Strong,

        [Description("h1")] Heading1,

        [Description("h2")] Heading2,

        [Description("h3")] Heading3,

        [Description("h4")] Heading4,

        [Description("h5")] Heading5,

        [Description("h6")] Heading6
    }
}