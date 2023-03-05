using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Domain.Shared
{
    public class Response
    {
        public bool Successed { get; set; }
        public StatusCode Code { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TEntity? Entity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
        Unauthenticated = 6
    }
}