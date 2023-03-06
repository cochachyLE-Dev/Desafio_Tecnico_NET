using System.Text.Json.Serialization;

namespace APP.Auth
{
    public class AuthenticationResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("isVerified")]
        public bool IsVerified { get; set; }
        [JsonPropertyName("jwToken")]
        public string? JWToken { get; set; }        
    }
}