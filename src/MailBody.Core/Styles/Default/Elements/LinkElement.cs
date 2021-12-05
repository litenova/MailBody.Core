using System;
using MailBody.Core.Abstractions;

namespace MailBody.Core.Styles.Default.Elements;

public class LinkElement : IMailElement
{
    public LinkElement(string content, string link, LinkTarget target = LinkTarget.Blank)
    {
        Content = content;
        Link = link;
        Target = target;
    }

    public string ToHtml()
    {
        return $"<a href='{Link}' target='{ParseTarget(Target)}'>{Content}</a>";
    }

    public string Content { get; }

    public string Link { get; }

    public LinkTarget Target { get; }

    private readonly string _target;

    private static string ParseTarget(LinkTarget target)
    {
        return target switch
        {
            LinkTarget.Blank  => "_blank",
            LinkTarget.Parent => "_parent",
            LinkTarget.Self   => "_self",
            LinkTarget.Top    => "_top",
            _                 => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }
}