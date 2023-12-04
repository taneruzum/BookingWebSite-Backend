using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Comments")]
    public class Comment : BaseModel
    {
        public string UserComment { get; set; }
        public int Star { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
