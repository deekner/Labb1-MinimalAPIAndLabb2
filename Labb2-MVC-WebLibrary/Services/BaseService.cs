using Labb2_MVC_WebLibrary.Models;
using Newtonsoft.Json;
using System.Text;

namespace Labb2_MVC_WebLibrary.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO responseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient;
            this.responseModel = new ResponseDTO();
        }

      
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("Labb2BookAPI");
                HttpRequestMessage Message = new HttpRequestMessage();
                Message.Headers.Add("Accept", "application/json");
                Message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    Message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case StaticDetails.ApiType.GET:
                        Message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        Message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        Message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        Message.Method = HttpMethod.Delete;
                        break;

                }

                apiResponse = await client.SendAsync(Message);

                if (apiResponse.Content.Headers.ContentType?.MediaType == "application/json")
                {
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent); //Here we Deserielize
                    return apiResponseDTO;
                }
                else
                {
                    return default(T);
                }
                
                
            }

            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string>
                    {
                        Convert.ToString(e.Message)
                    },
                    isSuccess = false
                };

                var response = JsonConvert.SerializeObject(dto);
                var apiRespDTO = JsonConvert.DeserializeObject<T>(response);
                return apiRespDTO;
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
