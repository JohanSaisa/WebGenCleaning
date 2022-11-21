using FluentAssertions;

namespace WebGenCleaning.Lib.Test;

public class UnitTest1
{
  [Theory]
  [InlineData(
    new string[] {"   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   "},
    new string[] {"C#", "Databaser", "Webbutveckling", "Clean code"})]
  [InlineData(
    new string[] {"  Hej på dig. Jag är Ett Test!", "Hej igen.    Detta är en Inkomplett mening"},
    new string[] {"Hej på dig. Jag är ett test!", "Hej igen. Detta är en inkomplett mening"})]
    public void FormatSentencesTest(string[] input, string[] expectedResult)
    {
      // Arrange
      
      // Act
      string[] formattedCourses = WebContentHelper.FormatSentences(input);


      // Assert
      formattedCourses.Should().Equal(expectedResult);
    }

    [Theory]
    [InlineData(HtmlTag.Paragraph, "C#", "<p>C#</p>")]
    [InlineData(HtmlTag.Paragraph,"Databaser", "<p>Databaser</p>")]
    [InlineData(HtmlTag.Paragraph,"Webbutveckling", "<p>Webbutveckling</p>")]
    [InlineData(HtmlTag.Paragraph,"Clean code", "<p>Clean code</p>")]
    [InlineData(HtmlTag.Bold, " Meddelande: ", "<b> Meddelande: </b>")]
    [InlineData(HtmlTag.Heading, " Välkomna Klass A! ", "<h1> Välkomna Klass A! </h1>")]
    public void BuildParagraphTest(HtmlTag tag, string input, string expectedResult)
    {
      // Arrange
      
      // Act
      string result = WebContentHelper.GenerateHtml(tag, input);

      // Assert
      result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData(
      new string[]
      {
        ""
      }, 
      new string[]
      {
        "<!DOCTYPE html>",
        "<html>", "<body>",
        "<main>",
        "",
        "</main>",
        "</body>",
        "</html>",
      })]
    [InlineData(
      new string[]
      {
        "Hej"
      }, 
      new string[]
      {
        "<!DOCTYPE html>",
        "<html>",
        "<body>",
        "<main>",
        "Hej",
        "</main>",
        "</body>",
        "</html>",
      })]
    [InlineData(
      new string[]
      {
        "<h1> Välkomna Klass A! </h1>",
        "<p><b> Meddelande: </b> Glöm inte att övning ger färdighet! </p>",
        "<p><b> Meddelande: </b> Öppna boken på sida 257. </p>", "<p>C#</p>",
        "<p>Databaser</p>",
        "<p>Webbutveckling</p>",
        "<p>Clean code</p>",
      }, 
      new string[]
      {
        "<!DOCTYPE html>",
        "<html>",
        "<body>",
        "<main>",
        "<h1> Välkomna Klass A! </h1>",
        "<p><b> Meddelande: </b> Glöm inte att övning ger färdighet! </p>",
        "<p><b> Meddelande: </b> Öppna boken på sida 257. </p>", "<p>C#</p>",
        "<p>Databaser</p>",
        "<p>Webbutveckling</p>",
        "<p>Clean code</p>",
        "</main>",
        "</body>",
        "</html>",
      })]
    public void WrapHtmlInDocType(string[] input, string[] expectedResult)
    {
      // Arrange
      
      // Act
      string[] result = WebContentHelper.GenerateHtmlWrapper(input);

      // Assert
      result.Should().Equal(expectedResult);
    }
}


// Template
// Arrange
      
      
// Act
      
      
// Assert
