using System.Collections.Generic;
using System.Linq;
using MailBody.Core.Abstractions;

namespace MailBody.Core;

public class MailBlockBuilder : IMailBlockBuilder
{
    private readonly List<IMailElement> _elements = new();

    public IMailBlockBuilder WithElement(IMailElement element)
    {
        _elements.Add(element);
        return this;
    }

    public virtual string ToHtml()
    {
        return string.Join(string.Empty, _elements.Select(e => e.ToHtml()));
    }
}