namespace ReminderApp.Domain.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string StatusPhrase { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
