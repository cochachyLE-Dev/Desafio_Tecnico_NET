using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Domain.Shared
{
    public class Response
    {
        public bool Successed { get; set; }
        public StatusCode Code { get; set; }
        public string? Message { get; set; }
        public static Response Fail(StatusCode statusCode, string message)
        {
            return new Response()
            {
                Successed = false,
                Code = statusCode,
                Message = message
            };
        }
    }
    public class Response<TEntity> : Response
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TEntity? Entity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<TEntity>? List { get; set; }
    }
    public enum StatusCode
    {
        OK = 0,
        InternalError = 3
    }
}