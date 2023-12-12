using System.Reflection;

namespace ReminderApp.Infrastructure
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
