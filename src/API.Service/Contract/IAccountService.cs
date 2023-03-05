﻿using API.Domain.Auth;
using API.Domain.Shared;

using System.Threading.Tasks;

namespace API.Service.Contract
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<Response> RegisterAsync(RegisterRequest request);
        Task<Response> ConfirmEmailAsync(string username, string code);
    }
}
