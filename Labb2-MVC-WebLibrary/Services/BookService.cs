using Labb1_MinimalAPI.Models.DTOs;

namespace Labb2_MVC_WebLibrary.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            this._clientFactory = clientFactory;
        }


        public async Task<T> CreateBookAsync<T>(BookCreateDTO bookCreateDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = bookCreateDTO,
                Url = StaticDetails.BookApiBase + "/api/book/",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(Guid Id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/book/" + Id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetSingleBook<T>(Guid Id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/"+Id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(BookDTO BookDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = BookDTO,
                Url = StaticDetails.BookApiBase + "/api/book/",
                AccessToken = ""
            });
        }
    }
}
