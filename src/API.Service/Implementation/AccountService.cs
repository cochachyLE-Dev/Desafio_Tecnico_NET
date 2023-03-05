using API.Domain.Auth;
using API.Domain.Common;
using API.Domain.Settings;
using API.Domain.Shared;
using API.Persistence.Seeds;
using API.Service.Contract;
using API.Service.Exceptions;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly JWTSettings _jwtSettings;
        public AccountService(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {            
            // Basic Sample
            var user = DefaultUsers.UserList().Where(c => c.Email == request.Email).FirstOrDefault();

            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {request.Email}");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            AuthenticationResponse authResponse = new AuthenticationResponse();
            authResponse.Id = user.Id.ToString();
            authResponse.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authResponse.Email = user.Email;
            authResponse.UserName = user.UserName;
            authResponse.IsVerified = user.IsVerified;
            
            return Response<AuthenticationResponse>.Success(authResponse);
        }

        public Task<Response> ConfirmEmailAsync(string username, string code)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            // Basic Sample
            return await Task.Run<JwtSecurityToken>(() =>
            {
                string ipAddress = IpHelper.GetIpAddress();
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim("ip",ipAddress)
                };

                var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
                var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: signingCredentials);

                return jwtSecurityToken;
            });
        }
    }
}
