namespace ReminderApp.Domain.Entities.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool isActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
