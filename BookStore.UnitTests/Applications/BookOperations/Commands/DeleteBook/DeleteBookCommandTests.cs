using System;
using BookStore.Applications.BookOperations.Commands.DeleteBook;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;
        public int BookId { get; set; }
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            context=testFixture._context;
            BookId=4;
        }
        [Fact]
        public void WhenInvalidBookIdGiven_InvalidOperation_ShouldBeReturned()
        {
            //Arrange
            
            DeleteBookCommand command = new(context);
            command.BookId=BookId;

            //Act & Assert
            FluentActions.Invoking(()=>command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı.");
        }
    }
}