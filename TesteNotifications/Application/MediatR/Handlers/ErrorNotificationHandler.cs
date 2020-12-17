using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteNotifications.Application.Contracts;
using TesteNotifications.Application.DataStructure;
using TesteNotifications.Application.MediatR.Notifications;

namespace TesteNotifications.Application.MediatR.Handlers
{
    public class ErrorNotificationHandler : INotificationHandler<ErrorNotification>
    {
        private readonly ErrorRepository _repository;

        public ErrorNotificationHandler(ErrorRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            var messages = notification.Validations.Select(v => new ErrorMessage(v.PropertyName, v.ErrorMessage)).ToList();

            foreach (var message in messages)
            {
                _repository.Add(message);
            }

            return Task.CompletedTask;
        }
    }
}
