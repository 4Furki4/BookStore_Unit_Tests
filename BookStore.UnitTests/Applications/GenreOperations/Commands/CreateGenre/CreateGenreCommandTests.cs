using System;
using AutoMapper;
using BookStore.Applications.GenreOperations.Commands.CreateGenre;
using BookStore.DbOperations;
using BookStore.Entities;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture._context;
        }
        [Fact]
        public void WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldReturn()
        {
            //Arrange
            var genre = new Genre(){Name="WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldReturn",
            };
            context.Genres.Add(genre);
            context.SaveChanges();
            CreateGenreCommand command = new(context);
            command.Model=new CreateGenreModel(){Name=genre.Name};

            //Act & Assert
            FluentActions.Invoking(()=>command.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Kitap türü zaten mevcut!");
        }
    }
}