using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Security.Domain.Core.Interfaces;
using Security.Domain.Core.Notifications;

namespace Security.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificationHandler _notifications;

        protected BaseController(INotificationHandler notifications)
        {
            _notifications = (NotificationHandler)notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected IActionResult ResponseStatusCode(HttpStatusCode statusCode, object result = null)
        {
            return StatusCode(statusCode.GetHashCode(), new
            {
                data = result,
                errors = _notifications.GetNotifications().Select(x => x.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _notifications.Handle(new Notification(codigo, mensagem));
        }

        protected bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }

        
    }
}
