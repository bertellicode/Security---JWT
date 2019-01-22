using System.Collections.Generic;
using Security.Domain.Core.Notifications;

namespace Security.Domain.Core.Interfaces
{
    public interface INotificationHandler
    {
        List<Notification> GetNotifications();

        void Handle(Notification message);

        bool HasNotifications();
    }
}
