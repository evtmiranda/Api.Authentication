using Api.Authentication.Domain.Arguments.Request;
using Api.Authentication.Domain.Arguments.Response;
using Api.Authentication.Domain.Interfaces.Repositories;
using Api.Authentication.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Api.Authentication.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.Get(request.Email, request.Password);

            return new AuthenticateResponse();
        }
    }
}
