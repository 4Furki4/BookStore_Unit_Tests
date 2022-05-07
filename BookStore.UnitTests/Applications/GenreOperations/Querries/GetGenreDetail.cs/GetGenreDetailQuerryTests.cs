using System;
using BookStore.Applications.GenreOperations.Queries.GetGenreDetail;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.GenreOperations.Querries.GetGenreDetail.cs
{
    public class GetGenreDetailQuerryTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;

        public GetGenreDetailQuerryTests(CommonTestFixture testFixture)
        {
            context=testFixture._context;
        }

        [Fact]
        public void WhenInvalidBookIdGiven_InvalidOperaion_ShouldBeThrown()
        {
            //Arrange
            GetGenreDetailsQuery query = new(context,null);
            query.GenreId=10;
            
            //Act & Assert
            FluentActions.Invoking(()=>query.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Kitap bulunamadı.");
        }
    }
}