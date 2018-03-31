using Api.Authentication.Domain.Entities;
using Api.Authentication.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Api.Authentication.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(string email, string password)
        {
            if (email != "admin")
                return null;

            return new User();
        }
    }
}
