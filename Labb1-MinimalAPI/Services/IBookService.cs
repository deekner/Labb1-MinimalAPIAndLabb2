using Labb1_MinimalAPI.Models;

namespace Labb1_MinimalAPI.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetSingleBook(Guid id);
        public Task<Book> AddBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task<Book> DeleteBook(Guid id);
    }
}
