using System.Collections.Generic;
using FluentValidation.Results;

namespace Security.Domain.Core.Interfaces
{
    public interface IService
    {
        void NotificarValidacoesErro(ValidationResult validationResult);

        void NotificarValidacao(string propertyName = null, string errorMessage = null);

        bool HasNotifications();

        bool ValidateObjectIsNotNull<T>(T obj, string msg);

        bool ValidateListIsNotNull<T>(IEnumerable<T> obj, string msg);
    }
}
