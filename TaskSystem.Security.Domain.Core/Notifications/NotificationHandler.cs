using System;
using System.Collections.Generic;
using System.Linq;
using Security.Domain.Core.Interfaces;

namespace Security.Domain.Core.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public virtual List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification message)
        {
            _notifications.Add(message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: {message.Key} - {message.Value}");
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
