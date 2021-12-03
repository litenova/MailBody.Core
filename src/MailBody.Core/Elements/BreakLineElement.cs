using MailBody.Core.Abstractions;

namespace MailBody.Core.Elements;

public class BreakLineElement : IMailElement
{
    public string ToHtml()
    {
        return "<br/>";
    }
}