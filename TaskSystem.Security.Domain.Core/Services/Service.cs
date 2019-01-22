using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Security.Domain.Core.Interfaces;
using Security.Domain.Core.Notifications;

namespace Security.Domain.Core.Services
{
    public class Service : IService
    {

        private readonly INotificationHandler _notificationHandler;

        public Service(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notificationHandler.Handle(new Notification(error.PropertyName, error.ErrorMessage));
            }
        }

        public void NotificarValidacao(string propertyName = null, string errorMessage = null)
        {
            _notificationHandler.Handle(new Notification(propertyName, errorMessage));
        }

        public bool HasNotifications()
        {
            return _notificationHandler.HasNotifications();
        }

        public bool ValidateObjectIsNotNull<T>(T obj, string msg)
        {
            var objIsValid = obj != null;

            if (!objIsValid)
                NotificarValidacao(string.Empty, msg);

            return objIsValid;
        }

        public bool ValidateListIsNotNull<T>(IEnumerable<T> obj, string msg)
        {
            var objIsValid = obj != null && !obj.Any();

            if (!objIsValid)
                NotificarValidacao(string.Empty, msg);

            return objIsValid;
        }
    }
}
