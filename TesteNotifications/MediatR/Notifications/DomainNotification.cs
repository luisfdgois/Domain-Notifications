using FluentValidation.Results;
using MediatR;

namespace TesteNotifications.MediatR.Notifications
{
    public class DomainNotification : INotification
    {
        public ValidationResult Validation { get; private set; }

        public DomainNotification(ValidationResult validation)
        {
            Validation = validation;
        }
    }
}
