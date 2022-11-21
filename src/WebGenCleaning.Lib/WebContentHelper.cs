using System.Text.RegularExpressions;

namespace WebGenCleaning.Lib;

public static class WebContentHelper
{
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
        var t = sentence.ToString()!.Trim().ToLower();
        
        if (index > 0)
          formattedSentence += " ";
        
        formattedSentence += char.ToUpper(t[0]) + t.Substring(1);
        index++;
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