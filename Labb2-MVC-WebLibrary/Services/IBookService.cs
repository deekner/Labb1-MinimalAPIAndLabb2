using Labb1_MinimalAPI.Models.DTOs;

namespace Labb2_MVC_WebLibrary.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetSingleBook<T>(Guid Id);
        Task<T> CreateBookAsync<T>(BookCreateDTO bookCreateDTO);
        Task<T> UpdateBookAsync<T>(BookDTO BookDTO);
        Task<T> DeleteBookAsync<T>(Guid Id);
    }
}
