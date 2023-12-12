namespace ReminderApp.Application.Dtos.Comment
{
    public class AddCommentDto
    {
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; } = 1;
    }
}
