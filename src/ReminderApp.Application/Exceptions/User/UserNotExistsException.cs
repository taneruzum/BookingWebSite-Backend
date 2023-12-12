using System.Runtime.Serialization;

namespace ReminderApp.Application.Exceptions.User
{
    [Serializable]
    public class UserNotExistsException : Exception
    {
        public string Username { get; }

        public UserNotExistsException()
            : base($"User not exists !")
        {
        }

        public UserNotExistsException(string username)
            : base($"User '{username}' not exists !")
        {
            Username = username;
        }

        public UserNotExistsException(string username, string message)
            : base(message)
        {
            Username = username;
        }

        public UserNotExistsException(string username, string message, Exception inner)
            : base(message, inner)
        {
            Username = username;
        }

        protected UserNotExistsException(
          SerializationInfo info,
          StreamingContext context) : base(info, context)
        {
            Username = info.GetString("Username")!;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Username", Username);
        }
    }
}
