namespace ReminderApp.Application.Extensions
{
    public static class EmailFormatExtension
    {
        public static string EmailShort(this string email)
        {
            string[] splitEmail = email.Split('@');
            return splitEmail[0];
        }
    }
}
