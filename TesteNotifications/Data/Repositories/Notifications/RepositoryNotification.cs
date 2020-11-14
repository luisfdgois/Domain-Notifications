using System.Collections.Generic;

namespace TesteNotifications.Data.Repositories.Notifications
{
    public interface RepositoryNotification
    {
        void AddNotification(Notification notification);
        void AddRangeNotifications(ICollection<Notification> notifications);
        ICollection<Notification> GetNotifications();
        bool HasNotifications();
    }
}
