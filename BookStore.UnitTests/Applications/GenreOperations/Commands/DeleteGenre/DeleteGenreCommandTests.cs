using System;
using BookStore.Applications.GenreOperations.Commands.DeleteGenre;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;

        public DeleteGenreCommandTests(CommonTestFixture testFixtures)
        {
            context=testFixtures._context;
        }

        [Fact]
        public void WhenInvalidGenreGiven_InvalidOperation_ShouldBeThrown()
        {
            // Arrange
            DeleteGenreCommand command = new(context);
            command.GenreId=10;

            // Act & Assert
            FluentActions.Invoking(()=>command.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Silinecek kitap türü bulunamadı.");
        }
    }
}