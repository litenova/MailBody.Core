using System;
using System.Collections.Generic;
using System.Linq;
using MailBody.Core.Abstractions;

namespace MailBody.Core.Elements;

public class RawElement : IMailElement
{
    public RawElement(string content)
    {
        Content = content;
    }

    public string ToHtml()
    {
        return Content;
    }

    public string Content { get; }
}

public class ListElement : IMailElement
{
    public ListElement(ListType type, IEnumerable<ListItemElement> items)
    {
        Type = type;
        Items = new List<ListItemElement>(items);
    }

    public ListType Type { get; }

    public IReadOnlyCollection<ListItemElement> Items { get; }

    public string ToHtml()
    {
        var items = string.Join(string.Empty, Items.Select(i => i.ToHtml()));

        return Type switch
        {
            ListType.Ordered   => $"<ol>{items}</ol>",
            ListType.Unordered => $"<ul>{items}</ul>",
            _                  => throw new ArgumentOutOfRangeException()
        };
    }

    public enum ListType
    {
        Ordered,
        Unordered,
    }
}