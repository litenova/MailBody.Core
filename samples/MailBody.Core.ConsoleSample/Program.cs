// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Threading.Channels;
using MailBody.Core;

var html = new MailBodyBuilder()
           .WithParagraph("Please confirm your email address by clicking the link below.")
           .WithParagraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
           .WithButton("https://example.com/", "Confirm Email Address")
           .WithParagraph("— [Insert company name here]")
           .ToHtml();

string projectPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
var destinationFolder = Path.Combine(projectPath, "HTML-Files", "sample.html");

File.WriteAllText(destinationFolder, html);

Console.WriteLine("Done!");
Console.ReadKey();