using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using z1.Models;

namespace z1.Services
{
    public class DataService
    {
        private const string FinanceFile = "finance.json";
        private const string UsersFile = "users.json";
        private const string ChatFile = "chat.json";

        public List<Transaction> LoadTransactions()
        {
            try
            {
                if (!File.Exists(FinanceFile)) return new List<Transaction>();
                return JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(FinanceFile)) ?? new List<Transaction>();
            }
            catch { return new List<Transaction>(); }
        }

        public void SaveTransactions(List<Transaction> transactions) =>
            File.WriteAllText(FinanceFile, JsonConvert.SerializeObject(transactions, Formatting.Indented));

        public List<string> LoadChat()
        {
            try
            {
                if (!File.Exists(ChatFile)) return new List<string>();
                return JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ChatFile)) ?? new List<string>();
            }
            catch { return new List<string>(); }
        }

        public void SaveChat(List<string> messages) =>
            File.WriteAllText(ChatFile, JsonConvert.SerializeObject(messages, Formatting.Indented));

        public User Authenticate(string login, string password)
        {
            if (!File.Exists(UsersFile)) CreateDefaultUsers();
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(UsersFile));
            return users.FirstOrDefault(u => u.Username.ToLower() == login.ToLower() && u.Password == password);
        }

        private void CreateDefaultUsers()
        {
            var defaults = new List<User> {
                new User { Username = "admin", Password = "123", Role = UserRole.Admin },
                new User { Username = "user", Password = "123", Role = UserRole.User }
            };
            File.WriteAllText(UsersFile, JsonConvert.SerializeObject(defaults, Formatting.Indented));
        }
    }
}