using System;
using System.Collections.Generic;
using System.Linq;

namespace prmToolkit.Notification
{
    public static class NotificationManager
    {
        public static void Start()
        {
            _notifications = new List<Notification>();
        }

        public static void End()
        {
            _notifications = null;
        }

        private static List<Notification> _notifications;
        public static IReadOnlyCollection<Notification> Notifications
        {
            get
            {
                if (_notifications == null) return new List<Notification>();
                return _notifications;
            }
        }

        public static void AddNotification(Notification notification)
        {
            if (_notifications == null) return;

            if (notification != null)
                _notifications.Add(notification);
        }

        public static void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            if (_notifications == null) return;

            if (notifications != null)
                _notifications.AddRange(notifications);
        }

        public static bool IsValid()
        {
            if (_notifications == null) return true;
            return !_notifications.Any();
        }

        public static List<Notification> GetNotifications()
        {
            return _notifications;
        }

        //public static bool IsValid(Guid entity)
        //{
        //    if (_notifications == null) return true;

        //    foreach (var item in _notifications)
        //    {
        //        if (string.Equals(item.Entity.ToString(), entity.ToString(), StringComparison.OrdinalIgnoreCase))
        //            return false;
        //    }

        //    return true;
        //}
    }
}