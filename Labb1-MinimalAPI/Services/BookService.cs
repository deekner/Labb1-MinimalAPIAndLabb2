using Labb1_MinimalAPI.Data;
using Labb1_MinimalAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace Labb1_MinimalAPI.Services
{
    public class BookService : IBookService
    {

        private readonly BooksDbContext _appDbContext;

        public BookService(BooksDbContext appDbContext)
        {
            _appDbContext = appDbContext;  
        }

        public async Task<Book> AddBook(Book book)
        {
            await _appDbContext.books.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(Guid Id)
        {
            var book = await _appDbContext.books.FindAsync(Id);
            _appDbContext.books.Remove(book);
            await _appDbContext.SaveChangesAsync();
            return book;
            
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _appDbContext.books.ToListAsync();
        }

        public async Task<Book> GetSingleBook(Guid id)
        {
            var book = await _appDbContext.books.FindAsync(id);
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _appDbContext.books.Update(book);
            await _appDbContext.SaveChangesAsync();
            return book;

        }
    }
}
