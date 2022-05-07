using AutoMapper;
using BookStore.Common;
using BookStore.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.UnitTests.TestsSetup
{//CONTEXT VE MAPPER nesnelerini constructorda oluşturmak için burayı kullanacağız.
    public class CommonTestFixture
    {   
        public BookStoreDbContext _context { get; set; } //Referans olarak BookStore projesini eklediğimiz için ulaşabiliyoruz.
        public IMapper _mapper { get; set; }
        public CommonTestFixture()
        {
            var options=  new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            _context = new BookStoreDbContext(options);

            _context.Database.EnsureCreated();
            _context.AddBook();
            _context.AddGenre();
            _context.SaveChanges();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper(); //Mapleri önceden hazırladığımız mappingProfile'dan alıyor.
        }
    }
}