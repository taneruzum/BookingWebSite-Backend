using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Dtos.User;
using System.Text;

namespace Test.Api
{
    public class ReminderTest
    {
        private ServiceCollection _services;

        public ReminderTest()
        {

        }

        public ReminderTest(ServiceCollection services)
        {
            _services = services;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task user_register_test()
        {
            using (var httpClient = new HttpClient())
            {
                CreateUserDto createUserDto = new() { Email = "test@gmail.com", Fullname = "test", Password = "test123" };
                string jsonData = System.Text.Json.JsonSerializer.Serialize(createUserDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync($"{Constats.ApiUrl}/api/User/Register-User", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                    Console.WriteLine($"Error Message: {response.StatusCode}");
            }
        }


        [Test]
        public async Task user_login_test()
        {
            using (var httpClient = new HttpClient())
            {
                LoginUserDto loginUserDto = new() { Email = "test@gmail.com", Password = "test123" };
                string jsonData = System.Text.Json.JsonSerializer.Serialize(loginUserDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync($"{Constats.ApiUrl}/api/User/Login-User", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                    Console.WriteLine($"Error Message: {response.StatusCode}");
            }
        }
    }
}