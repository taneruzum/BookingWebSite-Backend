namespace ReminderApp.Application.Dtos.User
{
    public class AllUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
