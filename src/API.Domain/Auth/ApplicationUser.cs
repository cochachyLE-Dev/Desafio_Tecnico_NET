using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Auth
{
    public class ApplicationUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }    
}
