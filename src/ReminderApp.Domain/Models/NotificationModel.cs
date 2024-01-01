namespace ReminderApp.Domain.Models
{
    public class NotificationPersonModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string DisplayName { get; set; }
    }
    public class NotificationAllModel
    {
        public string[] Emails { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string DisplayName { get; set; }
    }
}
