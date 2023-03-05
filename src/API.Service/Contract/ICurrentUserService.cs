using System.Collections.Generic;

namespace API.Service.Contract
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Username { get; }
        string? Email { get; }

        List<KeyValuePair<string, string>>? Claims { get; }
    }
}
