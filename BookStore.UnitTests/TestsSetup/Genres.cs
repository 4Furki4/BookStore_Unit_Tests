using BookStore.DbOperations;
using BookStore.Entities;

namespace BookStore.UnitTests.TestsSetup
{
    public static class Genres
    {
        public static void AddGenre(this BookStoreDbContext context)
        {
            context.Genres.AddRange
                (
                    new Genre
                    {
                        Name="Personal Growth",

                    },
                    new Genre
                    {
                        Name="Sciene Fiction"
                    },
                    new Genre
                    {
                        Name="Novel"
                    }
                );
            
        }
    }
}