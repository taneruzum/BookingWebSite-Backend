using Microsoft.AspNetCore.Http;

namespace ReminderApp.Application.Dtos.Comment
{
    public class AllCommentDto
    {
        public string UserName { get; set; }
        public int Star { get; set; }
        public string UserComment { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
