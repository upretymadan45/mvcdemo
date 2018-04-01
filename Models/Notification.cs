using System.Collections.Generic;

namespace mvcdemo.Models{
    public class Notification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
    }
}