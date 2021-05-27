using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteNotifications.Application.MediatR.Notifications;
using TesteNotifications.Domain.Global.Notifier.DataTypes.Error;
using TesteNotifications.Domain.Global.Notifier.Queues.Error;

namespace TesteNotifications.Application.MediatR.Handlers
{
    public class ErrorNotificationHandler : INotificationHandler<ErrorNotification>
    {
        private readonly IErrorQueue _errorQueue;

        public ErrorNotificationHandler(IErrorQueue errorQueue)
        {
            _errorQueue = errorQueue;
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            var messages = notification.Validations.Select(v => new ErrorMessage(v.PropertyName, v.ErrorMessage)).ToList();

            messages.ForEach(error =>
            {
                _errorQueue.Insert(error);
            });

            return Task.CompletedTask;
        }
    }
}
