using MailBody.Core.Abstractions;
using MailBody.Core.Styles.Default.Layouts;

namespace MailBody.Core;

public class MailBodyBuilder : MailBlockBuilder, IMailBodyBuilder
{
    private IMailLayout? _mailLayout;

    public IMailBlockBuilder WithLayout(IMailLayout mailLayout)
    {
        _mailLayout = mailLayout;
        return this;
    }

    public override string ToHtml()
    {
        var content = base.ToHtml();

        return _mailLayout?.ToHtml(content) ?? content;
    }
}