using API.Domain.Auth;
using API.Domain.Shared;
using API.Service.Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Implementation
{
    public class AccountService : IAccountService
    {
        public Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> ConfirmEmailAsync(string username, string code)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
