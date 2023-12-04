namespace Labb2_MVC_WebLibrary.Models
{
    public class ResponseDTO
    {
        public bool isSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
