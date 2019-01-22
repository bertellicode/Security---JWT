using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Security.Domain.Users.Entities;
using Security.Domain.Users.Interfaces.Repositories;
using Security.Infra.Data.Context;

namespace Security.Infra.Data.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context)
        {
        }

        public async Task<User> GetUserIncludeRoles(string user, string password)
        {
            var userDb = DbSet.Include(x => x.RoleList)
                                .ThenInclude(x => x.Role)
                                .FirstOrDefault(x => x.UserName == user
                                                    && x.PasswordHash == password);

            return userDb;
        }
    }
}
