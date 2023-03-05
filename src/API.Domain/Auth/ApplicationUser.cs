using System;
using System.Collections.Generic;

namespace API.Domain.Auth
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsVerified { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }    
}
