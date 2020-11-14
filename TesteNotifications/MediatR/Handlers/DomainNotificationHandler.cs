using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteNotifications.Data.Repositories.Notifications;
using TesteNotifications.MediatR.Notifications;

namespace TesteNotifications.MediatR.Handlers
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private readonly RepositoryNotification _repositoryNotification;

        public DomainNotificationHandler(RepositoryNotification repositoryNotification)
        {
            _repositoryNotification = repositoryNotification;
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            var notifications = notification.Validation.Errors.Select(v => new Notification(v.PropertyName, v.ErrorMessage)).ToList();

            _repositoryNotification.AddRangeNotifications(notifications);

            return Task.CompletedTask;
        }
    }
}
