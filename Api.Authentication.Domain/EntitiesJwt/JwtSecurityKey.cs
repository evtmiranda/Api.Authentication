using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Authentication.Domain.EntitiesJwt
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}
