using System.Text.Json.Serialization;

namespace APP.Shared
{
    public class Response
    {
        [JsonPropertyName("successed")]
        public bool Successed { get; set; }
        [JsonPropertyName("code")]
        public StatusCode Code { get; set; }
        [JsonPropertyName("message")]
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
        public static Response Success(string message)
        {
            return new Response()
            {
                Successed = true,
                Code = StatusCode.OK,
                Message = message
            };
        }
    }
    public class Response<TEntity> : Response
    {
        [JsonPropertyName("entity")]
        public TEntity? Entity { get; set; }
        [JsonPropertyName("list")]
        public IEnumerable<TEntity>? List { get; set; }

        public static new Response<TEntity> Fail(StatusCode statusCode, string? message = null)
        {
            return new Response<TEntity>()
            {
                Successed = false,
                Code = statusCode,
                Message = message
            };
        }
        public static Response<TEntity> Success(IEnumerable<TEntity> list, string? message = null)
        {
            return new Response<TEntity>()
            {
                Successed = true,
                Code = StatusCode.OK,
                Message = message,
                List = list
            };
        }
        public static Response<TEntity> Success(TEntity entity, string? message = null)
        {
            return new Response<TEntity>()
            {
                Successed = true,
                Code = StatusCode.OK,
                Message = message,
                Entity = entity
            };
        }
    }
    public enum StatusCode
    {
        OK = 0,
        InternalError = 3,
        PermissionDenied = 4,
        InvalidArgument = 5,
        Unauthenticated = 6,
        NotImplemented = 7,
        Aborted = 10,
        Unavailable = 14
    }
}