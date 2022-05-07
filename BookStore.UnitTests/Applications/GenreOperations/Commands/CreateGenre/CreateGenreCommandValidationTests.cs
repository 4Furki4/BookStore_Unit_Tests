using BookStore.Applications.GenreOperations.Commands.CreateGenre;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidationTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("1")]
        [InlineData("s")]
        [InlineData("A")]
        [InlineData("")]

        public void WhenInvalidInputsAreGiven_CreateValidator_ShouldReturnErrors(string name)
        {
            //Arrange
            CreateGenreCommand command= new(null);
            command.Model=new(){Name=name};
            CreateGenreCommandValidator validations = new();
            //Act & Assert
            validations.Validate(command).Errors.Count.Should().BeGreaterThan(0);
        }
    }
}