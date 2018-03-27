using Api.Authentication.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Authentication.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string email, string password);
    }
}
