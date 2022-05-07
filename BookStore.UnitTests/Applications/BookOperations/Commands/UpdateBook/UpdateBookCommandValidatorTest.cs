using System;
using System.Linq;
using BookStore.Applications.BookOperations.Commands.CreateBook;
using BookStore.Applications.BookOperations.Commands.UpdateBook;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest  : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("s",1,0)]
        [InlineData("s",0,1)]
        [InlineData("Suç ve Ceza",0,0)]
        [InlineData("Suç ve Ceza",1,0)]
        [InlineData("Suç ve Ceza",0,1)]
        [InlineData("s",1,1)]
       // [InlineData("Suç ve Ceza",1,1)]
        public void WhenInvalidInputAreGiven_UpdateValidator_ShouldReturnErrors(string title, int bookId, int genreId)
        {
            //Arrange
            UpdateBookCommand command = new(null);
            command.BookId=bookId;
            command.Model= new(){Title=title,GenreId=genreId};
            UpdateBookCommandValidator validations = new();
            //Act
            var result= validations.Validate(command);
            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}