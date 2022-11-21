// See https://aka.ms/new-console-template for more information

/*
 * Data ifrån API
 */

using WebGenCleaning.Lib;

string[] techniques = {"   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   "};
string[] messagesToClass = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };

var myWebPage = new List<string>();

var myHeading = WebContentHelper.GenerateHtml(HtmlTag.Heading, $" Välkomna Klass A! ");

myWebPage.Add(myHeading);

foreach (var message in messagesToClass)
{
  var staticHtml = WebContentHelper.GenerateHtml(HtmlTag.Bold, " Meddelande: ");
  var htmlMessage = WebContentHelper.GenerateHtml(HtmlTag.Paragraph, $"{staticHtml} {message} ");

  myWebPage.Add(htmlMessage);
}

foreach (var technique in WebContentHelper.FormatSentences(techniques))
{
  myWebPage.Add(WebContentHelper.GenerateHtml(HtmlTag.Paragraph, technique));
}

foreach (var htmlRow in WebContentHelper.GenerateHtmlWrapper(myWebPage.ToArray()))
{
  Console.WriteLine(htmlRow);
}