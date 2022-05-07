using BookStore.Applications.GenreOperations.Commands.DeleteGenre;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests :IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10000)]

        public void WhenInvalidInputsGiven_DeleteValidator_ShouldThrowErrors(int Id)
        {
            // Arrange
            DeleteGenreCommand command = new(null);
            DeleteGenreCommandValidator validations = new();
            command.GenreId=Id;

            //Act & Assert
            validations.Validate(command).Errors.Count.Should().BeGreaterThan(0);
        }
    }
}