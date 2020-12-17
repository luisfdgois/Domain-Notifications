using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;

namespace TesteNotifications.Application.MediatR.Notifications
{
    public class ErrorNotification : INotification
    {
        public IList<ValidationFailure> Validations { get; set; }
    }
}
