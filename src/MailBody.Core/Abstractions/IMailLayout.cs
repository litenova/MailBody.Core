namespace MailBody.Core.Abstractions;

public interface IMailLayout
{
    string ToHtml(string content);
}