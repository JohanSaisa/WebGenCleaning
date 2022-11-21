using System.Text.RegularExpressions;

namespace WebGenCleaning.Lib;

public static class WebContentHelper
{
  public static string[] FormatSentences(string[] textToBeFormatted)
  {
    var formattedText = new List<string>();
    foreach (var text in textToBeFormatted)
    {
      var regEx = new Regex(@"(?<sentences>(\S.+?[.!?])(?=\s+|$))|(?<sentencesNoDelmiter>[\w\s]+$)");
      var sentences = regEx.Matches(text).Cast<Match>().Select(m => m.Value).ToArray();

      var formattedSentence = "";
      
      foreach (var sentence in sentences)
      {
        var t = sentence.ToString()!.Trim().ToLower();
        formattedSentence += char.ToUpper(t[0]) + t.Substring(1);
      }

      formattedText.Add(formattedSentence);
    }

    return formattedText.ToArray();
  }

  public static string GenerateParagraph(string input)
  {
    return $"<p>{input}</p>";
  }
}