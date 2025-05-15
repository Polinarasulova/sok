using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace LemonApp
{
    public class DataContext
    {
        private readonly IHostEnvironment _env;
        private string FilePath => Path.Combine(_env.ContentRootPath, "app_data.json");

        public DataContext(IHostEnvironment env)
        {
            _env = env;
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<User>();

            var json = File.ReadAllText(FilePath);
            var data = JsonSerializer.Deserialize<AppData>(json);
            return data?.Users ?? new List<User>();
        }

        public void SaveUsers(List<User> users)
        {
            var data = new AppData { Users = users };
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(FilePath, json);
        }

        private class AppData
        {
            public List<User> Users { get; set; } = new();
        }
    }
}