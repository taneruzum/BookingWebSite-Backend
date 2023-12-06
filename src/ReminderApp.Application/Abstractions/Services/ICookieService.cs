namespace ReminderApp.Application.Abstractions.Services
{
    public interface ICookieService
    {
        string GetCookieValue(string key);
        void AddCookieValue(string key, string value);
        void DeleteCoolie(string key);

        void UpdateCookieValue(string key, string newValue);
    }
}
