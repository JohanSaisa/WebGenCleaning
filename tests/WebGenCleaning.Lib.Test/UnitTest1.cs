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
    [InlineData("C#", "<p>C#</p>")]
    [InlineData("Databaser", "<p>Databaser</p>")]
    [InlineData("Webbutveckling", "<p>Webbutveckling</p>")]
    [InlineData("Clean code", "<p>Clean code</p>")]
    public void BuildParagraphTest(string input, string expectedResult)
    {
      // Arrange
      
      // Act
      string result = WebContentHelper.GenerateParagraph(input);

      // Assert
      result.Should().Be(expectedResult);
    }
}


// Template
// Arrange
      
      
// Act
      
      
// Assert
