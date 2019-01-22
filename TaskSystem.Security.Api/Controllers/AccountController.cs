using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Interfaces;
using Security.Application.ViewModels;
using Security.Domain.Core.Interfaces;

namespace Security.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public AccountController(INotificationHandler notifications,
                                    IUserAppService userAppService) : base(notifications)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }

            var result = await _userAppService.AutenticateUser(model);

            if (result.Succeeded)
            {
                return Response(result.Token);
            }

            return Response(model);
        }
    }
}
