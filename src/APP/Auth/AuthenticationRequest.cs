namespace APP.Auth
{
    public class AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public string? TwoFactorCode { get; set; }
    }
}
