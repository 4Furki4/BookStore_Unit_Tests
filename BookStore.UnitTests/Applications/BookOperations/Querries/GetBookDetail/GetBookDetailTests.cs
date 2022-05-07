using System;
using AutoMapper;
using BookStore.Applications.BookOperations.Queries.GetBookDetail;
using BookStore.DbOperations;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Querries.GetBookDetailTests
{
    public class GetBookDetailTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public GetBookDetailTests(CommonTestFixture testFixture)
        {
            context=testFixture._context;
            mapper=testFixture._mapper;
        }
        [Fact]
        public void WhenInvalidIdGiven_InvalidOperation_ShouldBeReturned()
        {
            // Arrange
            GetBookDetailQuery query = new(context, mapper);
            query.BookId=10;
            //Act & Assert
            FluentActions.Invoking(()=>query.Handler()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Kitap bulunamadı");
        }
    }
}