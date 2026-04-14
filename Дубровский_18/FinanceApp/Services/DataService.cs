using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FinanceApp.Models;

namespace FinanceApp.Services
{
    public class DataService
    {
        private const string UsersFile = "users.json";
        private const string ChatFile = "chat.json";
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public List<string> LoadChat()
        {
            try
            {
                if (!File.Exists(ChatFile))
                {
                    return new List<string>();
                }

                var json = File.ReadAllText(ChatFile);
                return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        public void SaveChat(List<string> messages)
        {
            File.WriteAllText(ChatFile, JsonSerializer.Serialize(messages, JsonOptions));
        }

        public User? Authenticate(string login, string password)
        {
            if (!File.Exists(UsersFile))
            {
                CreateDefaultUsers();
            }

            var json = File.ReadAllText(UsersFile);
            var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            return users.FirstOrDefault(u =>
                u.Username.Equals(login, System.StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        private void CreateDefaultUsers()
        {
            var defaults = new List<User>
            {
                new() { Username = "admin", Password = "123", Role = UserRole.Admin },
                new() { Username = "user", Password = "123", Role = UserRole.User }
            };

            File.WriteAllText(UsersFile, JsonSerializer.Serialize(defaults, JsonOptions));
        }
    }
}
