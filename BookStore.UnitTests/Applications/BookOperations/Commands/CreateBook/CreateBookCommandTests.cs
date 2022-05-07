using System;
using System.Linq;
using AutoMapper;
using BookStore.Applications.BookOperations.Commands.CreateBook;
using BookStore.DbOperations;
using BookStore.Entities;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture) //CommonTestFixture'daki inşa edici metotta yaptığımız configleri almamızı sağlıyor.
        {
            context=testFixture._context; //bu ayarlamaları yapılmış context ve mapper ı atıyoruz.
            mapper=testFixture._mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn()
        {
            // arrange 
            var book= new Book()
            {Title="Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn",
            PageCount=100, PublishDate= new DateTime(1999,2,12),GenreId=1,AuthorId=1
            };
            context.Books.Add(book);
            context.SaveChanges();
            CreateBookCommand command = new(context,mapper);
            command.Model= new CreateBookModel(){Title=book.Title};
            // act & assert
            FluentActions.Invoking(()=>command.Handler())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut!");
            //assert

        }
        [Fact]
        public void WhenInvalidInputsAreGiven_Book_ShouldBeCreated() //HappyCase
        {
            //Arrange
            CreateBookCommand command = new(context,mapper);
            var model =new CreateBookModel(){Title="Hobbit",GenreId=1,PageCount=1000,PublishDate= DateTime.Now.Date.AddYears(-10)};
            command.Model= model;
            //Act
            FluentActions.Invoking(() => command.Handler()).Invoke(); //Metodun çalışması için sonuna ivoke metodu eklenmeli, öncesinde should bu görevi görüyordu.
            //Assert
            var book= context.Books.SingleOrDefault(x=>x.Title==command.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(command.Model.PageCount);
            book.PublishDate.Should().Be(command.Model.PublishDate);
            book.GenreId.Should().Be(command.Model.GenreId);

        } 
    }
}