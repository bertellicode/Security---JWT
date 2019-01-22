using System.Threading.Tasks;
using Security.Domain.Core.Interfaces;
using Security.Domain.Users.Entities;

namespace Security.Domain.Users.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserIncludeRoles(string user, string password);
    }
}
