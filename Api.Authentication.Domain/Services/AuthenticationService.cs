using Api.Authentication.Domain.Arguments.Request;
using Api.Authentication.Domain.Arguments.Response;
using Api.Authentication.Domain.Interfaces.Repositories;
using Api.Authentication.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Api.Authentication.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.Get(request.Email, request.Password);

            if (user == null)
                return null;

            return new AuthenticateResponse();
        }

        public JwtSecurityToken GetJwtSecurityToken(string user, string issuer, string secretKey)
        {
            return new JwtSecurityToken(
                issuer,
                issuer,
                GetTokenClaims(user),
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256)
            );
        }

        private static IEnumerable<Claim> GetTokenClaims(string user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user)
            };
        }
    }
}
