using MailBody.Core.Abstractions;

namespace MailBody.Core.Elements;

public class ImageElement : IMailElement
{
    public ImageElement(string src, string alt, string? style = null)
    {
        Src = src;
        Alt = alt;
        Style = style ??
                "margin:0;Margin-bottom:15px;height:auto !important;max-width:100% !important;width:auto !important;";
    }

    public string Src { get; }

    public string Alt { get; }

    public string Style { get; }

    public string ToHtml()
    {
        return
            $"<img src='{Src}' alt='{Alt}' style='{Style}' />";
    }
}

