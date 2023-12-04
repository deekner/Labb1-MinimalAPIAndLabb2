using Labb1_MinimalAPI.Models.DTOs;

namespace Labb1_MinimalAPI.Models
{
    public class BookViewModel
    {
        public IEnumerable<BookDTO> BookDTO { get; set; }
        public IEnumerable<Book> Book { get; set; }
    }
}
