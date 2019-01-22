using System.Threading.Tasks;
using Security.Domain.Users.DTOs;
using Security.Domain.Users.Entities;

namespace Security.Domain.Users.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string usuer, string password);
        Task<TokenDto> GenerateToken(User user);
    }
}
