using System.Text.RegularExpressions;

namespace WebGenCleaning.Lib;

/// <summary>
/// Contains methods for generation and formatting of HTML content.
/// </summary>
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

  /// <summary>
  /// Formats an array of text so that sentences are capitalized and
  /// stripped of leading and trailing whitespaces.
  /// </summary>
  /// <param name="textToBeFormatted">The rows of text which should be formatted.</param>
  /// <returns>An array of formatted sentences.</returns>
  public static string[] FormatSentences(string[] textToBeFormatted)
  {
    var formattedText = new List<string>();
    foreach (var text in textToBeFormatted)
    {
      string[] sentences = ExtractSentences(text);

      var formattedSentence = String.Empty;
      foreach (var sentence in sentences)
      {
        var trimmedSentence = sentence.Trim().ToLower();

        if (NotFirstSentence(sentence, sentences))
          AddBlankspaceBeforeSentence(ref formattedSentence);

        formattedSentence += AddUppercaseToFirstLetter(trimmedSentence);
      }

      formattedText.Add(formattedSentence);
    }

    return formattedText.ToArray();
  }

  private static bool NotFirstSentence(string sentence, string[] sentences)
  {
    return !(sentence == sentences[0]);
  }

  private static void AddBlankspaceBeforeSentence(ref string sentence)
  {
    sentence += " ";
  }

  private static string AddUppercaseToFirstLetter(string trimmedSentence)
  {
    return char.ToUpper(trimmedSentence[0]) + trimmedSentence[1..];
  }

  private static string[] ExtractSentences(string text)
  {
    var sentenceRegex = new Regex(@"(?<!\w\.\w.)(?<![A-Z][a-z]\.)(?<=\.|\?)\s");
    var sentences = sentenceRegex.Split(text);
    return sentences;
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