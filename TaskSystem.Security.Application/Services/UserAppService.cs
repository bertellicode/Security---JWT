using System.Threading.Tasks;
using AutoMapper;
using Security.Application.Interfaces;
using Security.Application.ViewModels;
using Security.Domain.Core.Interfaces;
using Security.Domain.Users.Interfaces.Services;

namespace Security.Application.Services
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserService _userService;


        public UserAppService(IUnitOfWork unitOfWork, 
                                INotificationHandler notificationHandler,
                                IMapper mapper,
                                IUserService userService) : base(unitOfWork, notificationHandler, mapper)
        {
            _userService = userService;
        }

        public async Task<LoginReturnViewModel> AutenticateUser(LoginViewModel model)
        {
            var result = await _userService.GetUser(model.User, model.Password);

            if (result != null)
            {
                var response = _userService.GenerateToken(result);

                return _mapper.Map<LoginReturnViewModel>(response);
            }

            return new LoginReturnViewModel();
        }
    }
}
