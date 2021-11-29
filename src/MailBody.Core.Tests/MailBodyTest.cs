using System;
using Xunit;

namespace MailBody.Core.Tests;

public class MailBodyTest
{
    [Fact]
    public void Simple()
    {
        var body = MailBody.CreateBody()
                           .Paragraph("Please confirm your email address by clicking the link below.")
                           .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                           .Button("https://example.com/", "Confirm Email Address")
                           .Paragraph("— [Insert company name here]")
                           .ToString();

        Assert.NotEmpty(body);
    }

    [Fact]
    public void WithFooter()
    {
        var footer = MailBody.CreateBlock()
                             .Text("Follow ")
                             .Link("http://twitter.com/example", "@MailBody.Core.Examples")
                             .Text(" on Twitter.");

        var body = MailBody.CreateBody(footer)
                           .Paragraph("Please confirm your email address by clicking the link below.")
                           .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                           .Button("https://www.example.com/", "Confirm Email Address")
                           .Paragraph("— [Insert company name here]")
                           .ToString();

        Assert.NotEmpty(body);
    }

    [Fact]
    public void CustomThemeAndRawHtml()
    {
        var template = MailBodyTemplate.GetDefaultTemplate()
                                       .Paragraph(m => $"<p style='color:blue;'>{m.Content}</p>")
                                       .Body(m => "<html><body>" + m.Content + "<br />" + m.Footer +
                                                  "</body></html>");

        var footer = MailBody.CreateBlock()
                             .Text("Follow ")
                             .Link("http://twitter.com/example", "@MailBody.Core.Examples")
                             .Text(" on Twitter.");

        var body = MailBody.CreateBody(template, footer)
                           .Paragraph("Please confirm your email address by clicking the link below.")
                           .Raw("<p>We may need to send you <strong>critical information</strong> about our service and it is important that we have an accurate email address.</p>")
                           .Button("https://www.example.com/", "Confirm Email Address")
                           .Paragraph("— [Insert company name here]")
                           .ToString();

        Assert.NotEmpty(body);
    }

    [Fact]
    public void RunExampleProject()
    {
        Examples.Program.Main(Array.Empty<string>());
    }
}