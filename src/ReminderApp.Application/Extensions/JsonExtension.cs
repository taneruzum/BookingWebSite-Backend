using Newtonsoft.Json;

namespace ReminderApp.Application.Extensions
{
    public static class JsonExtension
    {
        public static string SerialJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T DeserializeJson<T>(this string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}
