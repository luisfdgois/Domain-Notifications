using System.Collections.Generic;
using System.Linq;

namespace TesteNotifications.Data.Repositories.Notifications
{
    public class RepositoryNotificationImp : RepositoryNotification
    {
        private ICollection<Notification> _notifications;

        public RepositoryNotificationImp()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddRangeNotifications(ICollection<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                _notifications.Add(notification);
            }
        }

        public ICollection<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
