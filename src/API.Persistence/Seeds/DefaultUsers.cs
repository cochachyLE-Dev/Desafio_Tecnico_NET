using API.Domain.Auth;

using System;
using System.Collections.Generic;

namespace API.Persistence.Seeds
{
    public static class DefaultUsers
    {
        public static List<ApplicationUser> UserList()
        {
            return new List<ApplicationUser> { 
                new ApplicationUser{
                    Id = Guid.NewGuid(),
                    FirstName = "asesor",
                    LastName = "comercial",
                    Email = "basicuser@vaetech.net",
                    UserName = "basicuser",
                    IsVerified = true
                }
            };
        }
    }
}
