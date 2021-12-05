namespace MailBody.Core.Abstractions;

public interface IMailBodyBuilder : IMailBlockBuilder
{
    IMailBlockBuilder WithLayout(IMailLayout layout);
}