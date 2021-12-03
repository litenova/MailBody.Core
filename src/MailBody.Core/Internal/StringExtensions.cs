using System.Text;

namespace MailBody.Core.Internal;

internal static class StringExtensions
{
    /// <summary>
    /// Escape greater-than sign and less-than sign characters.
    /// </summary>
    /// <param name="unescapeText"></param>
    /// <returns></returns>
    public static string HtmlEncode(this string unescapeText)
    {
        var builder = new StringBuilder();
        foreach (var item in unescapeText)
        {
            switch (item)
            {
                case '<':
                    builder.Append("&lt;");
                    break;
                case '>':
                    builder.Append("&gt;");
                    break;
                default:
                    builder.Append(item);
                    break;
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Escape ", ', greater-than sign and less-than sign characters.
    /// </summary>
    /// <param name="unescapeText"></param>
    /// <returns></returns>
    public static string AttributeEncode(this string unescapeText)
    {
        var builder = new StringBuilder();
        foreach (var item in unescapeText)
        {
            switch (item)
            {
                case '"':
                    builder.Append("&quot;");
                    break;
                case '\'':
                    builder.Append("&#x27;");
                    break;
                case '<':
                    builder.Append("&lt;");
                    break;
                case '>':
                    builder.Append("&gt;");
                    break;
                default:
                    builder.Append(item);
                    break;
            }
        }

        return builder.ToString();
    }
}