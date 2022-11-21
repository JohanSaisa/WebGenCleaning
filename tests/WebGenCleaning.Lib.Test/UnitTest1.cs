using FluentAssertions;

namespace WebGenCleaning.Lib.Test;

public class UnitTest1
{
    [Fact]
    public void FormatSentencesTest()
    {
      // Arrange
      string[] coursesFromApi = {"   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   "};
      string[] expectedCourses = {"C#", "Databaser", "Webbutveckling", "Clean code"};
      
      // Act
      string[] formattedCourses = WebContentHelper.FormatSentences(coursesFromApi);


      // Assert
      formattedCourses.Should().Equal(expectedCourses);
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
