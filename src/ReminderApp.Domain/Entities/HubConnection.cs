using ReminderApp.Domain.Entities.Base;
using ReminderApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("HubConnections")]
    public class HubConnection : BaseModel
    {
        public string ConnectionId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ConnectionType ConnectionType { get; set; }
    }
}
