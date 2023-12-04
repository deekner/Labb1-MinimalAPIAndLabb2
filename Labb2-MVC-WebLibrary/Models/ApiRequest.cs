using static Labb2_MVC_WebLibrary.StaticDetails;

namespace Labb2_MVC_WebLibrary.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }

        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
