using System.Text.Json.Serialization;

namespace ReminderApp.Api.Registrations
{
    public static class Controller
    {
        public static IServiceCollection ControllerRegistration(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {

            })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                })
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });

            return services;
        }
    }
}
