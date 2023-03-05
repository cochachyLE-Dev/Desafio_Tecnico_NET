using API.Service.Contract;

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

namespace API.Service.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value;
            Username = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Email = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
        }
        public string? UserId { get; }
        public string? Username { get; }
        public string? Email { get; }
        public List<KeyValuePair<string, string>>? Claims { get; }
    }
}
