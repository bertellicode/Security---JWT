using System.Threading.Tasks;
using Security.Application.ViewModels;

namespace Security.Application.Interfaces
{
    public interface IUserAppService : IAppService
    {
        Task<LoginReturnViewModel> AutenticateUser(LoginViewModel model);
    }
}
