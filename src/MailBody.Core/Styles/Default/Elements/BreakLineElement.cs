using MailBody.Core.Abstractions;

namespace MailBody.Core.Styles.Default.Elements;

public class BreakLineElement : IMailElement
{
    public string ToHtml()
    {
        return "<br/>";
    }
}