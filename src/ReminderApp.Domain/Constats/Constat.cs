using ReminderApp.Domain.Entities;

namespace ReminderApp.Domain.Constats
{
    public static class Constat
    {
        public static string ApplicationName = "ReminderApp.Api";
        public static string Version = "v1";
        public static string Description = "BasketApi version1 project";
    }

    public static class TableNames
    {
        public static string Users = $"{nameof(User)}s";
        public static string HubConnections = $"{nameof(HubConnection)}s";
        public static string Notifications = $"{nameof(Notification)}s";
        public static string Meetings = $"{nameof(Meeting)}s";
        public static string MeetingItem = $"{nameof(MeetingItem)}s";
        public static string Images = $"{nameof(Image)}s";
        public static string ImageUsers = $"{nameof(ImageUser)}s";
    }

    public static class TableProperty
    {
        public static string email = "email";
    }

    public static class Time
    {
        public static DateTime GetNowGet = DateTime.Now;
    }

    public static class RegexPattern
    {
        public static string EmailFormat = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
        public static string UppercaseLetter = @"[^A-Za-zğüşöçıİĞÜŞÖÇ]";
    }

    public static class Channels
    {
        public static string NotificationHub = "notificationHub";
        public static string UserHub = "userHub";
    }

    public static class Claims
    {
        public static string Email = "Email";
    }

    public static class FilePaths
    {
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string parentDirectory = Directory.GetParent(currentDirectory).FullName;
        private static string logsPath = Path.Combine(parentDirectory, "Logs".TrimStart('\\', '/'));
        private static IEnumerable<string> txtFiles = Directory.EnumerateFiles(logsPath, "*.txt");

        public static List<string> txtLogFiles = txtFiles.ToList();
    }

    public class Roles
    {
        public const string UserRole = "User";
    }
}
