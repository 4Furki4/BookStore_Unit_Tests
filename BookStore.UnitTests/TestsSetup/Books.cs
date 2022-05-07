using System;
using BookStore.DbOperations;
using BookStore.Entities;

namespace BookStore.UnitTests.TestsSetup
{
    public static class Books
    {
        public static void AddBook(this BookStoreDbContext context)
        {
            context.Books.AddRange( new Book
            {
                Title="Lord Of The Rings",
                GenreId=1,
                PageCount=800,
                PublishDate= new DateTime(2001,11,07),
                AuthorId=1
            },
            new Book
            {
                Title="Incognito",
                GenreId=2,
                PageCount=300,
                PublishDate= new DateTime(2016,6,11),
                AuthorId=2
            },
            new Book
            {
                Title="Our Inner Ape",
                GenreId=2,
                PageCount=400,
                PublishDate= new DateTime(2017,1,18),
                AuthorId=3
            });
        }
    }
}