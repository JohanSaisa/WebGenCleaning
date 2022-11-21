using System.Text.RegularExpressions;

namespace WebGenCleaning.Lib;

public static class WebContentHelper
{
  private static readonly Dictionary<HtmlTag, string> HtmlTags = new Dictionary<HtmlTag, string>()
  {
    {HtmlTag.Bold, "b"},
    {HtmlTag.Paragraph, "p"},
    {HtmlTag.Heading, "h1"},
  };
  
  private static readonly string[] HtmlStart = new string[] { "<!DOCTYPE html>", "<html>", "<body>", "<main>", };
  private static readonly string[] HtmlEnd = new string[] { "</main>", "</body>", "</html>", };
  
  public static string[] FormatSentences(string[] textToBeFormatted)
  {
    var formattedText = new List<string>();
    foreach (var text in textToBeFormatted)
    {
      var regEx = new Regex(@"(?<!\w\.\w.)(?<![A-Z][a-z]\.)(?<=\.|\?)\s");
      var sentences = regEx.Split(text);

      var formattedSentence = "";

      var index = 0;
      foreach (var sentence in sentences)
      {
        var t = sentence.Trim().ToLower();
        
        if (index > 0)
          formattedSentence += " ";
        
        formattedSentence += char.ToUpper(t[0]) + t[1..];
        index++;
      }

      formattedText.Add(formattedSentence);
    }

    return formattedText.ToArray();
  }

  public static string GenerateHtml(HtmlTag htmlTag, string input)
  {
    return $"<{HtmlTags[htmlTag]}>{input}</{HtmlTags[htmlTag]}>";
  }

  public static string[] GenerateHtmlWrapper(string[] input)
  {
    return HtmlStart.Concat(input).ToArray().Concat(HtmlEnd).ToArray();
  }
}

public enum HtmlTag
{
  Paragraph,
  Bold,
  Heading,
}