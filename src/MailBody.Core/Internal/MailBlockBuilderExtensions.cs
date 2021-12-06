using System;
using MailBody.Core.Abstractions;

namespace MailBody.Core.Internal;

public static class MailBlockBuilderExtensions
{
    public static string ToHtml(this Action<IMailBlockBuilder> configMailBlockBuilder)
    {
        var blockBuilder = new MailBlockBuilder();
        configMailBlockBuilder(blockBuilder);

        return blockBuilder.ToHtml();
    }
    
    public static string ToHtml(this Action<MailBlockBuilder> configMailBlockBuilder)
    {
        var blockBuilder = new MailBlockBuilder();
        configMailBlockBuilder(blockBuilder);

        return blockBuilder.ToHtml();
    }
}