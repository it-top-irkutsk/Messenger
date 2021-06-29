using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DB_Connection
{
    class JsonType
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    class Program
    {
        static async Task GetJson()
        {
            using (FileStream fs = new FileStream("config.json", FileMode.OpenOrCreate))
            {
                JsonType restoredJsonType = await JsonSerializer.DeserializeAsync<JsonType>(fs);
                Console.WriteLine($"Name: {restoredJsonType.Server}  Age: {restoredJsonType.Database}");
            }
        }
    }
}