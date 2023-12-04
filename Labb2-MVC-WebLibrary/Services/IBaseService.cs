using Labb2_MVC_WebLibrary.Models;

namespace Labb2_MVC_WebLibrary.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
