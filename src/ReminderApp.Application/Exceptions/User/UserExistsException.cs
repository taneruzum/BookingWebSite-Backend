using System.Runtime.Serialization;

namespace ReminderApp.Application.Exceptions.User
{
    [Serializable]
    public class UserAlreadyExistsException : Exception
    {
        public string Username { get; }

        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string username)
            : base($"User '{username}' alread exists !")
        {
            Username = username;
        }

        public UserAlreadyExistsException(string username, string message)
            : base(message)
        {
            Username = username;
        }

        public UserAlreadyExistsException(string username, string message, Exception inner)
            : base(message, inner)
        {
            Username = username;
        }

        protected UserAlreadyExistsException(
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
