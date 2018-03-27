using Api.Authentication.Domain.Arguments.Response;
using Api.Authentication.Domain.Arguments.Request;
using System.Threading.Tasks;

namespace Api.Authentication.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}
