using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Domain.Auth
{
    public class AuthenticationResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UserName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Roles { get; set; }
        public bool IsVerified { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? JWToken { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
    }
}