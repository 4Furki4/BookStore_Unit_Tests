using BookStore.Applications.GenreOperations.Commands.UpdateGenre;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData("q")]
        [InlineData("qw")]
        [InlineData("qwe")]
        public void WhenInvalidInputsAreGıven_UpdateValidator_ShouldReturnErrors(string name)
        {
            //Arrange
            UpdateGenreCommand command = new(null);
            UpdateGenreModel model = new(){Name=name};
            command.Model=model;
            UpdateGenreCommandValidator validation= new();
            
            // Act
            var result = validation.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
    }
}