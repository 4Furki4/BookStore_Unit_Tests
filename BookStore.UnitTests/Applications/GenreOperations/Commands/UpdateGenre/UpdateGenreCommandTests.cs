using System;
using AutoMapper;
using BookStore.Applications.GenreOperations.Commands.UpdateGenre;
using BookStore.DbOperations;
using BookStore.Entities;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture._context;
        }
        [Fact]
        public void WhenInvalidGenreGiven_InvalidOperation_ShouldBeReturned()
        {
            //Arrange
            UpdateGenreCommand command= new(context);
            command.GenreId=10;
            //Act & Assert
            FluentActions.Invoking(()=>command.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Kitap türü bulunamadı.");
        }
        [Fact]
        public void WhenAlreadyExistsGenreGiven_InvalidOperation_ShouldBeReturned()
        {
            //Arrange
            UpdateGenreCommand command= new(context);
            command.GenreId=1;
            var genre= new Genre(){Name="WhenAlreadyExistsGenreGiven_InvalidOperation_ShouldBeReturned"};
            context.Genres.Add(genre);
            context.SaveChanges();
            command.Model=new(){Name=genre.Name};
            //Act & Assert
            FluentActions.Invoking(()=>command.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Aynı isimde bir kitap türü zaten mevcut!");
        }
    }
}