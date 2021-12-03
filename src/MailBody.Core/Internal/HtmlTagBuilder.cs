using System.Collections.Generic;
using System.Linq;

namespace MailBody.Core.Internal;

public class HtmlTagBuilder
{
    private readonly string _tagName;
    private readonly bool _isClosed;
    private readonly Dictionary<string, string> _attributes = new();
    private string _content = string.Empty;

    public HtmlTagBuilder(string tagName, bool isClosed = false)
    {
        _tagName = tagName;
        _isClosed = isClosed;
    }

    public HtmlTagBuilder WithStyle(string? style)
    {
        if (!string.IsNullOrEmpty(style))
        {
            _attributes["style"] = style;
        }

        return this;
    }

    public HtmlTagBuilder WithClass(string? @class)
    {
        if (!string.IsNullOrEmpty(@class))
        {
            _attributes["class"] = @class;
        }

        return this;
    }

    public HtmlTagBuilder WithClass(params string[] @classes)
    {
        if (@classes.Any())
        {
            _attributes["class"] = string.Join(' ', classes);
        }

        return this;
    }

    public HtmlTagBuilder WithAttribute(string name, string value)
    {
        _attributes[name] = value;

        return this;
    }

    public HtmlTagBuilder WithContent(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            _content = content;
        }

        return this;
    }

    public string Build()
    {
        var attributes = string.Join(' ', _attributes.Select(a => $"{a.Key}='{a.Value}'"));

        return _isClosed ? $"<{_tagName} {attributes} />" : $"<{_tagName} {attributes}>{_content}</{_tagName}>";
    }
}