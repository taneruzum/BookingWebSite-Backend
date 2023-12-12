using Microsoft.AspNetCore.Http;

namespace ReminderApp.Domain.Models
{
    public class FileUpload
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public IFormFile File { get; set; }
    }
}
