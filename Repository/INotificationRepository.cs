using System.Collections.Generic;
using mvcdemo.Models;

namespace mvcdemo.Repository{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void Create(Notification notification, int petId);
        void ReadNotification(int notificationId, string userId);
    }
}