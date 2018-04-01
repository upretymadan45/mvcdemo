namespace mvcdemo.Models{
    public class NotificationApplicationUser
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool IsRead { get; set; } = false;
    }
}