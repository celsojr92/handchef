using System.Collections.Generic;

namespace HandChef.Shared.Entities
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() { _notifications = new List<Notification>(); }

        public IReadOnlyCollection<Notification> Notifications
        {
            get
            {
                return _notifications;
            }
        }

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public bool IsValid()
        {
            return _notifications.Count == 0;
        }

        public string GetNotifications()
        {
            if (IsValid())
                return string.Empty;

            string ret = string.Empty;

            _notifications.ForEach(x =>
                ret += x.Message + System.Environment.NewLine);

            return ret;
        }
    }
}
