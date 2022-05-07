using System;
using AutoMapper;
using BookStore.Applications.BookOperations.Commands.CreateBook;
using BookStore.DbOperations;
using BookStore.Entities;
using BookStore.UnitTests.TestsSetup;
using FluentAssertions;
using Xunit;

namespace BookStore.UnitTests.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests :IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("Lord of The Rings",0,0)]
        [InlineData("Lord of The Rings",0,1)]
        [InlineData("Lord of The Rings",1,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("Lor",100,1)]
        [InlineData("Lord",100,1)]
        [InlineData("Lord",100,0)]
        [InlineData("Lord",0,1)]
        [InlineData(" ",100,1)]
        public void WhenInvalidInputAreGiven_CreateValidator_ShouldReturnErrors(string title, int pageCount,int genreId)
        {
            //Arrange
           CreateBookCommand command= new(null,null);
           command.Model=new CreateBookModel(){Title=title,PageCount=pageCount,PublishDate=DateTime.Now.Date.AddYears(-1),GenreId=genreId};
           //Act
           CreateBookCommandValidator validations = new();
           var result= validations.Validate(command);
           //Assert
           result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenDateTimeEqualNullIsGıven_Validator_ShouldReturnError()
        {
            CreateBookCommand command= new(null,null);
           command.Model=new CreateBookModel(){Title="asddasddads",PageCount=122,PublishDate=DateTime.Now.Date,GenreId=2};
           CreateBookCommandValidator validations = new();
           var result= validations.Validate(command);
           result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}