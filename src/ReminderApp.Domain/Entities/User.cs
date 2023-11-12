using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string Fullname { get; set; } = "_-NONE-_";
        public string Email { get; set; }
        public string Password { get; set; }


        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }


        public List<ImageUser>? ImageUsers { get; set; }
    }
}
