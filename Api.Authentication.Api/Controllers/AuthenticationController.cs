using Microsoft.AspNetCore.Mvc;
using System;
using Api.Authentication.Domain.Interfaces.Services;
using Api.Authentication.Domain.Arguments.Request;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Api.Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public static IConfiguration Configuration { get; set; }
        readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="request">User informations</param>
        /// <returns>String</returns>
        [ProducesResponseType(typeof(string), 200)]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateRequest request)
        {
            try
            {
                var user = await _authenticationService.Authenticate(request);

                if (user == null)
                    return Unauthorized();

                string issuer = $"{Configuration["Security:Issuer"]}";
                string secretKey = $"{Configuration["Security:SecretKey"]}";

                var token = _authenticationService.GetJwtSecurityToken(request.Email, issuer, secretKey);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
