using Newtonsoft.Json;

namespace MCFWebApp.Models
{
    public abstract class ResponseApi
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class SuccessResponse<T> : ResponseApi 
    {
        public T Data { get; set; } 
    }

    public class ErrorResponse : ResponseApi { }
}
