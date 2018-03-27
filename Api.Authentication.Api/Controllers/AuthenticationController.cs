using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Api.Authentication.Domain.Interfaces.Services;
using Api.Authentication.Domain.Arguments.Request;
using Api.Authentication.Domain.Arguments.Response;

namespace Api.Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController
    {
        readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request">User informations</param>
        /// <returns>AuthenticateResponse</returns>
        [ProducesResponseType(typeof(AuthenticateResponse), 200)]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateRequest request)
        {
            try
            {
                var response = await _authenticationService.Authenticate(request);

                return new OkObjectResult(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
