namespace MailBody.Core.Abstractions;

public interface IMailBlockBuilder
{
    IMailBlockBuilder WithElement(IMailElement layout);
    string ToHtml();
}