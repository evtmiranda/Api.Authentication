using Api.Authentication.Domain.Arguments.Response;
using Api.Authentication.Domain.Arguments.Request;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Authentication.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        JwtSecurityToken GetJwtSecurityToken(string user, string issuer, string secretKey);
    }
}
