namespace ReminderApp.Domain.Models
{
    public class NotificationPersonModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
    public class NotificationAllModel
    {
        public string[] Emails { get; set; }
        public string Message { get; set; }
    }

}
