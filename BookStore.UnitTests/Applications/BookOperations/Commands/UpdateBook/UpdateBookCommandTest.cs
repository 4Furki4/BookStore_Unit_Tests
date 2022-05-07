using System;
using System.Linq;
using BookStore.Applications.BookOperations.Commands.UpdateBook;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly UpdateBookModel Model;
        public int BookId { get; set; }
        public UpdateBookCommandTest(CommonTestFixture testFixture)
        {
            context=testFixture._context;
        }
        [Fact]
        public void WhenMissingBookIdGiven_InvalidOperation_ShouldBeReturned()
        {
            //Arrange
            BookId=10;
            UpdateBookCommand command = new(context);
            command.Model= new UpdateBookModel(){Title="sadfadsfas", GenreId=2};
            //Act & Assert
            FluentActions.Invoking(()=> command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap bulunamadı.");

        }
    }
}