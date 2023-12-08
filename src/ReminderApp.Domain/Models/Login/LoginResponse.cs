namespace ReminderApp.Domain.Models.Login
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
